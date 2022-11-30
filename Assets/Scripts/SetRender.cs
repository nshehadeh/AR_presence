using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRender : MonoBehaviour
{
    public GameObject render0;
    public GameObject render1;
    // Set to render level 0
    public void SetLevel0()
    {
        Debug.Log("Render level 0");
        render0.SetActive(true);
        render1.SetActive(false);
    }
    // Set to render level 1
    public void SetLevel1()
    {
        Debug.Log("Render level 1");
        render0.SetActive(false);
        render1.SetActive(true);
    }

}
