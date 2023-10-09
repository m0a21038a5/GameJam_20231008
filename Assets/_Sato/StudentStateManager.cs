using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

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

    [SerializeField] TextMeshProUGUI sleepingUI;
    private int m_awakeTime;
    private int m_SirentSlept;

    //�^�C�}�[
    private float startTimer;
    private float currentTimer;


    //�f�o�b�N�p�@�o�ߕb���\��
    [SerializeField] TextMeshProUGUI timeText;

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

        currentState = StudentState.nomal;
        StateChange(currentState);

        pos = sleepingUI.transform.position;

        animator = GetComponent<Animator>();

        startTimer = Time.time;
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
            //�Q�Ă��狭���I�ɋN�����B
            if (currentTimer >= awakeTimeList[currentAwakeTime])
            {
                //
                currentState = StudentState.nomal;
                OnAwake(currentSleepTime);

                //�N�����ꂽ�񐔂����Z
                currentAwakeTime++;
            }
                //��x�����Ăяo�� Dotween
                if (!onece)
                {
                    DoMoveText();
                    onece = true;
                }

                StateChange(currentState);
        }
        ////
        //else if(currentState == StudentState.nomal_slept)
        //{
        //    //�Q�Ă��狭���I�ɋN�����B
        //    if (Time.time >= awakeTimeList[currentAwakeTime])
        //    {
        //        //
        //        currentState = StudentState.nomal;
        //        OnAwake(currentSleepTime);

        //        //�N�����ꂽ�񐔂����Z
        //        currentAwakeTime++;
        //    }
        //}
    }



    //�N�����ꂽ���̏����@�����F�N������
    public void OnAwake(int AwakeTime)  //OnAwake(studentStateManager(���C���X�^���X��).currentSleepTime)�@�ŌĂяo���Ă�������
    {
        m_awakeTime++;
        //�����ɁA�N�����ꂽ�u�Ԃ̃��X�|���X
        sleepingUI.gameObject.SetActive(false);

        animator.SetBool("wakeUp", true);
        animator.SetBool("sleep", false);

        //SE�Đ���


        ////�N�������ɕ��u���Ă������̗�O����
        //if(m_awakeTime < currentSleepTime)
        //{
        //    m_awakeTime = currentSleepTime;

            
        //}

        //����ő�񐔂𒴂��Ă�����
        if (AwakeTime > MaxSleepTime)
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
            sleepingUI.gameObject.SetActive(false);

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
            sleepingUI.text = "Z";

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
        var tween = sleepingUI.rectTransform.DOLocalMove(new Vector3(10f, 8f, 0f), 0.9f)
                                           .SetLoops(-1, LoopType.Restart)
                                           .SetRelative();

        sleepingUI.DOFade(0.0f, 0.9f)
            .SetLoops(-1, LoopType.Restart);
            //.SetRelative();
    }
}
