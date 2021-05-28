using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bullet;

    private void Start()
    {
        InvokeRepeating("Attack", 0.9f, 0f);
    }

    private void Attack()
    {
        
        Instantiate(bullet);
        /*RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {

        }*/
    }
}
