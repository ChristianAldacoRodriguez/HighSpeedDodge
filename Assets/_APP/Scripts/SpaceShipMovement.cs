using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaceShipMovement : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 5f;
    public bool canMove = true;
    public float distanceCompleted = 0f;

    [Header("Rails")]
    public int maxRails = 4;
    public float railsChangeSpeed = 5f;
    public float railsSeparation = 3f;
    public Vector3 currentRail = Vector3.zero;

    public Action<int> onMove;
    public Action<float> onUpdate;

    [Header("Animation")]
    public Animator anim;

    private void Update()
    {
        float delta = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * delta);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentRail.x > railsSeparation * -maxRails)
        {
            currentRail.x -= railsSeparation;
            onMove?.Invoke(-1);
            anim.SetTrigger("Left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentRail.x < railsSeparation * maxRails)
        {
            currentRail.x += railsSeparation;
            onMove?.Invoke(1);
            anim.SetTrigger("Right");
        }

        Vector3 currentNextPosition = new Vector3(currentRail.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, currentNextPosition, Time.deltaTime * railsChangeSpeed);

        distanceCompleted += delta;
        onUpdate?.Invoke(delta);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
    }

}
