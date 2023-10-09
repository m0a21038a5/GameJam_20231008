using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    SEManager se;
    // Start is called before the first frame update
    void Start()
    {
        se = GameObject.FindGameObjectWithTag("SE").GetComponent<SEManager>();
        se.ResultSE();
       

        // カーソル非表示
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        // カーソル非表示
        Cursor.visible = true;
    }
}
