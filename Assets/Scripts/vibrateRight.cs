using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class vibrateRight : MonoBehaviour
{

    public SteamVR_Action_Vibration hapticAction;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hatics trigger entered");


        hapticAction.Execute(0, 0.1f, 150, 75, SteamVR_Input_Sources.RightHand);
        

    }
}
