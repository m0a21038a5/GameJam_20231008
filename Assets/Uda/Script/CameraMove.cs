using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    CinemachinePOV pov;
    [SerializeField] GameObject FirstLookAtObject;
    // Start is called before the first frame update
    void Start()
    {
        // CinemachineVirtualCameraからCinemachineComposerを取得
        pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        float verticalRotation = FirstLookAtObject.transform.rotation.eulerAngles.x;
        pov.m_VerticalAxis.Value = verticalRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            pov.m_HorizontalAxis.m_InputAxisName = "Horizontal";
        }
        else
        {
            // より低い優先度のInputを設定
            pov.m_HorizontalAxis.m_InputAxisName = "Mouse X";
        }
    }
}
