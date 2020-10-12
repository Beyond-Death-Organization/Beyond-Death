using System;
using Cinemachine;
using Rewired;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraRotation : MonoBehaviour
{
    public InputsComponent Inputs;

    public float MouseCameraRotationSpeed = 150;
    public float JoystickCameraRotationSpeed = 200;
    
    private CinemachineFreeLook cameraFreeLook;

    private void Awake() {
        cameraFreeLook = GetComponent<CinemachineFreeLook>();
    }

    private void Start() {
        Inputs.Player.controllers.AddLastActiveControllerChangedDelegate(HandleControllerChange);
    }

    private void Update() {
        //TODO USE AXIS ID INSTEAD OF STRING COMPARISON
        cameraFreeLook.m_XAxis.m_InputAxisValue = Inputs.Player.GetAxis("Mouse X");
        cameraFreeLook.m_YAxis.m_InputAxisValue = Inputs.Player.GetAxis("Mouse Y");
    }

    private void HandleControllerChange(Rewired.Player p, Controller c) {
        if(c.type == ControllerType.Joystick)
            SetCameraRotationSpeed(JoystickCameraRotationSpeed);
        else
            SetCameraRotationSpeed(MouseCameraRotationSpeed);
    }

    private void SetCameraRotationSpeed(float speed) {
        cameraFreeLook.m_XAxis.m_MaxSpeed = speed;
    }
}
