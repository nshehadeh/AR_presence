using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SetShadows : MonoBehaviour
{
    public Light slight;


    //private ObjectsReset obj = model.GetComponent<ObjectReset>();

    // Level 1: no physics, unmovable
    public void SetLevel1()
    {
        Debug.Log("Shadows Level 1: no shadows");
        slight.shadows = LightShadows.None;
    }
    // Level 2: no physics, unmovable
    public void SetLevel2()
    {
        Debug.Log("Shadows Level 2: blob shadows");
        //slight.shadows = LightShadows.None;
    }
    // Level 3: no physics, unmovable
    public void SetLevel3()
    {
        Debug.Log("Shadows Level 3: hard shadows");
        slight.shadows = LightShadows.Hard;
    }
    // Level 4: no physics, unmovable
    public void SetLevel4()
    {
        Debug.Log("Shadows Level 4: soft shadows");
        slight.shadows = LightShadows.Soft;
    }

}