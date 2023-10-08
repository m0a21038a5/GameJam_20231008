using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager")?.GetComponent<SoundManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            soundManager.Play("Hit");
        }
    }
}
