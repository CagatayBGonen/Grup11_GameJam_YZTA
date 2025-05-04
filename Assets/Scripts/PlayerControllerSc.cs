using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerSc : MonoBehaviour
{
  public float jumpForce = 6f;
    public float doubleJumpForce = 7f;
    public float fastFallForce = -6f; // Normal zıplamada S'ye basılırsa
    public float superFastFallForce = -10f; // Double jump sonrası S'ye basılırsa
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

    public GameObject dashBarPrefab;
    private GameObject dashBarInstance;
    private Image dashBarFill;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (dashBarPrefab != null)
        {
            dashBarInstance = Instantiate(dashBarPrefab);
            dashBarFill = dashBarInstance.transform.Find("Background/Fill").GetComponent<Image>();
            dashBarInstance.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(moveForwardSpeed, rb.linearVelocity.y);
        }

        // DashBar karakteri takip etsin
        if (dashBarInstance != null)
        {
            dashBarInstance.transform.position = transform.position + new Vector3(0, 1.5f, 0);
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
            float fallForce = hasDoubleJumped ? superFastFallForce : fastFallForce;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fallForce);
        }

        // Dash
        if (!isGrounded && Input.GetKeyDown(KeyCode.D) && canDash && !isDashing)
        {
            StartDash();
        }

        // Dash süresi kontrolü
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

            if (dashBarInstance != null && dashBarFill != null)
            {
                float fill = Mathf.Clamp01(1f - (dashCooldownTimer / dashCooldown));
                dashBarFill.fillAmount = fill;

                if (fill >= 1f)
                {
                    dashBarInstance.SetActive(false);
                }
            }

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

        rb.linearVelocity = new Vector2(dashForce, 0f);

        if (animator != null)
            animator.SetBool("isDashing", true);

        if (dashBarInstance != null && dashBarFill != null)
        {
            dashBarInstance.SetActive(true);
            dashBarFill.fillAmount = 0f;
        }
    }

    void EndDash()
    {
        isDashing = false;

        if (animator != null)
            animator.SetBool("isDashing", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")&&collision.gameObject.CompareTag("AirGround"))
        {
            isGrounded = true;
            canDoubleJump = false;
            hasDoubleJumped = false;
            isDashing = false;

            if (animator != null)
                animator.SetBool("isJumping", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Barrier"))
        {
            GameManager.Instance.LooseEnergy();
            
        }
        else if (collision.CompareTag("EnergyBall"))
        {
            Debug.Log("player ile carpisti");
            GameManager.Instance.CollectEnergy(); // GameManager scriptindeki CollectEnergy methodunu calistiriyoruz.
            Destroy(collision.gameObject);
        }

    }
    
}
