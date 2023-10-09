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
        //初期スケールを取得しておく
        StartX = this.transform.localScale.x;
        StartY = this.transform.localScale.y;
        StartZ = this.transform.localScale.z;
    }
    //マウスカーソルが触れたかを検知する
    public void OnPointerEnter(PointerEventData eventData)
    {
        SelectButtonTextTarget = this.gameObject;

        ////※保存用
        //text.text = SelectButtonTextTarget.GetComponentInChildren<TextMeshProUGUI>().text;

        //テキストを探してくる
        //GameObject selectedText = this.transform.Find("Text").gameObject;
        // Textコンポーネントからtextデータを取得し、メインテキストに表示
        //Maintext.text = selectedText.GetComponent<TextMeshProUGUI>().text;


        GameObject a = this.GetComponent<Image>().gameObject;
        //a.GetComponent<Image>().color
        //    = new Color(0 / 255f, 64f / 255f, 147 / 255f);


        Debug.Log("マウスが触れてるゾ");
        GameObject b = this.gameObject;

        b.transform.DOScale(new Vector3(1.2f * StartX, 1.2f * StartY, 1.2f * StartZ), 0.3f);

        ////選択中のコマンド表示名を取得
        ////子どもの名前を探してくる（コマンド）
        //GameObject b = this.transform.Find("Panel").gameObject;
        ////選択中のコマンドのテキスト色を変更
        //b.GetComponent<TextMeshProUGUI>().color
        //    = new Color(0 / 255f, 64f / 255f, 147 / 255f);        
    }

    //マウスカーソルが離れたかを検知する
    public void OnPointerExit(PointerEventData eventData)
    {
        // Textコンポーネントからtextデータを取得し、メインテキストに表示
        //Maintext.text = "とっとと選びやがれ！なのです。";

        GameObject a = this.GetComponent<Image>().gameObject;
        //a.GetComponent<Image>().color
        //    = new Color(255 / 255f, 64f / 255f, 255 / 255f);


        GameObject b = this.gameObject;
        b.transform.DOScale(new Vector3(StartX, StartY, StartZ), 0.3f);

        ////選択中のコマンド名表示を取得
        ////子どもの名前を探してくる（コマンド）
        //GameObject b = this.transform.Find("Panel").gameObject;
        ////選択中のコマンドのテキスト色を変更
        //b.GetComponent<TextMeshProUGUI>().color
        //    = new Color(255 / 255f, 255f / 255f, 255f / 255f);
    }


    //クリックした際
    public void OnPointerDown(PointerEventData eventData)
    {
        fadeManager.OnFadeOutWaitKOMIKOMI(NextSceneName);
    }
}
