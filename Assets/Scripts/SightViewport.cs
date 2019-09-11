using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightViewport : MonoBehaviour
{
    public Light spotLight;
    public Camera cameraView;
    public Transform targetPoint;

    public float xMin = 0.3f;
    public float xMax = 0.7f;
    public float zMin = 0.3f;
    public float zMax = 0.7f;

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = cameraView.WorldToViewportPoint(targetPoint.position);
        Debug.Log(targetPoint.name + " " + screenPoint);
        bool onScreen = screenPoint.x > xMin && screenPoint.x < xMax && screenPoint.z > zMin && screenPoint.z < zMax;
        if(onScreen)
            spotLight.intensity = 1;
        else
            spotLight.intensity = 0;
    }
}
