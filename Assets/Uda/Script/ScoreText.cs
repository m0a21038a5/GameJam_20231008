using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class ScoreText : MonoBehaviour
{
    [SerializeField] int ScorePlusCount;
    int ScoreCount;
    int StudentNumber;
    [SerializeField] Text Scoretext;
    Countdown cd;

    bool Clear;

    string key = "CurrentScore";
    string Wkey = "CurrentNumber";

    // ★クラスのNCMBObject（data）を作成
    NCMBObject data = new NCMBObject("data");
    // Start is called before the first frame update
    void Start()
    {
        ScoreCount = 0;
        cd = GetComponent<Countdown>();
        Clear = false;
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Score : " + ScoreCount;
        if(cd.MaxCount <= 0 && !Clear)
        {
            Clear = true;
            isClear();
        }
    }

    public void PlusScore()
    {
        ScoreCount += ScorePlusCount;
        StudentNumber++;
    }

    public void isClear()
    {
        // ★scoreを「data」クラスに保存する
        data["score"] = ScoreCount;
        // ★データストア（「data」クラス）への登録
        data.SaveAsync();
        PlayerPrefs.SetInt(key,ScoreCount);
        PlayerPrefs.SetInt(Wkey, StudentNumber);
    }
}
