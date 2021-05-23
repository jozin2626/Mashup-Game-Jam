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
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Jump", initialJumpDelay, jumpTiming);
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        if (rb.velocity.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * playerSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Flip()
    {

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
    }
}
