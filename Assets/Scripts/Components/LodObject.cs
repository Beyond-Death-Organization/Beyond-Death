using System.Collections;
using System.Collections.Generic;
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
    public List<MeshFilter> State;
    public MeshFilter MainObject;
    private int contaminationLevel = 0;
    void Start()
    {
        GameManager.Instance.OnNextLevel.AddListener(level=>
        {
            ChangeMesh(level);
        });
    }

    public void ChangeMesh(int level)
    {
        
        if (level % 3 == 0)
            contaminationLevel++;
        switch (Baseon)
        {
            case BaseOn.Level:
                if(contaminationLevel < State.Count)
                    MainObject.mesh = State[contaminationLevel].sharedMesh;
                break;
            case BaseOn.DeathCount:
                if(level - 1 < State.Count)
                    MainObject.mesh = State[level - 1].sharedMesh;
                break;
        }
    }
}
