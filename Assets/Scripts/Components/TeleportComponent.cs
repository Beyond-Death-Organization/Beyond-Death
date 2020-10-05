using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{
    public TeleportComponent MyGoodFriend;
    [Tooltip("When player teleports on me, where should I place him")]
    public Transform MyTeleportPosition;
    
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out PlayerMovementComponent player)) {
            GameVariables.Instance.LastTeleportUsed = this;   
            GameVariables.Instance.Timeline_PlayerTeleport.Play();
        }
        else
            Teleport(other.gameObject);
    }

    public void Teleport(GameObject obj) {
        MyGoodFriend.OnPlayerTpOnMe(obj);
    }

    private void OnPlayerTpOnMe(GameObject obj) {
        obj.transform.position = MyTeleportPosition.position;
        obj.transform.rotation = MyTeleportPosition.rotation;
    }
}
