using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownableWater : MonoBehaviour
{
    public bool enabled = true;
    public GameObject DeadBody;

    private void Awake() {
    }

    private void OnTriggerEnter(Collider other) {
        if (!enabled)
            return;
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;

        enabled = false;
        GameVariables.Instance.Timeline_PlayerDrown.Play();
        EventsPlayer.Instance.OnToggleDeadBodies.AddListener((() => { DeadBody.SetActive(true); }));
        //EventsPlayer.Instance.OnToggleDeadBodies.RemoveListener((() => { DeadBody.SetActive(true); }));
    }
}