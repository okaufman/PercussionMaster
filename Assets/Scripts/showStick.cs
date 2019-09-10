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

    private bool availableSticks = false;
    private GameObject leftStick = null;
    private GameObject rightStick = null;
    private Quaternion rotationLeftHand;
    private Quaternion rotationRightHand;

    Quaternion quaternion;

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = cameraView.WorldToViewportPoint(targetPoint.position);
        bool onScreen = screenPoint.x > 0.4 && screenPoint.x < 0.6 && screenPoint.z > 0.4 && screenPoint.z > 0.6;
        if(onScreen && !availableSticks)
        {
            rotationLeftHand = leftHand.rotation;
            rotationRightHand = rightHand.rotation;
            rotationLeftHand.Set(0, 0, 90, 0);
            rotationRightHand.Set(0, 0, 90, 0);
            availableSticks = true;
            leftStick = Instantiate(stickType, leftHand.position + new Vector3(0,0.1f,0), rotationLeftHand, leftHand);
            rightStick = Instantiate(stickType, rightHand.position + new Vector3(0, 0.1f, 0), rotationRightHand, rightHand);
        }
        else if(!onScreen)
        {
            availableSticks = false;
            Destroy(leftStick);
            Destroy(rightStick);
        }
    }
}
