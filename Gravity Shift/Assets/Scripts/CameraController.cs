using UnityEngine;
public class CameraController : MonoBehaviour

{
    public Transform player;
    public float rotationSpeed = 5f;
    public bool enableRotation = true;
    private float targetRotation = 0f;
    private int lastGravDir = 0;
    void LateUpdate()
    {
        // Follow player
        if (player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x;
            pos.y = player.position.y;
            transform.position = pos;
        }
        // Rotate with gravity
        if (enableRotation && GravityManager.Instance != null)
        {
            int dir = GravityManager.Instance.GetCurrentDirection();
            if (dir != lastGravDir)
            {
                lastGravDir = dir;
                targetRotation = dir * 90f;
            }
            float current = transform.eulerAngles.z;
            if (Mathf.Abs(targetRotation - current) > 180f)
                current += (targetRotation > current) ? 360f : -360f;
            float newZ = Mathf.Lerp(current, targetRotation,
                            Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Euler(0, 0, newZ);
        }
    }
    public void SetRotationEnabled(bool enabled)
    {
        enableRotation = enabled;
        if (!enabled) transform.rotation = Quaternion.identity;
    }
}