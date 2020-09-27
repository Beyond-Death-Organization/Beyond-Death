using UnityEngine;

public class MainEntry : MonoBehaviour
{
#region Singleton

    public static MainEntry Instance = null;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            //GameObject.DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

#endregion

    private GameFlowManager gameFlowManager;

    private void Start() {
        gameFlowManager = GameFlowManager.Instance;
        
        gameFlowManager.PreInitialize();
        
        gameFlowManager.Initialize();
    }

    private void Update() {
        gameFlowManager.Refresh();
    }

    private void FixedUpdate() {
        gameFlowManager.PhysicRefresh();
    }

    private void LateUpdate() {
        gameFlowManager.LateRefresh();
    }

    private void OnApplicationFocus(bool hasFocus) { }    //TODO event

    private void OnApplicationPause(bool pauseStatus) { }    //TODO event

    private void OnApplicationQuit() {
        gameFlowManager.Terminate();
    }
}