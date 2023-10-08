using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] float ScorePlusCount;
    float ScoreCount;
    [SerializeField] Text Scoretext;
    // Start is called before the first frame update
    void Start()
    {
        ScoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Score : " + ScoreCount.ToString("f1") + "p";
    }

    public void PlusScore()
    {
        ScoreCount += ScorePlusCount;
    }
}
