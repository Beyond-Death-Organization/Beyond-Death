using System;
using System.Collections.Generic;
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

    //Player info (hardcode but fk it)
    private Vector3 playerSpawnPosition;
    private Quaternion playerSpawnRotation;
    private CharacterController playerCC;

    private int amountTotemPicked = 0;

    private void Start() {
        playerCC = GameVariables.Instance.Player.GetComponent<CharacterController>();
        playerSpawnPosition = GameVariables.Instance.Player.transform.position;
        playerSpawnRotation = GameVariables.Instance.Player.transform.rotation;
        GameManager.Instance.OnNextLevel.AddListener(i => { ToggleDeadBodies(); });
        GameVariables.Instance.Timeline_PlayerPickupTotem.stopped += director => { EventsGame.Instance.PlayDoorTotemTimeline(amountTotemPicked); };
    }


    /// <summary>
    /// Play end of timeline of bridge falling
    /// Enable player inputs at the end of timeline
    /// </summary>
    public void OnPlayerRespawn() {
        GameVariables.Instance.Timeline_PlayerJumpOffTombeau.Play();
    }

    public void OnPlayerDeath() {
        SetInputs(false);
        GameManager.Instance.NextLevel();
        //Increment death number UI
        //Call OnPlayerRespawn in X seconds (TimeManager)
    }

    public void SetInputs(bool enable) {
        playerCC.enabled = enable;
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

    public void ReturnToSpawn() {
        GameVariables.Instance.Player.transform.position = playerSpawnPosition;
        GameVariables.Instance.Player.transform.rotation = playerSpawnRotation;
    }

    public void OnTeleport() {
        GameVariables.Instance.LastTeleportUsed.Teleport(GameVariables.Instance.Player.gameObject);
    }

    public void ActivatePlayer(bool enabled) {
        GameVariables.Instance.Player.gameObject.SetActive(enabled);
    }

    public void ActivatePlayerAnimator(bool enabled) {
        GameVariables.Instance.PlayerAnimtor.enabled = enabled;
    }

    public void OnTotemPickup() {
        amountTotemPicked++;
        GameVariables.Instance.Timeline_PlayerPickupTotem.Play();
    }

    public void OnPlayerEnteredGate() {
        //TODO TIMELINE PLAYER EXIT LEVEL
        //TODO DISPLAY THX FOR PLAYING
    }
}