using UnityEngine;
using UnityEngine.InputSystem; // This uses Unity's new Input Settings asset. Add this script to the an empty GameObject, tag the GameObject "Player"
using Unity.Cinemachine; // Use using Cinemachine; if you are on older Unity versions
// For the new Input Settings system, you'll need to make sure you're using it under project settings. Then you'll add custom inputs to the universal input settings. Call them whatever you like
// and map the correct button presses. Because the new input system reads from the Player tag, that object has to have the inputs mapped to the inputsettings (.inputsettings file). Because you're adding
// this NewCameraSwitcher.cs file to the "Player" and not anything else, it will read correctly. In the inspector, add the cameras and specify what button does what.

public class CameraSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    public CinemachineCamera cameraOne;   // Your main gameplay camera
    public CinemachineCamera cameraTwo;   // Your secondary/cutscene camera
    public CinemachineCamera cameraThree; // Your tertiary/cutscene camera

    [Header("Input Actions")]
    public InputActionReference cameraOneAction;
    public InputActionReference cameraTwoAction;
    public InputActionReference cameraThreeAction;

    [Header("Timer Settings")]
    public bool useTimer = false;
    public float timeToSwitch = 5f;

    private void OnEnable()
    {
        if (cameraOneAction != null)
        {
            cameraOneAction.action.Enable();
            cameraOneAction.action.performed += OnCameraOnePressed;
        }

        if (cameraTwoAction != null)
        {
            cameraTwoAction.action.Enable();
            cameraTwoAction.action.performed += OnCameraTwoPressed;
        }

        if (cameraThreeAction != null)
        {
            cameraThreeAction.action.Enable();
            cameraThreeAction.action.performed += OnCameraThreePressed;
        }
    }

    private void OnDisable()
    {
        if (cameraOneAction != null)
        {
            cameraOneAction.action.performed -= OnCameraOnePressed;
            cameraOneAction.action.Disable();
        }

        if (cameraTwoAction != null)
        {
            cameraTwoAction.action.performed -= OnCameraTwoPressed;
            cameraTwoAction.action.Disable();
        }

        if (cameraThreeAction != null)
        {
            cameraThreeAction.action.performed -= OnCameraThreePressed;
            cameraThreeAction.action.Disable();
        }
    }

    private void Start()
    {
        ActivateCameraOne();
    }

    private void OnCameraOnePressed(InputAction.CallbackContext context) => ActivateCameraOne();
    private void OnCameraTwoPressed(InputAction.CallbackContext context) => ActivateCameraTwo();
    private void OnCameraThreePressed(InputAction.CallbackContext context) => ActivateCameraThree();

    public void ActivateCameraOne()
    {
        cameraOne.Priority = 15;
        cameraTwo.Priority = 5;
        cameraThree.Priority = 10;
    }

    public void ActivateCameraTwo()
    {
        cameraOne.Priority = 5;
        cameraTwo.Priority = 15;
        cameraThree.Priority = 10;
    }

    public void ActivateCameraThree()
    {
        cameraOne.Priority = 5;
        cameraTwo.Priority = 10;
        cameraThree.Priority = 15;
    }
}
