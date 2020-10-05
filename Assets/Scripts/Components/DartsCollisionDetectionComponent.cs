using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsCollisionDetectionComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;

        GameVariables.Instance.LastTrapActivatedByPlayer = null;
        GameVariables.Instance.Timeline_PlayerDarted.Play();
    }
}
