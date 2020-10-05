using System;
using UnityEngine;

public class TotemComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;
        
        gameObject.SetActive(false);

        EventsPlayer.Instance.OnTotemPickup();
    }
}