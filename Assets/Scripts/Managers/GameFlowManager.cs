using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : IManager
{
#region Singleton

    private static GameFlowManager instance = null;

    private GameFlowManager() { }

    public static GameFlowManager Instance {
        get { return instance ?? (instance = new GameFlowManager()); }
        private set { instance = value; }
    }

#endregion

    private IGameFlow currentFlow;
    private IGameFlow previousFlow;

    private bool hasCurrentFlowChanged;

    public void PreInitialize() {
        currentFlow = GameFlowLoadingGame.Instance;
    }

    public void Initialize() {
        currentFlow.PreInitialize();
        currentFlow.Initialize();
    }

    public void Refresh() {
        if (hasCurrentFlowChanged) {
            hasCurrentFlowChanged = false;
            previousFlow.Terminate();

            currentFlow.PreInitialize();
            currentFlow.Initialize();
        }

        currentFlow.Refresh();
    }

    public void PhysicRefresh() {
        if (!hasCurrentFlowChanged)
            currentFlow.PhysicRefresh();
    }

    public void LateRefresh() {
        if (!hasCurrentFlowChanged)
            currentFlow.LateRefresh();
    }

    public void Terminate() {
        currentFlow.Terminate();
    }

    private void SetFlow(IGameFlow flow) {
        hasCurrentFlowChanged = true;
        previousFlow = currentFlow;
        currentFlow = flow;
    }

    public static void SetGameFlow(IGameFlow flow) {
        Instance.SetFlow(flow);
    }
}