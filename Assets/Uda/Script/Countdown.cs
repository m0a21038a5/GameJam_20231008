using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] Text TimeText;
    [SerializeField] float MaxCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxCount -= Time.deltaTime;
        TimeText.text = MaxCount.ToString("f1");
    }
}
