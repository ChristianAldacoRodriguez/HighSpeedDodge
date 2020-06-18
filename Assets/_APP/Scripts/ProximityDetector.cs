using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProximityDetector : MonoBehaviour
{

    public Transform startPos;
    public float rayMaxDistance = 30f;

    public Action<float> onDetectSomething;
    public Transform cube;

    private void Update()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(startPos.position, startPos.forward, out hitInfo, rayMaxDistance))
        {

            float distance = Vector3.Distance(startPos.position, hitInfo.point);
            onDetectSomething?.Invoke(distance);

            //cube.localScale = Vector3.one * ((1f / 30f) * distance);
            cube.localScale = Vector3.one * ((1f / rayMaxDistance) * distance);

        }
        else
        {
            cube.localScale = Vector3.one;
        }

    }

}
