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
        //フェードイン
        //オブジェクト下の画像を動かしながら、透明度を下げるゾ
        //子オブジェクトを取得して、バラバラに表示させる処理
        for (int i = 0; i < fadeCanvas.transform.childCount; i++)
        {
            //横からニュルっと
            Transform child = fadeCanvas.transform.GetChild(i);
            ((RectTransform)child).DOMoveX(-1920, 0.5f)
                .SetEase(Ease.InOutQuart)
                .SetDelay(0.1f)
                .SetDelay(0.1f * i);

            

            //透明度　DoFade
            Image childImage = child.GetComponent<Image>();


            ////透明度を上げる
            //childImage.color = new Color(0f, 0f, 0f, 255f);

            //透明度を下げていく。
            childImage.DOFade(endValue: 0f, duration: 0.8f)
                .SetDelay(0.05f)
                .SetDelay(0.03f * i);
        }
    }

    public void OnFadeOut()
    {
        //フェードアウト
        //オブジェクト下の画像を動かしながら、透明度を上げるゾ
        //子オブジェクトを取得して、バラバラに表示させる処理
        for (int i = 0; i < fadeCanvas.transform.childCount; i++)
        {
            //横からニュルっと
            Transform child = fadeCanvas.transform.GetChild(i);
            ((RectTransform)child).DOMoveX(960, 0.5f)
                .SetDelay(0.1f)
                .SetDelay(0.1f * i);

            //透明度　DoFade
            Image childImage = child.GetComponent<Image>();
            childImage.DOFade(endValue: 255f, duration: 5.0f)
                .SetEase(Ease.InOutQuart)
                .SetDelay(0.05f)
                .SetDelay(0.03f * i);
        }
    }

    //コルーチンこみこみのフェード処理
    public void OnFadeOutWaitKOMIKOMI(string GoToSceneName)
    {
        StartCoroutine(WaitProcess(GoToSceneName));
    }

    IEnumerator WaitProcess(string GoToSceneName)
    {
        // 別のコルーチンの終了を待ちます。　フェードアウトが終わってから、
        //　　→　別のコルーチンで、フェードアウト処理を呼び出してくる。
        yield return StartCoroutine(AnotherProcess());

        //【テスト用】秒数で待つ
        // 指定した秒数だけ処理を待ちます。
        yield return new WaitForSeconds(2.0f);

        //シーンチェンジ
        SceneManager.LoadScene(GoToSceneName);
    }
    //別のコルーチン
    IEnumerator AnotherProcess()
    {
        //フェード処理を実行
        OnFadeOut();

        yield return null;
    }
}
