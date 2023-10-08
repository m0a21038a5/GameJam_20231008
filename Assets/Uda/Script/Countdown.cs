using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] Text TimeText;
    [SerializeField] public float MaxCount;
    [SerializeField] float EndCount;
    [SerializeField] FadeManager fd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        TimeText.text = MaxCount.ToString("f1");
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
