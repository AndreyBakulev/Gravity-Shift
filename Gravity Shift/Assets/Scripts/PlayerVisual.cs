using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private float targetRotation = 0f;
    private CameraController cameraController;

    void Start()
    {
        //reads from cameraController to get its rotation speed
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    void Update()
    {
        if (GravityManager.Instance == null) return;

        // Match rotation speed to camera
        float rotationSpeed = cameraController != null ? 
                              cameraController.rotationSpeed : 5f;

        int gravDir = GravityManager.Instance.GetCurrentDirection();

        switch (gravDir)
        {
            case 0: targetRotation = 0f;    break; // Gravity down
            case 1: targetRotation = 90f;   break; // Gravity right
            case 2: targetRotation = 180f;  break; // Gravity up
            case 3: targetRotation = -90f;  break; // Gravity left
        }

        float current = transform.eulerAngles.z;
        if (Mathf.Abs(targetRotation - current) > 180f)
            current += (targetRotation > current) ? 360f : -360f;

        float newZ = Mathf.Lerp(current, targetRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(0, 0, newZ);
    }
}