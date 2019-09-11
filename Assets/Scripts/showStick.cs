using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showStick : MonoBehaviour
{
    public GameObject stickType;
    public Camera cameraView;
    public Transform targetPoint;
    public Transform leftHand;
    public Transform rightHand;

    public Transform leftPalm, rightPalm, leftFingerEnd, rightFingerEnd;

    private bool availableSticks = false;
    private GameObject leftStick = null;
    private GameObject rightStick = null;
    private Transform transformLefStick;
    private Transform transformRightStick;
    private Quaternion rotationLeftStick;
    private Quaternion rotationRightHand;

    Quaternion quaternion;

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = cameraView.WorldToViewportPoint(targetPoint.position);
        bool onScreen = screenPoint.x > 0.4 && screenPoint.x < 0.6 && screenPoint.z > 0.4 && screenPoint.z > 0.6;
        if(onScreen && !availableSticks && isHandClosed())
        {
            availableSticks = true;
            leftStick = Instantiate(stickType, leftHand,false);
            rightStick = Instantiate(stickType, rightHand, false);
            transformLefStick = leftStick.GetComponent<Transform>();
        }
        else if(!onScreen || !isHandClosed())
        {
            availableSticks = false;
            Destroy(leftStick);
            Destroy(rightStick);
        }
    }

    bool isHandClosed()
    {
        bool closedHand = false;

        float leftHandDistanz = (leftPalm.position - leftFingerEnd.position).sqrMagnitude;
        float rightHandDistanz = (rightPalm.position - rightFingerEnd.position).sqrMagnitude;

        Debug.Log("Left: " + leftHandDistanz);
        Debug.Log("Right: " + rightHandDistanz);

        if (leftHandDistanz < 0.02 && rightHandDistanz < 0.02)
            closedHand = true;

        return closedHand;
    }
}
