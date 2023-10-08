using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            soundManager.Play("Hit");
        }
    }
}
