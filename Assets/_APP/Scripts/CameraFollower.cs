using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    public float followSpeed = 10f;

    public bool lookAt = false;
    public float lookAtSpeed = 3f;
    


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * followSpeed);

        if (lookAt)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation( target.position - transform.position, Vector3.up), Time.deltaTime * lookAtSpeed);
        }
    }


}
