using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameFlowLoadingGame : IGameFlow
{
#region Singleton

    private static GameFlowLoadingGame instance = null;

    private GameFlowLoadingGame() { }

    public static GameFlowLoadingGame Instance {
        get { return instance ?? (instance = new GameFlowLoadingGame()); }
        private set { instance = value; }
    }

#endregion

    public void PreInitialize() { }

    public void Initialize() {
        GameFlowManager.SetGameFlow(GameFlowMenuLoop.Instance);
    }

    public void Refresh() { }

    public void PhysicRefresh() { }

    public void LateRefresh() { }

    public void Terminate() { }
}