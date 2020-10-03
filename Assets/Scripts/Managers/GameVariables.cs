﻿using UnityEngine;
using UnityEngine.Playables;

public class GameVariables : MonoBehaviour
{
#region Singleton

    public static GameVariables Instance = null;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            //GameObject.DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

#endregion

    public float Timeline_PlayerRespawnTime;
    public PlayableDirector Timeline_BridgeFalling;
}
