using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : TrapComponent
{
    public float SpikeDelay;

    private bool enabled;

    private double lastOutputTime;
    private float timer = 0;

    private void Start() {
        AnimationTimeline.stopped += director => {
            enabled = false;
            lastOutputTime = Time.time;
        };
    }

    private void Update() {
        timer += Time.deltaTime;
        
        if (lastOutputTime + timer >= SpikeDelay) {
            enabled = true;
            timer = 0;

            AnimationTimeline.Play();
        }
    }

    private void OnCollisionStay(Collision other) {
        if (!enabled)
            return;
        
        //Make sure its player
        if (!other.gameObject.TryGetComponent(out PlayerMovementComponent player))
            return;

#if UNITY_EDITOR
        Debug.Log("Killed played");
#endif
    }
}
