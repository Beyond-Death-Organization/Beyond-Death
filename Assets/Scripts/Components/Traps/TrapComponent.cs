using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TrapComponent : MonoBehaviour
{
    public float AnimationSpeed = 1;
    public PlayableDirector AnimationTimeline;

    public void PlayAnimation() {
        AnimationTimeline.Play();
        AnimationTimeline.playableGraph.GetRootPlayable(0).SetSpeed(AnimationSpeed);
    }
}
