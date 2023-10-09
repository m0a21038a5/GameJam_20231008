using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentStudent : MonoBehaviour
{
    int CurrentStudentNumder;
    [SerializeField] Text StudentNumber;
    string Wkey = "CurrentNumber";
    // Start is called before the first frame update
    void Start()
    {
        CurrentStudentNumder = PlayerPrefs.GetInt(Wkey, 0);
        StudentNumber.text = CurrentStudentNumder.ToString() + "êl";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
