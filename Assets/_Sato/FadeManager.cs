using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeManager : MonoBehaviour
{
    [SerializeField] Canvas fadeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //�t�F�[�h�C��
        //�I�u�W�F�N�g���̉摜�𓮂����Ȃ���A�����x��������]
        //�q�I�u�W�F�N�g���擾���āA�o���o���ɕ\�������鏈��
        for (int i = 0; i < fadeCanvas.transform.childCount; i++)
        {
            //������j��������
            Transform child = fadeCanvas.transform.GetChild(i);
            ((RectTransform)child).DOMoveX(-1920, 0.5f)
                .SetEase(Ease.InOutQuart)
                .SetDelay(0.1f)
                .SetDelay(0.1f * i);

            

            //�����x�@DoFade
            Image childImage = child.GetComponent<Image>();


            ////�����x���グ��
            //childImage.color = new Color(0f, 0f, 0f, 255f);

            //�����x�������Ă����B
            childImage.DOFade(endValue: 0f, duration: 0.8f)
                .SetDelay(0.05f)
                .SetDelay(0.03f * i);
        }
    }

    public void OnFadeOut()
    {
        //�t�F�[�h�A�E�g
        //�I�u�W�F�N�g���̉摜�𓮂����Ȃ���A�����x���グ��]
        //�q�I�u�W�F�N�g���擾���āA�o���o���ɕ\�������鏈��
        for (int i = 0; i < fadeCanvas.transform.childCount; i++)
        {
            //������j��������
            Transform child = fadeCanvas.transform.GetChild(i);
            ((RectTransform)child).DOMoveX(960, 0.5f)
                .SetDelay(0.1f)
                .SetDelay(0.1f * i);

            //�����x�@DoFade
            Image childImage = child.GetComponent<Image>();
            childImage.DOFade(endValue: 255f, duration: 5.0f)
                .SetEase(Ease.InOutQuart)
                .SetDelay(0.05f)
                .SetDelay(0.03f * i);
        }
    }

    //�R���[�`�����݂��݂̃t�F�[�h����
    public void OnFadeOutWaitKOMIKOMI(string GoToSceneName)
    {
        StartCoroutine(WaitProcess(GoToSceneName));
    }

    IEnumerator WaitProcess(string GoToSceneName)
    {
        // �ʂ̃R���[�`���̏I����҂��܂��B�@�t�F�[�h�A�E�g���I����Ă���A
        //�@�@���@�ʂ̃R���[�`���ŁA�t�F�[�h�A�E�g�������Ăяo���Ă���B
        yield return StartCoroutine(AnotherProcess());

        //�y�e�X�g�p�z�b���ő҂�
        // �w�肵���b������������҂��܂��B
        yield return new WaitForSeconds(2.0f);

        //�V�[���`�F���W
        SceneManager.LoadScene(GoToSceneName);
    }
    //�ʂ̃R���[�`��
    IEnumerator AnotherProcess()
    {
        //�t�F�[�h���������s
        OnFadeOut();

        yield return null;
    }
}
