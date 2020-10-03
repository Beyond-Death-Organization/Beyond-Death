using Rewired;
using UnityEngine;

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

    /// <summary>
    /// Play end of timeline of bridge falling
    /// Enable player inputs at the end of timeline
    /// </summary>
    public void OnPlayerRespawn() {
        GameVariables.Instance.Timeline_BridgeFalling.time = GameVariables.Instance.Timeline_PlayerRespawnTime;
        GameVariables.Instance.Timeline_BridgeFalling.Play();
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
}
