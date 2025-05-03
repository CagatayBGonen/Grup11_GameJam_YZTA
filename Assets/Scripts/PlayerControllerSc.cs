using UnityEngine;

public class PlayerControllerSc : MonoBehaviour
{
    public float jumpForce = 7f; // Karakter zıplama gücü
    private Rigidbody2D rb;
    private Animator animator; // Animator bileşeni
    private bool isGrounded = true;  // Karakterin zeminle temas edip etmediğini kontrol etmek için
     void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator varsa al, yoksa hata vermez
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Boşluk tuşuna basıldığında ve zeminle temas ediyorsa
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); //Zıpla
            isGrounded = false; // Zeminle temas etmiyo olarak ayarla

            if (animator != null) //Animatör varsa zıplama animasyonunu tetikle
                animator.SetTrigger("Jump");
        }

        if (animator != null) //Animmatör varsa koşma animasyonunu kontrol et
            animator.SetBool("IsRunning", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Zemin kontrolü
        if (collision.gameObject.CompareTag("Ground")) // Eğer temas edilen nesne Ground etiketine sahipse
        {
            isGrounded = true; // Zeminle temas etti olarak ayarla

            if (animator != null) //Animatör varsa zeminle temas animasyonunu tetikle
                animator.SetTrigger("Land");
        }
    }
}
