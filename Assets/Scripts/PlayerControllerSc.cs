using UnityEngine;

public class PlayerControllerSc : MonoBehaviour
{
    public float jumpForce = 6f;
    public float doubleJumpForce = 7f;
    public float fastFallForce = -10f;
    public float dashForce = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 5f;

    [SerializeField] private float moveForwardSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = true;
    private bool canDoubleJump = false;
    private bool hasDoubleJumped = false;
    private bool isDashing = false;
    private bool canDash = true;
    private float dashTimer;
    private float dashCooldownTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(moveForwardSpeed, rb.linearVelocity.y);
        }
    }

    void Update()
    {
        // Zıplama
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump(jumpForce);
                canDoubleJump = true;
                hasDoubleJumped = false;
            }
            else if (canDoubleJump)
            {
                Jump(doubleJumpForce);
                canDoubleJump = false;
                hasDoubleJumped = true;
            }
        }

        // Hızlı düşme
        if (!isGrounded && Input.GetKeyDown(KeyCode.S))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fastFallForce);
        }

        // Dash sadece havadayken ve cooldown süresi dolmuşsa
        if (!isGrounded && Input.GetKeyDown(KeyCode.D) && canDash && !isDashing)
        {
            StartDash();
        }

        // Dash süresi
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                EndDash();
            }
        }

        // Cooldown süresi
        if (!canDash)
        {
            dashCooldownTimer -= Time.deltaTime;
            if (dashCooldownTimer <= 0f)
            {
                canDash = true;
            }
        }

    }

    void Jump(float force)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
        isGrounded = false;

        if (animator != null)
            animator.SetTrigger("isJumping");
    }

    void StartDash()
{
    isDashing = true;
    canDash = false;
    dashTimer = dashDuration;
    dashCooldownTimer = dashCooldown;

    // Dash hareketi
    rb.linearVelocity = new Vector2(dashForce, 0f);

    // Dash animasyonu için bool parametreyi true yapıyoruz
    if (animator != null)
        animator.SetBool("isDashing", true); // Bool parametre kullanıyoruz
}
    

void EndDash()
{
    isDashing = false;

    // Dash bittiğinde bool parametreyi false yapıyoruz
    if (animator != null)
        animator.SetBool("isDashing", false); // Dash tamamlandığında false yapıyoruz
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = false;
            hasDoubleJumped = false;
            isDashing = false;

            if (animator != null)
                animator.SetBool("isJumping", false);
        }
    }
}
