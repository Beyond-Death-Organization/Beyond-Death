using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;
        
        EventsGame.Instance.EndGame();
    }
}
