using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class vibrateLeft : MonoBehaviour
{

    public SteamVR_Action_Vibration hapticAction;

    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log("haptics trigger entered");

        
            hapticAction.Execute(0, 0.1f, 150, 75, SteamVR_Input_Sources.LeftHand);
      
    }
}
