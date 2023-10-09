using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public List<AudioClip> SEList;
    AudioSource audioSource;
    // Start is called before the first frame update
    int hitCount;
    private void Start()
    {
        hitCount = 0;
        audioSource = GetComponent<AudioSource>();
    }
    public void Hit()
    {
        audioSource.PlayOneShot(SEList[0]);
    }

    public void HitStudent()
    {
        hitCount++;
        audioSource.PlayOneShot(SEList[hitCount]);
        if(hitCount > 2)
        {
            hitCount = 1;
        }
    }

    public void ResultSE()
    {
        audioSource.PlayOneShot(SEList[0]);
    }

    public void SelectSE()
    {
        audioSource.PlayOneShot(SEList[1]);
    }

    public void KetteiSE()
    {
        audioSource.PlayOneShot(SEList[2]);
    }
}
