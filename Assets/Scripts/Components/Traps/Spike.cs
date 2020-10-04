using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spike : TrapComponent
{
    public float SpikeDelay = 1;

    private bool enabled;

    private double nextOutputTime;
    private double timer = 0;

    private void Start() {
        nextOutputTime = Random.Range(5f, 10f);
        AnimationTimeline.stopped += director => {
            enabled = false;
        };
    }

    private void Update() {
        if (enabled)
            return; 
        
        timer += Time.deltaTime;
        
        if (timer >= nextOutputTime) {
            enabled = true;
            nextOutputTime += SpikeDelay;

            AnimationTimeline.Play();
        }
    }
    

    private void OnTriggerStay(Collider other) {
        if (!enabled)
            return;
        
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;

        EventsPlayer.Instance.OnPlayerDeath();
    }
}
