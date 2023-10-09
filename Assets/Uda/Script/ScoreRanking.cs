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
    [SerializeField] Image RankImage;
    public List<Sprite> ImageList;
    /*
    0 = B,
    1 = A,
    2 = S
    */
    // Start is called before the first frame update
    void Start()
    {        
        StateCount = 1;
        CurrentScore = PlayerPrefs.GetInt(key, 0);

        if(CurrentScore < 50)
        {
            RankImage.sprite = ImageList[0]; 
        }
        else if(CurrentScore > 50 && CurrentScore < 100)
        {
            RankImage.sprite = ImageList[1];
        }
        else
        {
            RankImage.sprite = ImageList[2];
        }
    }

    private void Update()
    {
        switch(StateCount)
        {
            case 0:
            CurrentScore = PlayerPrefs.GetInt(key, 0);
            RankingText.text = "授業評価:" + CurrentScore.ToString();
                break;
            case 1:
                //順位のカウント
                int count = 0;
                string tempScore = "";
                //★ データストアの「data」クラスから検索
                NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("data");
                //★Scoreフィールドの降順でデータを取得
                query.OrderByDescending("score");
                //★検索件数を5件に設定
                query.Limit = 5;
                query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
                    if (e != null)
                    {
                        UnityEngine.Debug.Log("ランキング取得失敗");
                    }
                    else
                    {
                        //検索成功時の処理
                        UnityEngine.Debug.Log("ランキング取得成功");
                        // 値とインデックスのペアをループ処理
                        foreach (NCMBObject obj in objList)
                        {
                            count++;
                            //★ユーザーネームとスコアを画面表示
                            tempScore += count.ToString() + "位：" + "スコア：" + obj["score"] + "\r\n";
                        }
                        RankingText.GetComponent<Text>().text = tempScore;
                    }
                });
                break;
        }
        /*
        if(Input.anyKey)
        {
            StateCount++;
        }
        */
    }

}
