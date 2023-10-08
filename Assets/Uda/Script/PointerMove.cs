using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMove : MonoBehaviour
{
    [SerializeField] public GameObject TargetImage;

    // Start is called before the first frame update
    void Start()
    {
        // �J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;

        // �J�[�\����\��
        Cursor.visible = false;

        TargetImage.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
    }
}
