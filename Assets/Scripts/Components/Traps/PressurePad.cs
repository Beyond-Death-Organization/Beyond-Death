using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PressurePad : TrapComponent
{
    public PlayableDirector ReverseAnimation;
    public bool isPlayerTriggable;

    private bool hasAnimationFinished = true;
    private int objectOnPadId = -1;

    private void Start() {
        ReverseAnimation.stopped += director => { hasAnimationFinished = true; };
        AnimationTimeline.stopped += director => { hasAnimationFinished = true; };
    }

    private void OnTriggerEnter(Collider other) {
        if (!isPlayerTriggable)
            if (other.TryGetComponent(out PlayerMovementComponent player))
                return;
        if (objectOnPadId != -1)
            return;
        
        objectOnPadId = other.gameObject.GetInstanceID();

        ReverseAnimation.Stop();
        //Start animation from reverse animation time
        if (!hasAnimationFinished) {
            //AnimationTimeline.time = ReverseAnimation.playableAsset.duration - ReverseAnimation.time;
        }

        hasAnimationFinished = false;
        PlayAnimation();
    }

    private void OnTriggerExit(Collider other) {
        if (!isPlayerTriggable)
            if (other.TryGetComponent(out PlayerMovementComponent player))
                return;
        if (other.gameObject.GetInstanceID() != objectOnPadId)
            return;

        objectOnPadId = -1;

        AnimationTimeline.Stop();
        //Start reverse animation from basic animation time
        if (!hasAnimationFinished) {
            //ReverseAnimation.time = AnimationTimeline.playableAsset.duration - AnimationTimeline.time;
        }

        hasAnimationFinished = false;
        ReverseAnimation.Play();
        ReverseAnimation.playableGraph.GetRootPlayable(0).SetSpeed(AnimationSpeed);
    }
}