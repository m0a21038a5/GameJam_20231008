using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using System.Linq;
using UnityEngine.UI;

public class ScoreRanking : MonoBehaviour
{
    [SerializeField] Text RankingText;
    int CurrentScore;
    string key = "CurrentScore";

    int StateCount;
    // Start is called before the first frame update
    void Start()
    {        
        StateCount = 0;        
    }

    private void Update()
    {
        switch(StateCount)
        {
            case 0:
            CurrentScore = PlayerPrefs.GetInt(key, 0);
            RankingText.text = "���ƕ]��:" + CurrentScore.ToString();
                break;
            case 1:
                //���ʂ̃J�E���g
                int count = 0;
                string tempScore = "";
                //�� �f�[�^�X�g�A�́udata�v�N���X���猟��
                NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("data");
                //��Score�t�B�[���h�̍~���Ńf�[�^���擾
                query.OrderByDescending("score");
                //������������5���ɐݒ�
                query.Limit = 5;
                query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
                    if (e != null)
                    {
                        UnityEngine.Debug.Log("�����L���O�擾���s");
                    }
                    else
                    {
                        //�����������̏���
                        UnityEngine.Debug.Log("�����L���O�擾����");
                        // �l�ƃC���f�b�N�X�̃y�A�����[�v����
                        foreach (NCMBObject obj in objList)
                        {
                            count++;
                            //�����[�U�[�l�[���ƃX�R�A����ʕ\��
                            tempScore += count.ToString() + "�ʁF" + "�X�R�A�F" + obj["score"] + "\r\n";
                        }
                        RankingText.GetComponent<Text>().text = tempScore;
                    }
                });
                break;
        }
        if(Input.anyKey)
        {
            StateCount++;
        }
    }

}
