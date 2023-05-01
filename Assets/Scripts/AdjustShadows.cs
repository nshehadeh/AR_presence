using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;
using System;
using System.Diagnostics;
using System.IO;

public class AdjustShadows : MonoBehaviour
{
    public List<Light> lights;
    public List<GameObject> buttons;

    private List<bool> btns;
    public Material selected;
    public Material deselected;

    private string file = "shadows.txt";
    private string filepath;

    private void Start()
    {
        btns = new List<bool>() {false, false, false};
        filepath = Path.Combine(Application.persistentDataPath, file);

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
        btns[2] = false;
        buttons[2].GetComponent<Renderer>().material = deselected;
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
        btns[1] = false;
        buttons[0].GetComponent<Renderer>().material = deselected;
        buttons[1].GetComponent<Renderer>().material = deselected;

        if (btns[2])
            buttons[2].GetComponent<Renderer>().material = selected;
        else
            buttons[2].GetComponent<Renderer>().material = deselected;
        WriteConfig("Btn3 change: ");
    }

    private void Update()
    {

        //UnityEngine.Debug.Log(buttons.Count);

        // button 1 pressed = no interaction no matter what
        if (btns[0])
        {
            foreach (Light light in lights)
                light.shadows = LightShadows.None;
        }
        if (btns[1])
        {
            foreach (Light light in lights)
            {
                light.shadowResolution = UnityEngine.Rendering.LightShadowResolution.Low;
                light.shadows = LightShadows.Hard;
            }
        }
        if (btns[2])
        {
            foreach (Light light in lights)
            {
                light.shadows = LightShadows.Soft;
                light.shadowResolution = UnityEngine.Rendering.LightShadowResolution.VeryHigh;
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
