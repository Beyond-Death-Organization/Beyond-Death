using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameFlowMenuLoop : IGameFlow
{
#region Singleton

    private static GameFlowMenuLoop instance = null;

    private GameFlowMenuLoop() { }

    public static GameFlowMenuLoop Instance {
        get { return instance ?? (instance = new GameFlowMenuLoop()); }
        private set { instance = value; }
    }

#endregion
    
    public void PreInitialize() { }

    public void Initialize() { }

    public void Refresh() { }

    public void PhysicRefresh() { }

    public void LateRefresh() { }

    public void Terminate() { }
}