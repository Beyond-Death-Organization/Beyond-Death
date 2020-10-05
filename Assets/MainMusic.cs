using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnNextLevel.AddListener(ChangeTrack);
    }

    // Update is called once per frame
    void ChangeTrack(int level)
    {
        switch (level)
        {
            case 0:
                AudioManager.Instance.PlayMusic("MusicA",GetComponent<AudioSource>());
                break;
            case 4:
                AudioManager.Instance.PlayMusic("MusicB",GetComponent<AudioSource>());
                break;
            case 8:
                AudioManager.Instance.PlayMusic("MusicC",GetComponent<AudioSource>());
                break;
        }
    }
}
