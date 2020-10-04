using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private string contaminationLevelReached;
    void Start()
    {
        GameManager.Instance.OnNextLevel.AddListener(ChangeTrack);
        AudioManager.Instance.PlayMusic("MusicA",GetComponent<AudioSource>());
        contaminationLevelReached = "MusicA";
    }

    // Update is called once per frame
    void ChangeTrack(int level)
    {
        switch (level)
        {
            case 0:
                AudioManager.Instance.PlayMusic("MusicA",GetComponent<AudioSource>());
                break;
            case 3:
                AudioManager.Instance.PlayMusic("MusicB",GetComponent<AudioSource>());
                break;
            case 6:
                AudioManager.Instance.PlayMusic("MusicC",GetComponent<AudioSource>());
                break;
            case 9:
                AudioManager.Instance.PlayMusic("MusicD",GetComponent<AudioSource>());
                break;
        }
    }
}
