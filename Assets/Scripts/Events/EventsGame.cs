using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsGame : MonoBehaviour
{
#region Singleton

    public static EventsGame Instance = null;

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


    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }

    public void EnableMainCamera(bool enabled) {
        mainCamera.gameObject.SetActive(enabled);
    }

    public void CameraFade(bool isFadeIn) {
        if (isFadeIn) {
            GameVariables.Instance.CameraFadeOut.gameObject.SetActive(false);
            GameVariables.Instance.CameraFadeIn.gameObject.SetActive(true);
            GameVariables.Instance.CameraFadeIn.SetTrigger("FadeIn");
        }
        else {
            GameVariables.Instance.CameraFadeIn.gameObject.SetActive(false);
            GameVariables.Instance.CameraFadeOut.gameObject.SetActive(true);
            GameVariables.Instance.CameraFadeOut.SetTrigger("FadeOut");
        }
    }

    public void PlayDoorTotemTimeline(int amountTotem) {
        switch (amountTotem) {
            case 1:
                GameVariables.Instance.Timeline_Totem_Track01.Play();
                break;
            case 2:
                GameVariables.Instance.Timeline_Totem_Track02.Play();
                break;
            case 3:
                GameVariables.Instance.Timeline_Totem_Track03.Play();
                break;
        }
    }

    public void PlayTimelineActivatedTrapByPlayer() {
        GameVariables.Instance.LastTrapActivatedByPlayer.PlayAnimation();
    }
}