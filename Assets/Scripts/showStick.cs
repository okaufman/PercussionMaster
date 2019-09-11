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

    public float xMin = 0.3f;
    public float xMax = 0.7f;
    public float zMin = 0.3f;
    public float zMax = 0.7f;

    private bool availableSticks = false;
    private GameObject leftStick = null;
    private GameObject rightStick = null;

    Quaternion quaternion;

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = cameraView.WorldToViewportPoint(targetPoint.position);
        bool onScreen = screenPoint.x > xMin && screenPoint.x < xMax && screenPoint.z > zMin && screenPoint.z < zMax;
        if(onScreen && !availableSticks && isHandClosed())
        {
            availableSticks = true;
            leftStick = Instantiate(stickType, leftHand, false);

            //Connect joint
            Joint joint = leftHand.GetComponent<Joint>();
            Rigidbody rb = leftStick.GetComponent<Rigidbody>();
            joint.connectedBody = rb;

            rightStick = Instantiate(stickType, rightHand, false);

            //Connect joint
            Joint joint1 = rightFingerEnd.GetComponent<Joint>();
            Rigidbody rb1 = rightStick.GetComponent<Rigidbody>();
            joint1.connectedBody = rb1;
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

        if (leftHandDistanz < 0.02 && rightHandDistanz < 0.02)
            closedHand = true;

        return closedHand;
    }
}
