using UnityEngine;

public class TotemComponent : TrapComponent
{
    public float LerpTimeToBag;

    private void Start() {
        AnimationTimeline.stopped += director => {
            LeanTween.move(gameObject, GameVariables.Instance.Player.transform, LerpTimeToBag);
        };
    }

    private void OnTriggerEnter(Collider other) {
        //Make sure its player
        if (!other.TryGetComponent(out PlayerMovementComponent player))
            return;

        //Start timeline
        PlayAnimation();
    }
}