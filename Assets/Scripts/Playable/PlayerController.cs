using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Settings")]
    public int health;

    private bool isCrouch = false;

    [SerializeField] private float speed = 0;

    [Header("Jump Setting")]
    [SerializeField] private float jumpForce = 0;

    [SerializeField] private int extraJump;

    private int remainedJump;

    [Header("CheckEnemy Settings")]
    [SerializeField] private Transform enemyCheck;

    [SerializeField] private float enemyCheckRadius;

    [SerializeField] private LayerMask enemyLayer;

    [Header("Ground Check Setting")]
    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask ground;

    [SerializeField] private float redius;

    [Header("Score Settings")]
    [SerializeField] private ScoreUpdate scoreUpdate;

    private SpriteRenderer playerSprite_R;

    private Animator playerAnimator;

    private Rigidbody2D playerRb;

    private float horizontalMove = 0;

    private const string ISJUMP = "IsJump";

    private const string ISCROUCH = "IsCrouch";

    private void Start()
    {
        InitValues();

        InitComponents();

        GameLossData.isLoss = false;
    }

    private void InitValues()
    {
        remainedJump = extraJump;

        isCrouch = false;
    }

    private void InitComponents()
    {
        playerSprite_R = GetComponent<SpriteRenderer>();

        playerAnimator = GetComponent<Animator>();

        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameLossData.isLoss)
        {
            playerRb.velocity = Vector2.zero;
            return;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");

        FaceDir();

        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        Attack();

        Jump();

        Crouch();

        IsDead();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlayEffect(SoundType.Attack);
            playerAnimator.SetTrigger("Attack");
        }
    }

    private void FaceDir()
    {
        if (horizontalMove > 0)
        {
            //sprite flip approach1 scale 
            //transform.localScale = Vector3.one;

            //sprite flip approach2 flip value
            playerSprite_R.flipX = false;
        }

        if (horizontalMove < 0)
        {
            //sprite flip approach1 scale 
            //transform.localScale = new Vector3(-1, 1, 1);

            //sprite flip approach2 flip value
            playerSprite_R.flipX = true;
        }
    }

    private void IsDead()
    {
        if (playerRb.velocity.y < -50)
        {
            GameLossData.isLoss = true;
        }
    }

    private void FixedUpdate()
    {
        if (GameLossData.isLoss)
        {
            playerRb.velocity = Vector2.zero;
            return;
        }

        PlayerRun();
    }



    private void PlayerRun()
    {
        if (!isCrouch)
        {
            Vector2 finalMoveValue = new(horizontalMove * speed * Time.fixedDeltaTime, playerRb.velocity.y);

            playerRb.velocity = finalMoveValue;
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, redius, ground);
        return isGrounded;
    }

    private void Jump()
    {
        bool isGrounded = IsGrounded();

        CheckIfJumpPress();

        //when player touch the ground extraJump will reset;
        if (isGrounded)
        {
            remainedJump = extraJump;
        }

        void Jump_Perform()
        {
            AudioManager.Instance.PlayEffect(SoundType.Jump);
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);

            SetBoolAnimation(ISJUMP, true);
        }

        void CheckIfJumpPress()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    Jump_Perform();
                }
                else if (!isGrounded && remainedJump > 0)
                {
                    Jump_Perform();
                    remainedJump--;
                }

            }
            else
            {
                SetBoolAnimation(ISJUMP, false);
            }
        }
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (IsGrounded())
            {
                playerRb.velocity = Vector2.zero;
            }

            isCrouch = true;

            SetBoolAnimation(ISJUMP, false);
            SetBoolAnimation(ISCROUCH, true);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouch = false;
            SetBoolAnimation(ISCROUCH, false);
        }
    }

    private void SetBoolAnimation(string animName, bool value)
    {
        playerAnimator.SetBool(animName, value);
    }



    public void CheckEnemy()
    {
        Collider2D enemy = Physics2D.OverlapCircle(enemyCheck.position, enemyCheckRadius, enemyLayer);
        if (enemy != null)
        {
            enemy.enabled = false;
            enemy.GetComponent<Animator>().Play("Death");
        }
    }

    public void TakeDamage()
    {
        health--;
        CheckIfDie();
    }

    private void CheckIfDie()
    {
        if (health <= 0)
        {
            health = 0;
            GameLossData.isLoss = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IfKeyTrigger(collision);
    }

    private void IfKeyTrigger(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            AudioManager.Instance.PlayEffect(SoundType.Key);
            scoreUpdate.IncreaseScore();
            if (other.TryGetComponent<Collectables>(out Collectables cm))
            {
                cm.PlayCollected();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, redius);
        Gizmos.DrawWireSphere(enemyCheck.position, enemyCheckRadius);
    }
}