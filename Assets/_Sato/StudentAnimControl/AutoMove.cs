using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;

    private float MoveSpeed = 3.0f;
    private int direction = -1;

    private void FixedUpdate()
    {
        if (transform.position.x >= _RightEdge.position.x)
        {
            transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            direction = -1;
        }
        if (transform.position.x <= _LeftEdge.position.x)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            direction = 1;
        }

        transform.position = 
            new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime * direction,transform.position.y,transform.position.z);
    }
}
