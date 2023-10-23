using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{
    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float redius;

    [Header("Movement Settings")]
    [SerializeField] private float speed;

    private Rigidbody2D enemyRb;

    [Header("Enemy Rederer")]
    private SpriteRenderer spriteRenderer;

    private float moveX = 1;

    private void Start()
    {
        moveX = 1;
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, redius, groundLayer);

        if (!isGrounded)
        {
            transform.Rotate(0, 180, 0);
            Debug.Log("Continuas");
            moveX *= -1;
        }
    }

    private void FixedUpdate()
    {
        enemyRb.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, enemyRb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, redius);
    }
}
