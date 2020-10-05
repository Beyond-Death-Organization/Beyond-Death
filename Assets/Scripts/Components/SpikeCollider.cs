using System;
using Components;
using UnityEngine;
using UnityEngine.Events;

public class SpikeCollider : MonoBehaviour
{
    public SpikeComponent spike;
    public UnityEvent onTriggerEnter = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke();
        spike.SpawnDead(other);
        EventsPlayer.Instance.OnPlayerDeath();
        GetComponent<Collider>().isTrigger = false;
    }

}
