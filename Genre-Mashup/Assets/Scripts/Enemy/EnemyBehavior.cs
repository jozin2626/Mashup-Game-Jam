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
        InvokeRepeating("Attack", 0f, 2f);
    }

    private void Attack()
    {
        Instantiate(bullet);
    }
}
