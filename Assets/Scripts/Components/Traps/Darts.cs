using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Darts : TrapComponent
{
    public float ShootDelay = 2;
    public GameObject DeadBody;
    
    private bool dartEnabled = true;

    private double nextOutputTime;
    private double timer = 0;

    private void Start() {
        nextOutputTime = Random.Range(3f, 6f);
        AnimationTimeline.stopped += director => { dartEnabled = false; };
        //GameVariables.Instance.Timeline_PlayerDarted.stopped += director => { DeadBody.SetActive(true); };
    }

    private void Update() {
        if (dartEnabled)
            return; 

        timer += Time.deltaTime;
        
        if (timer >= nextOutputTime) {
            dartEnabled = true;
            nextOutputTime += ShootDelay;

            //AnimationTimeline.Play();
            PlayAnimation();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;

        //GameVariables.Instance.LastTrapActivatedByPlayer = this;
        GameVariables.Instance.Timeline_PlayerDarted.Play();
    }
}