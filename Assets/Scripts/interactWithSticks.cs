using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class interactWithSticks : MonoBehaviour
{
    
   // private EVRButtonId pickUpButton = EVRButtonId.k_EButton_A;
    //private EVRButtonId dropButton = EVRButtonId.k_EButton_Grip;
    public SteamVR_Action_Boolean pickup;
    public SteamVR_Action_Boolean drop;

    FixedJoint Joint;
    GameObject stick;

   //private SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    //private SteamVR_Input_Sources RightHand = SteamVR_Input_Sources.RightHand;
    


    // Start is called before the first frame update
    void Start()
    {
        Joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drop.active)
        {
            dropStick();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stick")
        {
            if (pickup.active)
            {
                pickUpStick(other);
            }
        }
    }

    public void pickUpStick(Collider stick)
    {
        Joint.connectedBody = stick.GetComponent<Rigidbody>();
    }

    public void dropStick()
    {
        if (Joint.connectedBody != null)
        {
            Joint.connectedBody = null;
        }
        
    }
}
