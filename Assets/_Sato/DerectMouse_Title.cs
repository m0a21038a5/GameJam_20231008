using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DerectMouse_Title : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private GameObject SelectButtonTextTarget;
    //[SerializeField] TextMeshProUGUI Maintext;

    float StartX;
    float StartY;
    float StartZ;

    [SerializeField] string NextSceneName;
    [SerializeField] FadeManager fadeManager;

    void Start()
    {
        //�����X�P�[�����擾���Ă���
        StartX = this.transform.localScale.x;
        StartY = this.transform.localScale.y;
        StartZ = this.transform.localScale.z;
    }
    //�}�E�X�J�[�\�����G�ꂽ�������m����
    public void OnPointerEnter(PointerEventData eventData)
    {
        SelectButtonTextTarget = this.gameObject;

        ////���ۑ��p
        //text.text = SelectButtonTextTarget.GetComponentInChildren<TextMeshProUGUI>().text;

        //�e�L�X�g��T���Ă���
        //GameObject selectedText = this.transform.Find("Text").gameObject;
        // Text�R���|�[�l���g����text�f�[�^���擾���A���C���e�L�X�g�ɕ\��
        //Maintext.text = selectedText.GetComponent<TextMeshProUGUI>().text;


        GameObject a = this.GetComponent<Image>().gameObject;
        //a.GetComponent<Image>().color
        //    = new Color(0 / 255f, 64f / 255f, 147 / 255f);


        Debug.Log("�}�E�X���G��Ă�]");
        GameObject b = this.gameObject;

        b.transform.DOScale(new Vector3(1.2f * StartX, 1.2f * StartY, 1.2f * StartZ), 0.3f);

        ////�I�𒆂̃R�}���h�\�������擾
        ////�q�ǂ��̖��O��T���Ă���i�R�}���h�j
        //GameObject b = this.transform.Find("Panel").gameObject;
        ////�I�𒆂̃R�}���h�̃e�L�X�g�F��ύX
        //b.GetComponent<TextMeshProUGUI>().color
        //    = new Color(0 / 255f, 64f / 255f, 147 / 255f);        
    }

    //�}�E�X�J�[�\�������ꂽ�������m����
    public void OnPointerExit(PointerEventData eventData)
    {
        // Text�R���|�[�l���g����text�f�[�^���擾���A���C���e�L�X�g�ɕ\��
        //Maintext.text = "�Ƃ��ƂƑI�т₪��I�Ȃ̂ł��B";

        GameObject a = this.GetComponent<Image>().gameObject;
        //a.GetComponent<Image>().color
        //    = new Color(255 / 255f, 64f / 255f, 255 / 255f);


        GameObject b = this.gameObject;
        b.transform.DOScale(new Vector3(StartX, StartY, StartZ), 0.3f);

        ////�I�𒆂̃R�}���h���\�����擾
        ////�q�ǂ��̖��O��T���Ă���i�R�}���h�j
        //GameObject b = this.transform.Find("Panel").gameObject;
        ////�I�𒆂̃R�}���h�̃e�L�X�g�F��ύX
        //b.GetComponent<TextMeshProUGUI>().color
        //    = new Color(255 / 255f, 255f / 255f, 255f / 255f);
    }


    //�N���b�N������
    public void OnPointerDown(PointerEventData eventData)
    {
        fadeManager.OnFadeOutWaitKOMIKOMI(NextSceneName);
    }
}
