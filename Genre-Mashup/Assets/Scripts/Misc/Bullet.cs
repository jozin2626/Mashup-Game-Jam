using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * -speed;
        Invoke("CleanUp", 5f);
    }

    private void CleanUp()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit trigger");
    }
}
