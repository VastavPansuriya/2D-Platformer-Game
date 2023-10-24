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

    [SerializeField] private float moveX;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    public override void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, redius, groundLayer);

        if (!isGrounded)
        {
            Debug.Log("Work");

            Debug.Log(moveX, this);
            Flip_Enemy();
        }

    }

    public override void FixedUpdate()
    {
        enemyRb.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, enemyRb.velocity.y);

    }
    private void Flip_Enemy()
    {
        if (moveX > 0)
        {
            moveX = -1;

            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            moveX = 1;

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, redius);
    }
}
