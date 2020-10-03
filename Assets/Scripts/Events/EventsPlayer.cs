﻿using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

public class EventsPlayer : MonoBehaviour
{
#region Singleton

    public static EventsPlayer Instance = null;

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

    [HideInInspector] public UnityEvent OnToggleDeadBodies;

    /// <summary>
    /// Play end of timeline of bridge falling
    /// Enable player inputs at the end of timeline
    /// </summary>
    public void OnPlayerRespawn() {
        GameVariables.Instance.Timeline_PlayerJumpOffTombeau.Play();
    }

    public void OnPlayerDeath() {
        SetInputs(false);
        //Start RagDole
        //Increment death number UI
        //Call OnPlayerRespawn in X seconds (TimeManager)
    }

    public void SetInputs(bool enable) {
        ReInput.players.GetPlayer("Player01").controllers.Keyboard.enabled = enable;
        ReInput.players.GetPlayer("Player01").controllers.Mouse.enabled = enable;
        foreach (Joystick joystick in ReInput.players.GetPlayer("Player01").controllers.Joysticks) {
            joystick.enabled = enable;
        }
    }

    /// <summary>
    /// Called on level start
    /// </summary>
    public void ToggleDeadBodies() {
        OnToggleDeadBodies?.Invoke();
    }

    public void ActivatePlayer(bool enabled) {
        GameVariables.Instance.Player.gameObject.SetActive(enabled);
    }
}
