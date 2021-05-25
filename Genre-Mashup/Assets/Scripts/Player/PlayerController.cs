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
    public GameObject heart1, heart2, heart3;
    private bool isGrounded;
    private Rigidbody2D rb;
    private CircleCollider2D floorCollider;
    private BoxCollider2D ceilingCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        floorCollider = GetComponent<CircleCollider2D>();
        ceilingCollider = GetComponent<BoxCollider2D>();
        FindObjectOfType<AudioManager>().Play("Level Music");
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
            FindObjectOfType<AudioManager>().Play("Hammer");
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
        FindObjectOfType<AudioManager>().Play("Jump");
        animator.SetBool("Grounded", false);
        animator.SetBool("Jump", true);
        animator.SetBool("Attack", false);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes") || collision.gameObject.CompareTag("Enemy"))
        {
            if (playerHealth == 3)
            {
                playerHealth--;
                heart3.SetActive(false);
            }
            else if (playerHealth == 2)
            {
                playerHealth--;
                heart2.SetActive(false);
            }
            else if (playerHealth == 1)
            {
                heart1.SetActive(false);
                Invoke("GameOver", 2f);
            }
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Grounded", true);
            isGrounded = true;
        }
    }

    private void GameOver()
    {

    }
}
