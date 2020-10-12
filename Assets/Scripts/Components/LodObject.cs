using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum BaseOn
{
    DeathCount,
    Level
}
public class LodObject : MonoBehaviour
{
    // Start is called before the first frame update
    public BaseOn Baseon;
    public List<GameObject> State;
    private int contaminationLevel = 0;
    private int currentLevel;
    void Start()
    {
        GameManager.Instance.OnNextLevel.AddListener(level=>
        {
            ChangeMesh(level);
        });
    }

    public void ChangeMesh(int level)
    {
        if (level % 3 == 0 && currentLevel != level)
            contaminationLevel++;
        currentLevel = level;
        switch (Baseon)
        {
            case BaseOn.Level:
                if(contaminationLevel < State.Count)
                    ShowGoodElement(contaminationLevel);
                break;
            case BaseOn.DeathCount:
                if(level - 1 < State.Count)
                    ShowGoodElement(level - 1);
                break;
        }
    }

    public void ShowGoodElement(int numberToShow)
    {
        int compteur = 0;
        foreach (var mesh in State)
        {
            if (compteur == numberToShow)
            {
                mesh.SetActive(true);
            }
            else
            {
                mesh.SetActive(false);
            }
            compteur++;
        }
    }
}
