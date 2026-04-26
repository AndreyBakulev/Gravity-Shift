using UnityEngine;
public class GravityManager : MonoBehaviour
{
    [Header("Gravity Settings")]
    public float gravityMagnitude = 20f;
    // 0=Down 1=Left 2=Up 3=Right
    private int currentDirection = 0;
    public static GravityManager Instance;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ApplyGravity();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) RotateGravity(-1);
        if (Input.GetKeyDown(KeyCode.E)) RotateGravity(1);
    }
    void RotateGravity(int direction)
    {
        currentDirection = (currentDirection + direction + 4) % 4;
        ApplyGravity();
    }
    void ApplyGravity()
    {
        switch (currentDirection)
        {
            case 0: Physics2D.gravity = new Vector2(0, -gravityMagnitude); break; //down
            case 1: Physics2D.gravity = new Vector2(gravityMagnitude, 0); break; //right
            case 2: Physics2D.gravity = new Vector2(0, gravityMagnitude); break;  //up
            case 3: Physics2D.gravity = new Vector2(-gravityMagnitude, 0); break;  //left
        }
    }
    // Called by PlayerController.Die() to reset gravity to default
    public void ResetGravity()
    {
        currentDirection = 0;
        ApplyGravity();
    }
    public int GetCurrentDirection() { return currentDirection; }

}