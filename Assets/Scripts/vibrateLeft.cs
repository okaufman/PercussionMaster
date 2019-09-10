using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class vibrateLeft : MonoBehaviour
{

    public SteamVR_Action_Vibration hapticAction;

    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log("hatics trigger entered");

        
            hapticAction.Execute(0, 1, 150, 75, SteamVR_Input_Sources.LeftHand);
      
    }
}
