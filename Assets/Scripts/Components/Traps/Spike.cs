using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spike : TrapComponent
{
    public float SpikeDelay = 1;
    public GameObject DeadBody;

    private bool spikeEnabled = true;

    private double nextOutputTime;
    private double timer = 0;

    private void Start() {
        //nextOutputTime = Random.Range(3f, 7f);
        //AnimationTimeline.stopped += director => { spikeEnabled = false; };        //To reactivate after animation
        //GameVariables.Instance.Timeline_PlayerSpiked.stopped += director => { DeadBody.SetActive(true); };
    }

    private void Update() {
        if (spikeEnabled)
            return;

        timer += Time.deltaTime;

        if (timer >= nextOutputTime) {
            spikeEnabled = true;
            nextOutputTime += SpikeDelay;

            AnimationTimeline.Play();
        }
    }


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
    
    public override void ToggleDeadBody() {
        DeadBody.SetActive(true);
    }
}