using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 14f;
    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 startPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius, groundLayer);
        float input = Input.GetAxisRaw("Horizontal");
        int gravDir = GravityManager.Instance.GetCurrentDirection();
        // Move perpendicular to gravity
        switch (gravDir)
        {
            case 0: // Gravity down
            case 2: // Gravity up
                rb.linearVelocity = new Vector2(input * moveSpeed, rb.linearVelocity.y);
                break;
            case 1: // Gravity left
            case 3: // Gravity right
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, input * moveSpeed);
                break;

        }
        // Jump — always opposite to current gravity
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector2 jumpDir = -Physics2D.gravity.normalized;
            // Zero only the jump axis to avoid a velocity spike
            switch (gravDir)
            {
                case 0: case 2: // vertical jump
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                    break;
                case 1: case 3: // horizontal jump
                    rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                    break;
            }
            rb.AddForce(jumpDir * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void Die()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        GravityManager.Instance.ResetGravity();
    }
    public void SetSpawnPoint(Vector3 pos) { startPosition = pos; }
    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}