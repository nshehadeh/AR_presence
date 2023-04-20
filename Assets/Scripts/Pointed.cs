using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class Pointed : MonoBehaviour, IMixedRealityPointerHandler
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject. Please add a Rigidbody component.");
            return;
        }
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        rb.isKinematic = false;
        Debug.Log("Pointed, making kinematic false");

    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }

    public void OnPointerUp(MixedRealityPointerEventData eventData) { }

    public void OnPointerClicked(MixedRealityPointerEventData eventData) { }
}