using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : PressurePlateComponent
{
    public ParticleSystem Fire;
    public Collider Hitbox;

    public override void Awake() {
        OnActivation += () => {
            Fire.Play();
            Hitbox.enabled = true;
        };
        OnDeactivation += () => {
            Fire.Stop();
            Hitbox.enabled = false;
        };
    }
}
