using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Management.Instrumentation;
using UnityEngine;

public class SetPhysics2 : MonoBehaviour
{
    public Rigidbody body;
    public Collider desk;
    //private ObjectsReset obj = model.GetComponent<ObjectReset>();

    // Level 1: no physics, unmovable
    public void SetLevel1()
    {
        Debug.Log("Physics Level 1: Kinematic");
        //obj.resetPosition();
        body.isKinematic = true;
    }
    // Level 2: kinematic objects
    public void SetLevel2()
    {
        Debug.Log("Physics Level 2: Not kinematic, no gravity");
        //obj.resetPosition();
        body.isKinematic = false;

    }
    // Level 3: nonkinematic, no collisions
    public void SetLevel3()
    {
        Debug.Log("Physics level 3: Nonkinematic, Inelastic");
        //obj.resetPosition();
        desk.enabled = true;
    }

    // Level 4: full physics, gravity
    public void SetLevel4()
    {
        Debug.Log("Physics level 4: Full physics, gravity");
        //obj.resetPosition();
        body.useGravity = true;
    }
}
