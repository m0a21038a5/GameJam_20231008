using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFirstRotation : MonoBehaviour
{
    [SerializeField] Vector3 FirstLookAt;
    [SerializeField] GameObject VirtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(FirstLookAt, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = VirtualCamera.transform.position;
    }
}
