using System;
using System.Collections;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float PointerScale = 1;
    public AudioClip HoverClip;
    private AudioSource source;
    public Image image;
    private Player player;
    private bool clicked;
    private void Awake()
    {
        player = ReInput.players.GetPlayer("Player01");
        source = gameObject.AddComponent<AudioSource>();
        source.clip = HoverClip;
        source.playOnAwake = false;
    }

    private void Update()
    {
        if (player.GetButton("Interact"))
        {
            Click();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        source.Play();
        transform.localScale *= PointerScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= PointerScale;
    }

    public void Click()
    {
        if (!clicked)
        {
            image.gameObject.SetActive(true);
            StartCoroutine(OnClickRoutine());
        }
    }

    IEnumerator OnClickRoutine()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            float currentProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            if(currentProgress > image.fillAmount)
                image.fillAmount = currentProgress;
            
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
                yield return new WaitForSeconds(0.1f);
            }

            yield return null;
        }
    }
}
