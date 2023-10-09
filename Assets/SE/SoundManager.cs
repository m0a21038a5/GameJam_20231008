using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip audioClip;
    }

    [SerializeField]
    private SoundData[] soundDatas;

    private AudioSource[] audioSourceList = new AudioSource[30];

    // �ʖ����L�[�Ƃ����Ǘ��pDictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    private void Awake()
    {
        //auidioSourceList�z��̐�����AudioSource���������g�ɐ������Ĕz��Ɋi�[
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        //soundDictionary�ɃZ�b�g
        foreach (var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    //���g�p��AudioSource�̎擾 �S�Ďg�p���̏ꍇ��null��ԋp
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].isPlaying == false) return audioSourceList[i];
        }

        return null; //���g�p��AudioSource�͌�����܂���ł���
    }


    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���Đ�
    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            Play(soundData.audioClip); //����������A�Đ�
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    //�w�肳�ꂽAudioClip�𖢎g�p��AudioSource�ōĐ�
    public void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return;
        audioSource.clip = clip;
        audioSource.Play();
    }
}