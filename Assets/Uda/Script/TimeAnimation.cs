using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAnimation : MonoBehaviour
{
    private Animator m_Animator;
    [SerializeField] Countdown cd;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cd.MaxCount <= 11f && cd.MaxCount > 0f)
        {
            m_Animator.enabled = true;
            m_Animator.SetBool("isCloseToFinish", true);
        }
        if (cd.MaxCount <= 0)
        {
            m_Animator.enabled = false;
        }
    }
}
