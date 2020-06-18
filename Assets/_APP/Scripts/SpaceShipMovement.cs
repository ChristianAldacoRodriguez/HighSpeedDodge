using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 5f;
    public bool canMove = true;

    [Header("Rails")]
    public float railsChangeSpeed = 5f;
    public float railsSeparation = 3f;
    public Vector3 currentRail = Vector3.zero;

    [Header("Animation")]
    public Animator anim;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentRail.x -= railsSeparation;
            anim.SetTrigger("Left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentRail.x += railsSeparation;
            anim.SetTrigger("Right");
        }

        Vector3 currentNextPosition = new Vector3(currentRail.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, currentNextPosition, Time.deltaTime * railsChangeSpeed);
    }

}
