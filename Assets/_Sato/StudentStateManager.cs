using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class StudentStateManager : MonoBehaviour
{
    //���k�̏��
    public enum StudentState
    {
        Null = -1,
        nomal,
        sleep,
        nomal_slept //���X�g�I�[�o�[����@�����Q�邱�Ƃ�������ԁB
    }

    public StudentState currentState;


    //���Ԍo�߂�State�𖰂�ɂ���B

    //Sleep�܂ł̎���
    [SerializeField] public List<float> sleepTimeList = new List<float>() { };
    [SerializeField] public List<float> awakeTimeList = new List<float>() { };
    [SerializeField] int MaxSleepTime; //���񖰂邩
    [SerializeField] int currentSleepTime; //���݁A����ڂ̖��肩�B
    [SerializeField] int currentAwakeTime;

    [SerializeField] Image sleepingUI;
    [SerializeField] Image awakeUI;
    private int m_awakeTime;
    private int m_SirentSlept;

    //�^�C�}�[
    private float startTimer;
    private float currentTimer;

    ////�p�[�e�B�N��
    //[SerializeField] GameObject particl_ZZZ;
    //[SerializeField] GameObject particl_WakeUp;

    //private GameObject Unchi;
    //private GameObject Unchi_Mark2;

    //�f�o�b�N�p�@�o�ߕb���\��
    //[SerializeField] TextMeshProUGUI timeText;

    //�A�j���[�V�����J��
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

        //�т�����UI
        awakeUI.rectTransform.DOLocalMove(new Vector3(10f, 8f, 0f), 0.3f)
                                           .SetLoops(-1, LoopType.Restart)
                                           .SetRelative();
        //awakeUI.DOFade(0.0f, 0.9f)
        //          .SetLoops(-1, LoopType.Restart);
    }

    void Update()
    {
        ////�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[����m�F�f�o�b�N�p�@��ŏ����B�[�[�[�[�[�[�[�[�[�[�[�[
        //if (Input.GetMouseButtonDown(0))
        //{
        //    OnAwake(currentSleepTime);
        //}
        ////�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[����m�F�f�o�b�O�p�[�[�[�[�[�[�[�[�[�[�[�[�[
        //timeText.text = currentTimer.ToString();
        ////---------------------------------------------------------------------------


        currentTimer = Time.time - startTimer;


        //if(sleepTimeList.Count > currentSleepTime)
        //{
        //    StateChange(currentState = StudentState.nomal_slept);
        //}
        //�m�[�}�����
        if (currentState == StudentState.nomal)
        {


            if (sleepTimeList.Count > currentSleepTime)
            {
                //�w�肵�����Ԃ��o��
                if (currentTimer >= sleepTimeList[currentSleepTime])
                {
                    //�X�e�C�g�ύX
                    currentState = StudentState.sleep;

                    if (sleepTimeList.Count > currentSleepTime)
                    {
                        //�˂ނ����񐔂����Z�B
                        currentSleepTime++;
                    }

                    //���ɋN���Ă���ꍇ�́A�����I�ɋN�������X�g�����s�ցB
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
        //�����Ă��鎞
        if(currentState == StudentState.sleep)
        {
            if (awakeTimeList.Count > m_awakeTime)
            {
                Debug.Log("����N������" + currentAwakeTime);


                //�����I�ɋN�����B
                if (currentTimer >= awakeTimeList[currentAwakeTime])
                {
                    Debug.Log("����N������" + currentAwakeTime);

                    //
                    currentState = StudentState.nomal;
                    OnAwake();


                    if (awakeTimeList.Count > m_awakeTime)
                    {
                        //�N�����񐔂����Z�B
                        currentAwakeTime++;
                    }

                }
                //��x�����Ăяo�� Dotween
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



    //�N�����ꂽ���̏����@�����F�N������
    public void OnAwake()  //OnAwake(studentStateManager(���C���X�^���X��).currentSleepTime)�@�ŌĂяo���Ă�������
    {
        m_awakeTime++;
        //�����ɁA�N�����ꂽ�u�Ԃ̃��X�|���X
        sleepingUI.gameObject.SetActive(false);
        awakeUI.gameObject.SetActive(true);
        //���o�ߌ�AFalse�ɂ���B
        StartCoroutine(DelayOnAwake());
        Debug.Log("�N�����ꂽ");


        animator.SetBool("wakeUp", true);
        animator.SetBool("sleep", false);

        ////�N�������ɕ��u���Ă������̗�O����
        //if(m_awakeTime < currentSleepTime)
        //{
        //    m_awakeTime = currentSleepTime;


        //}

        //����ő�񐔂𒴂��Ă�����
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

    //�e�X�e�C�g���̏���
    private void StateChange(StudentState studentState01)
    {
        //�ʏ펞
        if(studentState01 == StudentState.nomal || studentState01 == StudentState.nomal_slept)
        {
            ////ZZZ�������B
            //Destroy(Unchi);


            sleepingUI.gameObject.SetActive(false);
            //awakeUI.gameObject.SetActive(false);

            //�A�j���[�V����
            //animator.SetBool("sleep", false);

            //------�������@�f�o�b�O�p
            //gameObject.GetComponent<Renderer>().material.color = Color.red;
            //------------
        }

        //������Ԓ�
        else if (studentState01 == StudentState.sleep)
        {
            sleepingUI.gameObject.SetActive(true);
            awakeUI.gameObject.SetActive(false);


            //sleepingUI.text = "Z";

            //�A�j���[�V�����@�F�@�X���[�v���Đ�
            animator.SetBool("sleep", true);
            animator.SetBool("wakeUp", false);

            //�[�[�[�[�[�[�[�[�[�[�[�[�[�������@�f�o�b�O�p�[�[�[�[�[�[�[�[�[�[�[�[
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


    // �R���[�`���{��
    private IEnumerator DelayOnAwake()
    { 
        // ���b�ԑ҂�
        yield return new WaitForSeconds(0.5f);

        // ���b��Ɍ��_�ɃA�N�e�B�u��؂�
        awakeUI.gameObject.SetActive(false);
    }
}
