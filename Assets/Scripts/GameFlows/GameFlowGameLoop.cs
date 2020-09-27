using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameFlowGameLoop : IGameFlow
{
#region Singleton

    private static GameFlowGameLoop instance = null;

    private GameFlowGameLoop() { }

    public static GameFlowGameLoop Instance {
        get { return instance ?? (instance = new GameFlowGameLoop()); }
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