using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;
    public int deathCounter;
    private List<GameObject> corpse;
    private GameObject player;
    private GameObject startPos;
    private GameObject deathBody;
    private Image fadeImage;
    private float fadeDuration = 2;
    private CapsuleCollider playerCollider;
    private bool deathProcess = false;
    private void Awake() {
        
        player = GameVariables.Instance.Player.gameObject;
        playerCollider = player.GetComponent<CapsuleCollider>();
        startPos = GameVariables.References["StartPosition"];
        fadeImage = GameVariables.References["FadeImage"].GetComponent<Image>();
        deathBody = GameVariables.References["DeathBody"];
        fadeImage.canvasRenderer.SetAlpha(0);
        if (Instance == null) {
            Instance = this;
            corpse = new List<GameObject>();
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameManager.Instance.OnRestart.AddListener(IncreaseDeathCount);
    }

    public void IncreaseDeathCount()
    {
        deathCounter++;
    }
    public void Killplayer()
    {
        if (!deathProcess)
        {
            EventsPlayer.Instance.SetInputs(false);
            Debug.Log("kill");
            TimedActionManager.Instance.AddTimedAction(FadeOut, 2);
            deathProcess = true;
        }
    }
    public void InstantiateCorpse()
    {
        corpse.Add(Instantiate(deathBody, player.transform.position, Quaternion.Euler(0,0,90)));
    }

    public void FadeIn()
    {
        StartCoroutine(FadeView(false, false));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeView(true, true));
    }

    IEnumerator FadeView(bool isFadeOut, bool resetPlayer)
    {
        float time = 0;

        while (time < 2)
        {
            float pourcent;
            if (isFadeOut)
                pourcent = time / fadeDuration;
            else
                pourcent = (fadeDuration - time) / fadeDuration;
            fadeImage.canvasRenderer.SetAlpha(pourcent);
            time += Time.deltaTime;
            yield return null;
        }
        if(isFadeOut)
            ResetPlayer();
    }

    private void ResetPlayer()
    {
        InstantiateCorpse();
        GameManager.Instance.NextLevel();
        deathProcess = false;
        EventsPlayer.Instance.SetInputs(true);
        FadeIn();
    }
}
