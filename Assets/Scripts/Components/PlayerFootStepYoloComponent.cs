using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStepYoloComponent : MonoBehaviour
{
    public ParticleSystem Rightfoot, LeftFoot;
    
    public void OnFootStepRight() {
        Rightfoot.Emit(15);
    }

    public void OnFootStepLeft() {
        LeftFoot.Emit(15);
    }
}
