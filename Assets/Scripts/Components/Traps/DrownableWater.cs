using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class DrownableWater : MonoBehaviour
{
    public bool enabled = true;
    public GameObject DeadBody;
    public AudioSource audioSource;

    private void start()
    {
        
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
        AudioManager.Instance.PlayClip("Drown", audioSource);
        //EventsPlayer.Instance.OnToggleDeadBodies.RemoveListener((() => { DeadBody.SetActive(true); }));
    }
}