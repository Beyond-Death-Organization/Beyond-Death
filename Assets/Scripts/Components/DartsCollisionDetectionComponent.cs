using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsCollisionDetectionComponent : MonoBehaviour
{
    public DartsTrapeComponent Component;

    private void OnTriggerEnter(Collider other) {
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;

        if (Component.CurrentCoroutine != null)
            StopCoroutine(Component.CurrentCoroutine);
        GameVariables.Instance.Timeline_PlayerKilled.Play();
    }
}