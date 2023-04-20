using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class NoBounce : MonoBehaviour, IMixedRealityPointerHandler
{
    private PhysicMaterial originalMaterial;
    public PhysicMaterial noBounceMaterial;

    void Start()
    {
        originalMaterial = GetComponent<SphereCollider>().material;
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        GetComponent<SphereCollider>().material = noBounceMaterial;
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        GetComponent<SphereCollider>().material = originalMaterial;
    }
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        // Do nothing
    }
    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        // Do nothing
    }
}