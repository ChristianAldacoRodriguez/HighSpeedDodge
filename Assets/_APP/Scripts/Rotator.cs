using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField]private Vector3 _angle;
    [SerializeField] private Space _space;

    private void FixedUpdate()
    {
        transform.Rotate(_angle * Time.deltaTime, _space);
    }

}
