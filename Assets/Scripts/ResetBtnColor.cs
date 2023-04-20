using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ResetBtnColor : MonoBehaviour
{
    public GameObject button;
    public Material selected;
    public Material deselected;
    public void adjColor()
    {
        StartCoroutine(ColorCoroutine());

    }
    IEnumerator ColorCoroutine()
    {
        UnityEngine.Debug.Log("Selecting reset");
        button.GetComponent<Renderer>().material = selected;
        yield return new WaitForSeconds(1.5f);
        button.GetComponent<Renderer>().material = deselected;

    }
}
