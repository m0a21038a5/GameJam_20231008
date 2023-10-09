using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] FadeManager fd;
    
    public void OnClickRetry()
    {
        fd.OnFadeOutWaitKOMIKOMI("MainScene");
    }

    public void OnClickToTitle()
    {
        fd.OnFadeOutWaitKOMIKOMI("TitleScene");
    }
}
