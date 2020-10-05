using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePressurePlate : MonoBehaviour, IPressurePlate
{
    public int NumberPlateToActivate;
    private bool isActive = true;
    private int NumberPlateActivate;
    public void ActionPressurePlateEnter()
    {
        NumberPlateActivate++;
        if(isActive && NumberPlateActivate == NumberPlateToActivate)
            CompletePuzzle();
    }

    public void ActionPressurePlateExit()
    {
        NumberPlateActivate--;
    }

    public void CompletePuzzle()
    {
        isActive = false;
    }
}
