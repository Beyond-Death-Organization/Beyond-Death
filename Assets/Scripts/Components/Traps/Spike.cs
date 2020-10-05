using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spike : TrapComponent
{
    public float SpikeDelay = 1;

    private bool spikeEnabled;

    private double nextOutputTime;
    private double timer = 0;

    private void Start() {
        //nextOutputTime = Random.Range(3f, 7f);
        //AnimationTimeline.stopped += director => { spikeEnabled = false; };        //To reactivate after animation
    }

    /*private void Update() {
        if (spikeEnabled)
            return;

        timer += Time.deltaTime;

        if (timer >= nextOutputTime) {
            spikeEnabled = true;
            nextOutputTime += SpikeDelay;

            AnimationTimeline.Play();
        }
    }*/


    private void OnTriggerEnter(Collider other) {
        if (!spikeEnabled)
            return;

        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;
        
        spikeEnabled = false;

        GameVariables.Instance.LastTrapActivatedByPlayer = this;
        GameVariables.Instance.Timeline_PlayerSpiked.Play();
    }
}