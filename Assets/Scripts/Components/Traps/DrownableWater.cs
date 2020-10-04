using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownableWater : TrapComponent
{
    public bool enabled = true;
    public Camera Camera;
    public GameObject AnimatedBody, DeadBody;

    private void Awake() {
        AnimationTimeline.stopped += director => { Camera.gameObject.SetActive(false); };
        AnimationTimeline.stopped += director => { AnimatedBody.SetActive(false); };
    }

    private void OnTriggerEnter(Collider other) {
        if (!enabled)
            return;
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;

        enabled = false;
        Camera.gameObject.SetActive(true);
        AnimatedBody.SetActive(true);
        PlayAnimation();
        EventsPlayer.Instance.OnToggleDeadBodies.AddListener((() => { DeadBody.SetActive(true); }));
        //EventsPlayer.Instance.OnToggleDeadBodies.RemoveListener((() => { DeadBody.SetActive(true); }));
    }
}