using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ObjectsReset : MonoBehaviour
{
    public GameObject model;

    private Vector3 origPos;
    private Quaternion origRot;
    // Start is called before the first frame update
    void Start()
    {
        origPos = model.transform.position;
        origRot = model.transform.rotation;
        // Debug.Log("Original pos: " + origPos.x + origPos.y + origPos.z);

    }
    // ex
    // Reset the position to the original position
    public void resetPosition()
    {
        // Debug.Log("Triggered");
        // Debug.Log("Curr pos: "+ model.transform.position.x+ model.transform.position.y+ model.transform.position.z);
        model.transform.position = origPos;
        model.transform.rotation = origRot;
        // Debug.Log("Reset pos: "+ model.transform.position.x+ model.transform.position.y+ model.transform.position.z);
        model.GetComponent<Rigidbody>().velocity = Vector3.zero;
        model.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
