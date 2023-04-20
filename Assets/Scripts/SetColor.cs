using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public Material selected;
    public Material deselected;
    public GameObject se;
    public GameObject de1;
    public GameObject de2;
    public GameObject de3;

    public void Set()
    {
        se.GetComponent<Renderer>().material = selected;
        if (de1!=null)
        {
            de1.GetComponent<Renderer>().material = deselected;
        }
        if(de2!=null)
        {
            de2.GetComponent<Renderer>().material = deselected;
        }
        if (de3 != null)
        {
            de3.GetComponent<Renderer>().material = deselected;
        }

    }
}
