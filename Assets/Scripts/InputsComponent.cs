using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

[Serializable]
public class InputsComponent : MonoBehaviour
{
    public short RewiredPlayerId;

    public Rewired.Player Player;

    public bool IsMovementEnabled = true;

    public void Awake() {
        Player = ReInput.players.GetPlayer(RewiredPlayerId);
    }

    /// <summary>
    /// Disable inputs completely
    /// </summary>
    /// <param name="enable"></param>
    public void ActivateInputs(bool enable) {
        Player.controllers.Keyboard.enabled = enable;
        Player.controllers.Mouse.enabled = enable;
        foreach (Joystick joystick in Player.controllers.Joysticks) {
            joystick.enabled = enable;
        }
    }
}
