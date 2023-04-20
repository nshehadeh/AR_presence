using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class OnGrab : MonoBehaviour
{
    private ObjectManipulator objectManipulator;
    private Rigidbody rigidbody;

    void Start()
    {
        objectManipulator = GetComponent<ObjectManipulator>();
        objectManipulator.OnManipulationStarted.AddListener(Grabbed);
        objectManipulator.OnManipulationEnded.AddListener(OnRelease);
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Grabbed(ManipulationEventData eventData)
    {
        // Disable the rigidbody gravity while the object is being grabbed
        Debug.Log("Grabbing");
        rigidbody.isKinematic = false;

    }

    private void OnRelease(ManipulationEventData eventData)
    {
        // Enable the rigidbody gravity when the object is released
        Debug.Log("Releasing");
        rigidbody.useGravity = true;

    }
}