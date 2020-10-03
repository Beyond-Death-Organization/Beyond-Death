using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    public UnityEvent onTriggerEnter = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke();
        PlayerManager.Instance.Killplayer();
        GetComponent<Collider>().isTrigger = false;
    }

}
