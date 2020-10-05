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
    private bool hasGameJustStarted = true;

    private void Start() {
        mainCamera = Camera.main;
    }

    public void EnableMainCamera(bool enabled) {
        mainCamera.gameObject.SetActive(enabled);
    }

    public void CameraFade(bool isFadeIn) {
        GameVariables.Instance.CameraFadeAnimator.SetTrigger(isFadeIn ? "FadeIn" : "FadeOut");
    }

    public void PlayDoorTotemTimeline(int amountTotem) {
        switch (amountTotem) {
            case 1:
                GameVariables.Instance.DoorKey01.SetActive(true);
                GameVariables.Instance.Timeline_Totem_Track01.Play();
                break;
            case 2:
                GameVariables.Instance.DoorKey02.SetActive(true);
                GameVariables.Instance.Timeline_Totem_Track02.Play();
                break;
            case 3:
                GameVariables.Instance.DoorKey03.SetActive(true);
                GameVariables.Instance.Timeline_Totem_Track03.Play();
                break;
        }
    }

    public void PlayTimelineActivatedTrapByPlayer() {
        if (GameVariables.Instance.LastTrapActivatedByPlayer != null)
            GameVariables.Instance.LastTrapActivatedByPlayer.PlayAnimation();
    }

    public void PlayTimelineIntro() {
        if (hasGameJustStarted) {
            hasGameJustStarted = false;
            GameVariables.Instance.Timeline_PlayerIntro.Play();
        }
        else
            GameVariables.Instance.Timeline_PlayerJumpOffTombeau.Play();
    }

    public void StartMusic() {
        Managers.AudioManager.Instance.PlayMusic("MusicA", GetComponent<AudioSource>());
    }

    public void OnToggleBody() {
        if (GameVariables.Instance.LastTrapActivatedByPlayer != null)
            GameVariables.Instance.LastTrapActivatedByPlayer.ToggleDeadBody();
    }
}