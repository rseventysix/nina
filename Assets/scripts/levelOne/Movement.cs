using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] Animator animator;

    public bool canMove;
    public bool canJump;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = false;
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            Flip();

            if (canJump)
            {
                if  (Input.GetButtonDown("Jump") && isGrounded())
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                }

                if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                }
            }

            if (horizontal != 0)
            {
                animator.SetBool("isWalking", true);
            }

            else {animator.SetBool("isWalking", false);}
        }

        else 
        {
            animator.SetBool("isWalking", false);
            horizontal = 0;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }

        else {rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);}
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.8f, groundLayer);
    }
}
