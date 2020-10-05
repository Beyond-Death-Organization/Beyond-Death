using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsTrapeComponent : PressurePlateComponent
{
    [Tooltip("Time before being able to shoot again")]
    public float Delay = 5;
    [Tooltip("Time before darts reset")]
    public float ResetDelay = 2;
    public float Speed = 1;
    public AnimationCurve DistanceOverTime;
    public GameObject Darts;

    private float timerBeforeShoot;
    private bool isReadyToShoot => timerBeforeShoot <= 0;
    private bool isReadyToReset => timerBeforeShoot <= Delay - ResetDelay;
    private bool hasBeenReset = true;
    private Vector3 dartsInitialPosition;

    public Coroutine CurrentCoroutine;

    private void Awake() {
        dartsInitialPosition = Darts.transform.localPosition;
    }

    private void Update() {
        if (!isReadyToShoot)
            timerBeforeShoot -= Time.deltaTime;

        if (!hasBeenReset && isReadyToReset)
            ResetDarts();
    }

    protected override void OnActivation() {
        base.OnActivation();
        if (!isReadyToShoot)
            return;

        StartCoroutine(Shoot());
    }

    private void ResetDarts() {
        hasBeenReset = true;
        Darts.transform.localPosition = dartsInitialPosition;
    }

    private IEnumerator Shoot() {
        timerBeforeShoot = Delay;
        hasBeenReset = false;

        float timer = 0;
        Transform dartsTransform = Darts.transform;

        while (timer < 1) {
            timer += Time.deltaTime;

            float y = DistanceOverTime.Evaluate(timer) * Speed * Time.deltaTime;
            dartsTransform.localPosition = new Vector3(dartsInitialPosition.x, dartsTransform.localPosition.y + y,
                dartsInitialPosition.z);

            yield return null;
        }
    }
}