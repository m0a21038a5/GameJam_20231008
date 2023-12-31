using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] public float MaxCount;
    [SerializeField] FadeManager fd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        TimeText.text = String.Format("{0:00.00}", MaxCount);
        if(MaxCount <= 0)
        {
            fd.OnFadeOutWaitKOMIKOMI("ResultScene");
        }
        else
        {
            MaxCount -= Time.deltaTime;
        }
    }

   
}
