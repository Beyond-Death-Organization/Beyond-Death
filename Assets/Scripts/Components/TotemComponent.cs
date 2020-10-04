using System;
using UnityEngine;

public class TotemComponent : TrapComponent
{
    private void OnTriggerEnter(Collider other) {
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;

        //Start timeline
        PlayAnimation();
    }
}