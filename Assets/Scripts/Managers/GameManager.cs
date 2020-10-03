using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }
    
    public void RestartGame()
    {
        Debug.Log("Restart Game");
    }

    public void RestartLevel()
    {
        Debug.Log("Restart Level");
    }

    public void NextLevel()
    {
        Debug.Log("Next Level");
    }
}

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = GameManager.Instance;
        
        base.DrawDefaultInspector();

        GUILayout.BeginVertical();
        if (Application.isPlaying)
        {
            if (GUILayout.Button("Restart Game")) { gameManager.RestartGame(); }

            if (GUILayout.Button("Restart Level")) { gameManager.RestartLevel(); }

            if (GUILayout.Button("Next Level")) { gameManager.NextLevel(); }
        }
        GUILayout.EndVertical();
    }
}
