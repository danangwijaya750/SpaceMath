using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    void Start()
    {
        audioSource.clip = getStageClip();
        audioSource.Play();
    }
    AudioClip getStageClip(){
        return audioClips[GamePlayConfig.stage -1];
    }
}
