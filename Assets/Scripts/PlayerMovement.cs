using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float swipeThreshold = 50f;
    public float jumpForce;

    private Rigidbody2D rb;
    private Vector2 touchStartPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Keyboard
        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(horizontal * moveSpeed, rb.linearVelocity.y, 0);

        // Touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 delta = touch.position - touchStartPos;
                if (Mathf.Abs(delta.x) > swipeThreshold)
                {
                    float direction = Mathf.Sign(delta.x);
                    rb.linearVelocity = new Vector3(direction * moveSpeed, rb.linearVelocity.y, 0);
                }
            }
        }
    }

    //using OnTriggerEnter2D function for bouncing the ball
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            rb.linearVelocity = new Vector2(transform.position.x, jumpForce);
        }
    }
}
