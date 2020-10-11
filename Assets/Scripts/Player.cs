using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerMovements
{
    public InputsComponent inputs;
    
    protected override void Awake() {
        base.Awake();
        inputs.Initialize();
        playerRef = inputs.Player;
    }

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
    }

    protected override void FixedUpdate() {
        base.FixedUpdate();
    }
}
