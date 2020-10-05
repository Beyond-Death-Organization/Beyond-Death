using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float PointerScale = 1;
    public AudioClip HoverClip;
    private AudioSource source;
    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = HoverClip;
        source.playOnAwake = false;
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
        StartCoroutine(OnClickRoutine());
    }

    IEnumerator OnClickRoutine()
    {
        yield return null;

        Debug.Log("test");
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            // m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";
            Debug.Log("Loading progress: " + (asyncOperation.progress * 100) + "%");
            
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                // m_Text.text = "Press the space bar to continue";
                Debug.Log("Press the space bar to continue");

                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
