using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerFootStepYoloComponent : MonoBehaviour
{
    public ParticleSystem Rightfoot, LeftFoot;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnFootStepRight() {
        Rightfoot.Emit(15);
        int tmp = Random.Range(0, 2);
        switch (tmp)
        {
            case 0:
                AudioManager.Instance.PlayClip("FootStep1", audioSource);
                break;
            case 1:
                AudioManager.Instance.PlayClip("FootStep2", audioSource);
                break;
            case 2:
                AudioManager.Instance.PlayClip("FootStep3", audioSource);
                break;
            
        }
        AudioManager.Instance.PlayClip("FootStep", audioSource);
    }

    public void OnFootStepLeft() {
        LeftFoot.Emit(15);
        int tmp = Random.Range(0, 2);
        switch (tmp)
        {
            case 0:
                AudioManager.Instance.PlayClip("FootStep1", audioSource);
                break;
            case 1:
                AudioManager.Instance.PlayClip("FootStep2", audioSource);
                break;
            case 2:
                AudioManager.Instance.PlayClip("FootStep3", audioSource);
                break;
        }
        AudioManager.Instance.PlayClip("FootStep", audioSource);
    }
}
