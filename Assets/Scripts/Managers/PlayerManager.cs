using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;
    private List<Transform> corpse;
    private GameObject player;
    private GameObject startPos;
    private GameObject deathBody;
    private Image fadeImage;
    private float fadeDuration = 2;
    private void Awake() {
        player = GameVariables.References["Player"];
        startPos = GameVariables.References["StartPosition"];
        fadeImage = GameVariables.References["FadeImage"].GetComponent<Image>();
        deathBody = GameVariables.References["DeathBody"];
        fadeImage.canvasRenderer.SetAlpha(0);
        if (Instance == null) {
            Instance = this;
            corpse = new List<Transform>();
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }

    public void Killplayer()
    {
        
        Debug.Log("kill");
        TimedActionManager.Instance.AddTimedAction(FadeOut, 2);
        //corpse.Add(GameVariables.References["Player"].transform);
        //player.transform.position = startPos.transform.position;
    }
    public void InstantiateCorpse()
    {
        Instantiate(deathBody, player.transform.position, player.transform.rotation);
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
        player.transform.position = startPos.transform.position;
        FadeIn();
    }
}
