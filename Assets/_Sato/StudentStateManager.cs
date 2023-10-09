using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class StudentStateManager : MonoBehaviour
{
    //生徒の状態
    public enum StudentState
    {
        Null = -1,
        nomal,
        sleep,
        nomal_slept //リストオーバー回避　もう寝ることが無い状態。
    }

    public StudentState currentState;


    //時間経過でStateを眠りにする。

    //Sleepまでの時間
    [SerializeField] public List<float> sleepTimeList = new List<float>() { };
    [SerializeField] public List<float> awakeTimeList = new List<float>() { };
    [SerializeField] int MaxSleepTime; //何回眠るか
    [SerializeField] int currentSleepTime; //現在、何回目の眠りか。
    [SerializeField] int currentAwakeTime;

    [SerializeField] Image sleepingUI;
    [SerializeField] Image awakeUI;
    private int m_awakeTime;
    private int m_SirentSlept;

    //タイマー
    private float startTimer;
    private float currentTimer;

    ////パーティクル
    //[SerializeField] GameObject particl_ZZZ;
    //[SerializeField] GameObject particl_WakeUp;

    //private GameObject Unchi;
    //private GameObject Unchi_Mark2;

    //デバック用　経過秒数表示
    //[SerializeField] TextMeshProUGUI timeText;

    //アニメーション遷移
    private Animator animator;

    bool onece;
    Vector3 pos;

    //public int rand;

    void Start()
    {
        currentSleepTime = 0;
        MaxSleepTime = sleepTimeList.Count;
        sleepingUI.gameObject.SetActive(false);
        awakeUI.gameObject.SetActive(false);

        currentState = StudentState.nomal;
        //StateChange(currentState);

        pos = sleepingUI.transform.position;

        animator = GetComponent<Animator>();

        startTimer = Time.time;

        //びっくりUI
        awakeUI.rectTransform.DOLocalMove(new Vector3(10f, 8f, 0f), 0.3f)
                                           .SetLoops(-1, LoopType.Restart)
                                           .SetRelative();
        //awakeUI.DOFade(0.0f, 0.9f)
        //          .SetLoops(-1, LoopType.Restart);
    }

    void Update()
    {
        ////ーーーーーーーーーーーーーーーーー動作確認デバック用　後で消す。ーーーーーーーーーーーー
        //if (Input.GetMouseButtonDown(0))
        //{
        //    OnAwake(currentSleepTime);
        //}
        ////ーーーーーーーーーーーーーーーー動作確認デバッグ用ーーーーーーーーーーーーー
        //timeText.text = currentTimer.ToString();
        ////---------------------------------------------------------------------------


        currentTimer = Time.time - startTimer;


        //if(sleepTimeList.Count > currentSleepTime)
        //{
        //    StateChange(currentState = StudentState.nomal_slept);
        //}
        //ノーマル状態
        if (currentState == StudentState.nomal)
        {


            if (sleepTimeList.Count > currentSleepTime)
            {
                //指定した時間が経過
                if (currentTimer >= sleepTimeList[currentSleepTime])
                {
                    //ステイト変更
                    currentState = StudentState.sleep;

                    if (sleepTimeList.Count > currentSleepTime)
                    {
                        //ねむった回数を加算。
                        currentSleepTime++;
                    }

                    //既に起きている場合は、強制的に起こすリストを次行へ。
                    if (currentTimer >= awakeTimeList[currentAwakeTime])
                    {
                        currentAwakeTime++;
                    }
                }
            }
            else
            {
                currentState = StudentState.nomal_slept;
            }
        }
        //眠っている時
        if(currentState == StudentState.sleep)
        {
            if (awakeTimeList.Count > m_awakeTime)
            {
                Debug.Log("何回起きたか" + currentAwakeTime);


                //強制的に起こす。
                if (currentTimer >= awakeTimeList[currentAwakeTime])
                {
                    Debug.Log("何回起きたか" + currentAwakeTime);

                    //
                    currentState = StudentState.nomal;
                    OnAwake();


                    if (awakeTimeList.Count > m_awakeTime)
                    {
                        //起きた回数を加算。
                        currentAwakeTime++;
                    }

                }
                //一度だけ呼び出す Dotween
                if (!onece)
                {
                    DoMoveText();
                    onece = true;
                }

                StateChange(currentState);
            }
        }
        //
        else if (currentState == StudentState.nomal_slept)
        {
            awakeUI.gameObject.SetActive(false);
        }
    }



    //起こされた時の処理　引数：起きた回数
    public void OnAwake()  //OnAwake(studentStateManager(→インスタンス名).currentSleepTime)　で呼び出してください
    {
        m_awakeTime++;
        //ここに、起こされた瞬間のレスポンス
        sleepingUI.gameObject.SetActive(false);
        awakeUI.gameObject.SetActive(true);
        //一定経過後、Falseにする。
        StartCoroutine(DelayOnAwake());
        Debug.Log("起こされた");


        animator.SetBool("wakeUp", true);
        animator.SetBool("sleep", false);

        ////起こさずに放置していた時の例外処理
        //if(m_awakeTime < currentSleepTime)
        //{
        //    m_awakeTime = currentSleepTime;


        //}

        //眠る最大回数を超えていたら
        if (currentSleepTime > MaxSleepTime)
        {
            currentState = StudentState.nomal_slept;

            StateChange(currentState);
        }
        else
        {
            currentState = StudentState.nomal;
            StateChange(currentState);
        }
    }

    //各ステイト中の処理
    private void StateChange(StudentState studentState01)
    {
        //通常時
        if(studentState01 == StudentState.nomal || studentState01 == StudentState.nomal_slept)
        {
            ////ZZZを消す。
            //Destroy(Unchi);


            sleepingUI.gameObject.SetActive(false);
            //awakeUI.gameObject.SetActive(false);

            //アニメーション
            //animator.SetBool("sleep", false);

            //------仮実装　デバッグ用
            //gameObject.GetComponent<Renderer>().material.color = Color.red;
            //------------
        }

        //睡眠状態中
        else if (studentState01 == StudentState.sleep)
        {
            sleepingUI.gameObject.SetActive(true);
            awakeUI.gameObject.SetActive(false);


            //sleepingUI.text = "Z";

            //アニメーション　：　スリープを再生
            animator.SetBool("sleep", true);
            animator.SetBool("wakeUp", false);

            //ーーーーーーーーーーーーー仮実装　デバッグ用ーーーーーーーーーーーー
            //gameObject.GetComponent<Renderer>().material.color = Color.blue;
            //------------------------------------------------------------
        }
    }

    private void DoMoveText()
    {
        var tween =sleepingUI.rectTransform.DOLocalMove(new Vector3(10f, 8f, 0f), 0.9f)
                                           .SetLoops(-1, LoopType.Restart)
                                           .SetRelative();

        sleepingUI.DOFade(0.0f, 0.9f)
            .SetLoops(-1, LoopType.Restart);
            //.SetRelative();
    }


    // コルーチン本体
    private IEnumerator DelayOnAwake()
    { 
        // ○秒間待つ
        yield return new WaitForSeconds(0.5f);

        // ○秒後に原点にアクティブを切る
        awakeUI.gameObject.SetActive(false);
    }
}
