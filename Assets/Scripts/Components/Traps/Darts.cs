using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Darts : TrapComponent
{
    public float ShootDelay = 2;

    private bool dartEnabled;

    private double nextOutputTime;
    private double timer = 0;
    
    private void Start() {
        nextOutputTime = Random.Range(3f, 6f);
        AnimationTimeline.stopped += director => {
            dartEnabled = false;
        };
    }
    
    private void Update() {
        if (dartEnabled)
            return; 

        timer += Time.deltaTime;
        
        if (timer >= nextOutputTime) {
            dartEnabled = true;
            nextOutputTime += ShootDelay;

            AnimationTimeline.Play();
        }
    }

    private void OnTriggerStay(Collider other) {
#if UNITY_EDITOR
        Debug.Log("nonono");
#endif
    }

    private void OnTriggerEnter(Collider other) {

#if UNITY_EDITOR
        Debug.Log("wtfff");
#endif
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;
        
        EventsPlayer.Instance.OnPlayerDeath();
    }
}
