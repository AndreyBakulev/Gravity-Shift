using UnityEngine;
/*NOTE:
Directions:
0 = down
1 = left
2 = up
3 = right
*/
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public float groundCheckRadius = 0.2f;
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
        // Calculate ground check position based on gravity direction
        Vector2 groundCheckOffset;
        int gravDir = GravityManager.Instance.GetCurrentDirection();

        switch (gravDir)
        {
            case 0: // Gravity down - check below
                groundCheckOffset = new Vector2(0, -0.4f);
                break;
            case 1: // Gravity right - check to the left
                groundCheckOffset = new Vector2(0.4f, 0);
                break;
            case 2: // Gravity up - check above
                groundCheckOffset = new Vector2(0, 0.4f);
                break;
            case 3: // Gravity left - check to the right
                groundCheckOffset = new Vector2(-0.4f, 0);
                break;
            default:
                groundCheckOffset = new Vector2(0, -0.4f);
                break;
        }

        Vector2 checkPosition = (Vector2)transform.position + groundCheckOffset;
        isGrounded = Physics2D.OverlapCircle(checkPosition, groundCheckRadius, groundLayer);

        float input = Input.GetAxisRaw("Horizontal");

        switch (gravDir)
        {
            case 0: // Gravity down
                rb.linearVelocity = new Vector2(input * moveSpeed, rb.linearVelocity.y);
                break;
            case 2: // Gravity up
                rb.linearVelocity = new Vector2(-input * moveSpeed, rb.linearVelocity.y);
                break;
            case 1: // Gravity right
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, input * moveSpeed);
                break;
            case 3: // Gravity left
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -input * moveSpeed);
                break;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space pressed. isGrounded: " + isGrounded);
            //Debug.Log("Check position: " + checkPosition);
        } */

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector2 jumpDir = -Physics2D.gravity.normalized;
            rb.linearVelocity = Vector2.zero;
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

    public void SetSpawnPoint(Vector3 pos)
    {
        startPosition = pos;
    }

    void OnDrawGizmos() //draws gizmo to check for isGrounded based off gravDir
    {
        int gravDir = GravityManager.Instance != null ? 
                      GravityManager.Instance.GetCurrentDirection() : 0;
        Vector2 offset;
        switch (gravDir)
        {
            case 1: offset = new Vector2(0.4f, 0); break; //right
            case 2: offset = new Vector2(0, 0.4f);  break; //up
            case 3: offset = new Vector2(-0.4f, 0);  break; //left
            default: offset = new Vector2(0, -0.4f); break; //default = down
        }
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + offset, groundCheckRadius);
    }
}