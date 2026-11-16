using UnityEngine;
using Unity.Cinemachine; // Use using Cinemachine; if you are on older Unity versions

public class CameraSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    // This is the section where you set up the Cinemachine Cameras. Follow the examples for
    // more cameras. But you must name them exactly like the variables below.
    public CinemachineCamera cameraOne; // Your main gameplay camera
    public CinemachineCamera cameraTwo; // Your secondary/cutscene camera
    public CinemachineCamera cameraThree; // Your tertiary/cutscene camera

    [Header("Timer Settings")]
    public bool useTimer = false;
    public float timeToSwitch = 5f;

    private void Start()
    {
        // Ensure Camera One starts as the active camera. Ignore this for now. I'm still
	// thinking through how to do this.
        ActivateCameraOne();

        // If using a timer, trigger the switch after the specified seconds
        // if (useTimer)
        // {
        //     Invoke(nameof(ActivateCameraTwo), timeToSwitch);
        // }
    }

    private void Update()
    {
        // Manual override or manual switching via Key Presses
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateCameraOne();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateCameraTwo();
        }
	else if (Input.GetKeyDown(KeyCode.Alpha3))
	{
	    ActivateCameraThree();
	}
    }

    public void ActivateCameraOne()
    {
        cameraOne.Priority = 10;
        cameraTwo.Priority = 5;
	cameraThree.Priority = 15;
    }

    public void ActivateCameraTwo()
    {
        cameraOne.Priority = 5;
        cameraTwo.Priority = 15;
	cameraThree.Priority =10;
    }
    public void ActivateCameraThree()
    {
        cameraOne.Priority = 5;
        cameraThree.Priority = 15;
	cameraTwo.Priority = 10;
    }
}
