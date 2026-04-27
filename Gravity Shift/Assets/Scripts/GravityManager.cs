using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [Header("Gravity Settings")]
    public float gravityMagnitude = 20f;

    // 0=Down  1=Right  2=Up  3=Left
    private int currentDirection = 0;

    public static GravityManager Instance;

    void Awake()
    {   
        //makes sure there arent any double GravityManagers that will cause bugs
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
            case 0: Physics2D.gravity = new Vector2(0, -gravityMagnitude); break; // Down
            case 1: Physics2D.gravity = new Vector2(gravityMagnitude, 0);  break; // Right
            case 2: Physics2D.gravity = new Vector2(0,  gravityMagnitude); break; // Up
            case 3: Physics2D.gravity = new Vector2(-gravityMagnitude, 0); break; // Left
        }
    }

    public void ResetGravity()
    {
        currentDirection = 0;
        ApplyGravity();
    }

    public int GetCurrentDirection() { return currentDirection; }
}