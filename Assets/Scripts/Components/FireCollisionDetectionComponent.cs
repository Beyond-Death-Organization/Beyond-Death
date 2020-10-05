using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollisionDetectionComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;
        
        GameVariables.Instance.Timeline_PlayerKilled.Play();
    }
}
