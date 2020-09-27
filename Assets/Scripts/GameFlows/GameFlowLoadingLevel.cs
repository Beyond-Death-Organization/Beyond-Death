using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowLoadingLevel : IGameFlow
{
#region Singleton

    private static GameFlowLoadingLevel instance = null;

    private GameFlowLoadingLevel() { }

    public static GameFlowLoadingLevel Instance {
        get { return instance ?? (instance = new GameFlowLoadingLevel()); }
        private set { instance = value; }
    }

#endregion
    
    public void PreInitialize() {
        throw new System.NotImplementedException();
    }

    public void Initialize() {
        throw new System.NotImplementedException();
    }

    public void Refresh() {
        throw new System.NotImplementedException();
    }

    public void PhysicRefresh() {
        throw new System.NotImplementedException();
    }

    public void LateRefresh() {
        throw new System.NotImplementedException();
    }

    public void Terminate() {
        throw new System.NotImplementedException();
    }
}
