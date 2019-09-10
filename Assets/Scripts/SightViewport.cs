using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightViewport : MonoBehaviour
{
    public Light spotLight;
    public Camera cameraView;
    public Transform targetPoint;

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = cameraView.WorldToViewportPoint(targetPoint.position);
        bool onScreen = screenPoint.x > 0.4 && screenPoint.x < 0.6 && screenPoint.z > 0.4 && screenPoint.z > 0.6;
        if(onScreen)
            spotLight.intensity = 1;
        else
            spotLight.intensity = 0;
    }
}
