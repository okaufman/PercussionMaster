using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHand : MonoBehaviour
{
    public Transform leftPalm, rightPalm, leftFingerEnd, rightFingerEnd;

    // Update is called once per frame
    void Update()
    {
        float leftHandDistanz = (leftPalm.position - leftFingerEnd.position).sqrMagnitude;
        float rightHandDistanz = (rightPalm.position - rightFingerEnd.position).sqrMagnitude;

        Debug.Log("Left Hand - Distanz" + leftHandDistanz);
        Debug.Log("Right Hand - Distanz" + rightHandDistanz);
    }
}
