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

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = cameraView.WorldToViewportPoint(targetPoint.position);
        bool onScreen = screenPoint.x > 0.4 && screenPoint.x < 0.6 && screenPoint.z > 0.4 && screenPoint.z > 0.6;
        if(onScreen && !availableSticks)
        {
            availableSticks = true;
            leftStick = Instantiate(stickType, -leftHand.position + new Vector3(0,0.1f,0), leftHand.rotation, leftHand);
            rightStick = Instantiate(stickType, rightHand.position + new Vector3(0, 0.1f, 0), rightHand.rotation, rightHand);
        }
        else if(!onScreen)
        {
            availableSticks = false;
            Destroy(leftStick);
            Destroy(rightStick);
        }
    }
}
