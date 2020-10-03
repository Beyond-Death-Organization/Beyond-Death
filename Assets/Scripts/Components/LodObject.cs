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
    void Start()
    {
        switch (Baseon)
        {
            case BaseOn.Level:
                GameManager.Instance.OnNextLevel.AddListener(level=>
                {
                    ChangeMesh(level);
                });
                break;
            case BaseOn.DeathCount:
                GameManager.Instance.OnRestart.AddListener(()=>
                {
                    int tmp = PlayerManager.Instance.deathCounter;
                    ChangeMesh(PlayerManager.Instance.deathCounter);
                });
                
                break;
        }
    }

    public void ChangeMesh(int level)
    {
        MainObject.mesh = State[level].sharedMesh;
    }
}
