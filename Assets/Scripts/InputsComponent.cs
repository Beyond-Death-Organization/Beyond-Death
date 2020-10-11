using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

[Serializable]
public class InputsComponent
{
    public short RewiredPlayerId;

    public Rewired.Player Player;

    public void Initialize() {
        Player = ReInput.players.GetPlayer(RewiredPlayerId);
    }
}
