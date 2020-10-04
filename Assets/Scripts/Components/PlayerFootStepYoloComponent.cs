using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

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
        AudioManager.Instance.PlayClip("FootStep", audioSource);
    }

    public void OnFootStepLeft() {
        LeftFoot.Emit(15);
        AudioManager.Instance.PlayClip("FootStep", audioSource);
    }
}
