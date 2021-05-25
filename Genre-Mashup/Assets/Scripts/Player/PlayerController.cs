using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTiming;
    [SerializeField] private float initialJumpDelay;
    public Animator animator;
    private Vector2 movement = new Vector2();
    private int playerHealth = 3;
    private bool isGrounded;
    private Rigidbody2D rb;
    private CircleCollider2D floorCollider;
    private BoxCollider2D ceilingCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        floorCollider = GetComponent<CircleCollider2D>();
        ceilingCollider = GetComponent<BoxCollider2D>();
        InvokeRepeating("Jump", initialJumpDelay, jumpTiming);
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        animator.SetFloat("Movement", Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetFloat("LastMovement", Input.GetAxisRaw("Horizontal"));
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetBool("Attack", true);
            Invoke("StopAttack", 0.4f);
        }
    }

    private void StopAttack()
    {
        animator.SetBool("Attack", false);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * playerSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        animator.SetBool("Grounded", false);
        animator.SetBool("Jump", true);
        animator.SetBool("Attack", false);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (playerHealth > 1)
            {
                playerHealth--;
            }
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Grounded", true);
            isGrounded = true;
        }
    }
}
