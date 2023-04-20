using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;
using System;
using System.Diagnostics;

public class AdjustInteractionOldGrabbable : MonoBehaviour
{
    public List<GameObject> objectsToManipulate;
    public List<GameObject> buttons;

    // Initial levels
    //public bool btn1;
    //public bool btn2;
    //public bool btn3;
    //public bool btn4;
    public List<bool> btns;
    public Material selected;
    public Material deselected;

    private List<ObjectManipulator> objectManipulators;
    private List<NearInteractionGrabbable> objectNears;
    private List<NearInteractionTouchable> objectTouch;



    private void Start()
    {
        // Get the ObjectManipulator and near interactable component from each object in the list
        objectManipulators = new List<ObjectManipulator>();
        objectNears = new List<NearInteractionGrabbable>();
        btns = new List<bool>() { false, false, false };
        //buttons = new List<GameObject>();
        foreach (GameObject obj in objectsToManipulate)
        {
            ObjectManipulator manipulator = obj.GetComponent<ObjectManipulator>();
            NearInteractionGrabbable grabbable = obj.GetComponent<NearInteractionGrabbable>();
            NearInteractionTouchable touchable = obj.GetComponent<NearInteractionTouchable>();



            if (manipulator != null)
            {
                objectManipulators.Add(manipulator);
                manipulator.enabled = false;
                objectNears.Add(grabbable);
                grabbable.enabled = false;
                objectTouch.Add(touchable);
                touchable.enabled = false;

            }
        }
        string boolList = string.Join(", ", btns);
        // UnityEngine.Debug.Log("Initial btn vals: " + boolList);

    }
    public void reset()
    {
        btns[0] = false;
        btn1_press();
    }
    public void btn1_press()
    {
        btns[0] = !btns[0];
        // if turned on
        if (btns[0])
        {
            UnityEngine.Debug.Log("Resetting other buttons & turning on none");
            buttons[1].GetComponent<Renderer>().material = deselected;
            buttons[2].GetComponent<Renderer>().material = deselected;
            btns[1] = false;
            btns[2] = false;
            buttons[0].GetComponent<Renderer>().material = selected;
        }
        else
        {
            buttons[0].GetComponent<Renderer>().material = deselected;
        }
        string boolList = string.Join(", ", btns);
        //UnityEngine.Debug.Log("After btn none pressed vals: " + boolList);
    }
    public void btn2_press()
    {
        btns[1] = !btns[1];
        btns[0] = false;
        buttons[0].GetComponent<Renderer>().material = deselected;
        if (btns[1])
        {
            buttons[1].GetComponent<Renderer>().material = selected;
        }
        else
        {
            buttons[1].GetComponent<Renderer>().material = deselected;
        }
        string boolList = string.Join(", ", btns);
        //UnityEngine.Debug.Log("Initial btn vals: " + boolList);
    }


    public void btn3_press()
    {
        btns[2] = !btns[2];
        btns[0] = false;
        buttons[0].GetComponent<Renderer>().material = deselected;
        if (btns[2])
        {
            buttons[2].GetComponent<Renderer>().material = selected;
        }
        else
        {
            buttons[2].GetComponent<Renderer>().material = deselected;
        }
        string boolList = string.Join(", ", btns);
        // UnityEngine.Debug.Log("Initial btn vals: " + boolList);
    }

    private void Update()
    {
        //UnityEngine.Debug.Log(buttons.Count);

        // button 1 pressed = no interaction no matter what
        if (btns[0])
        {
            // Disable the object manipulators
            foreach (ObjectManipulator manipulator in objectManipulators)
            {
                manipulator.enabled = false;
            }
            foreach (NearInteractionGrabbable grabbable in objectNears)
            {
                grabbable.enabled = false;
            }
            foreach (NearInteractionTouchable touchable in objectTouch)
            {
                touchable.enabled = false;
            }
        }
        // button 2 pressed = near interactable on
        if (!btns[1])
        {
            foreach (NearInteractionGrabbable grabbable in objectNears)
            {
                grabbable.enabled = false;

            }
            foreach (NearInteractionTouchable touchable in objectTouch)
            {
                touchable.enabled = false;
            }
        }
        if (btns[1] && !btns[0])
        {
            // Disable the object manipulators
            foreach (ObjectManipulator manipulator in objectManipulators)
            {
                manipulator.enabled = true;
                // manipulator.NearInteractionTouchable = nearInteraction;

            }
            foreach (NearInteractionTouchable touchable in objectTouch)
            {
                touchable.enabled = true;
            }
            foreach (NearInteractionGrabbable grabbable in objectNears)
            {
                grabbable.enabled = true;
            }

        }
        if (!btns[2])
        {
            foreach (ObjectManipulator manipulator in objectManipulators)
            {
                manipulator.enabled = true;

                manipulator.disallowFar();
            }
        }
        // far interaction on, no close interaction
        else if (btns[2] && !btns[0])
        {
            foreach (ObjectManipulator manipulator in objectManipulators)
            {
                manipulator.enabled = true;

                manipulator.allowFar();
            }
        }
        /*
        else if (btns[2] && !btns[1])
        {
            foreach(ObjectManipulator manipulator in objectManipulators)
            {
                manipulator.NearInteractionTouchable = null;
            }
        }*/
    }
}
