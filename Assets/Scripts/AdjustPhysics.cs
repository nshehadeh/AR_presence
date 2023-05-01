using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;
using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

public class AdjustPhysics : MonoBehaviour
{
    public List<GameObject> objects;
    public List<GameObject> buttons;
    private List<Rigidbody> bodies;

    private List<bool> btns;
    private List<bool> g;

    public Material selected;
    public Material deselected;

    public List<Collider> colliders;

    private string file = "physics.txt";
    private string filepath;


    private void Start()
    {
        filepath = Path.Combine(UnityEngine.Application.persistentDataPath, file);

        // Get the ObjectManipulator and near interactable component from each object in the list
        btns = new List<bool>() { false, false, false, false };
        g = Enumerable.Repeat(false, objects.Count).ToList();

        bodies = new List<Rigidbody>();
        foreach (GameObject obj in objects)
        {
            obj.GetComponent<ObjectManipulator>().OnManipulationStarted.AddListener(Grabbed);
            obj.GetComponent<ObjectManipulator>().OnManipulationEnded.AddListener(Released);

            bodies.Add(obj.GetComponent<Rigidbody>());
        }

    }
    public void reset()
    {
        btns[0] = false;
        btn1_press();
        WriteConfig("Reset: ");

    }
    public void btn1_press()
    {
        btns[0] = !btns[0];
        if (btns[0])
        {
            for (int i = 1; i < btns.Count; i++)
            {
                buttons[i].GetComponent<Renderer>().material = deselected;
                btns[i] = false;
            }
            buttons[0].GetComponent<Renderer>().material = selected;
        }
        else
            buttons[0].GetComponent<Renderer>().material = deselected;
        WriteConfig("Btn1 change: ");

    }
    public void btn2_press()
    {
        btns[1] = !btns[1];
        btns[0] = false;
        buttons[0].GetComponent<Renderer>().material = deselected;
        if (btns[1])
            buttons[1].GetComponent<Renderer>().material = selected;
        else
            buttons[1].GetComponent<Renderer>().material = deselected;
        WriteConfig("Btn2 change: ");

    }


    public void btn3_press()
    {
        btns[2] = !btns[2];
        btns[0] = false;
        buttons[0].GetComponent<Renderer>().material = deselected;
        if (btns[2])
            buttons[2].GetComponent<Renderer>().material = selected;
        else
            buttons[2].GetComponent<Renderer>().material = deselected;
        WriteConfig("Btn3 change: ");

    }

    public void btn4_press()
    {
        btns[0] = false;
        buttons[0].GetComponent<Renderer>().material = deselected;
        btns[3] = !btns[3];
        if (btns[3])
            buttons[3].GetComponent<Renderer>().material = selected;
        else
            buttons[3].GetComponent<Renderer>().material = deselected;
        WriteConfig("Btn4 change: ");

    }

    private void Update()
    {

        //UnityEngine.Debug.Log(buttons.Count);

        // button 1 pressed = no interaction no matter what
        int index = 0;
        if (btns[0])
        {
            index = 0;
            foreach (Rigidbody bod in bodies)
            {
                // if not currently being grabbed
                if (!g[index])
                    bod.isKinematic = true;
               
                index++;
            }
            foreach (Collider col in colliders)
                col.enabled = false;
        }
        /*
        if (btns[1])
        {
            foreach (Rigidbody bod in bodies)
                bod.isKinematic = false;
        }
        else
        {
            foreach (Rigidbody bod in bodies)
                bod.isKinematic = true;
        }
        */
        index = 0;
        foreach (Rigidbody bod in bodies)
        {
            if (!g[index])
                bod.isKinematic = !btns[1];
            index++;
        }
        /*
        if (btns[2])
        {
            foreach (Collider col in colliders)
                col.enabled = true;
        }
        else
        {
            foreach (Collider col in colliders)
                col.enabled = false;
        }*/
        foreach (Collider col in colliders)
            col.enabled = btns[2];
        foreach (Rigidbody bod in bodies)
            bod.useGravity = btns[3];

    }
    /*
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        foreach (Rigidbody bod in bodies)
        {
            bod.isKinematic = false;
        }
    }
    */
    private void Grabbed(ManipulationEventData eventData)
    {
        // Disable the rigidbody gravity while the object is being grabbed
        //UnityEngine.Debug.Log("Grabbing");
        GameObject manipulatedObject = eventData.ManipulationSource;
       
        // Get a reference to the Rigidbody component of the object being manipulated
        Rigidbody rb = manipulatedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            int index = 0;
            foreach (Rigidbody bod in bodies)
            {
                // if not currently being grabbed
                if (bod == rb)
                {
                    g[index] = true;
                    //UnityEngine.Debug.Log("Setting g of an object to true (being grabbed) at index " + index);
                }
                index++;
            }
            //UnityEngine.Debug.Log("Setting kinematic to false");

            // Apply feature to the Rigidbody component of the object being manipulated
            rb.isKinematic = false;
        }
    }
    private void Released(ManipulationEventData eventData)
    {
        GameObject manipulatedObject = eventData.ManipulationSource;

        // Get a reference to the Rigidbody component of the object being manipulated
        Rigidbody rb = manipulatedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            int index = 0;
            foreach (Rigidbody bod in bodies)
            {
                // if not currently being grabbed
                if (bod == rb)
                    g[index] = false;
                index++;
            }
        }
    }
    private void WriteConfig(string message)
    {
        // Create a new file and write the message and boolean values to it
        using (StreamWriter writer = new StreamWriter(filepath))
        {
            writer.WriteLine(message);

            for (int i = 0; i < btns.Count; i++)
            {
                writer.Write(btns[i] + ", ");
            }
        }
    }

}
