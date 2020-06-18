using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProximityDetector : MonoBehaviour
{

    public Transform startPos;
    public float rayMaxDistance = 30f;
    public float distance = 30f;

    public Action<float> onUpdateProximity;
    public Transform cube;

    private void Start()
    {
        distance = rayMaxDistance;
    }

    private void Update()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(startPos.position, startPos.forward, out hitInfo, rayMaxDistance))
        {

            distance = Vector3.Distance(startPos.position, hitInfo.point);
            onUpdateProximity?.Invoke(distance);

            //cube.localScale = Vector3.one * ((1f / 30f) * distance);
            cube.localScale = Vector3.one * ((1f / rayMaxDistance) * distance);

        }
        else
        {
            distance = rayMaxDistance;
            cube.localScale = Vector3.one;
            onUpdateProximity?.Invoke(rayMaxDistance);
        }

    }

}
