using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class ScoreText : MonoBehaviour
{
    [SerializeField] int ScorePlusCount;
    int ScoreCount;
    [SerializeField] Text Scoretext;
    Countdown cd;

    bool Clear;

    string key = "CurrentScore";

    // ���N���X��NCMBObject�idata�j���쐬
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
        Scoretext.text = "Score : " + ScoreCount + "p";
        if(cd.MaxCount <= 0 && !Clear)
        {
            Clear = true;
            isClear();
        }
    }

    public void PlusScore()
    {
        ScoreCount += ScorePlusCount;
    }

    public void isClear()
    {
        // ��score���udata�v�N���X�ɕۑ�����
        data["score"] = ScoreCount;
        // ���f�[�^�X�g�A�i�udata�v�N���X�j�ւ̓o�^
        data.SaveAsync();
        PlayerPrefs.SetInt(key,ScoreCount);
    }
}
