using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private float speed = 0;

    [SerializeField] private float jumpForce = 0;

    private SpriteRenderer playerSprite_R;

    private Animator playerAnimator;

    private float moveValue = 0;

    private Rigidbody2D playerRb;


    // Start is called before the first frame update
    private void Start()
    {
        playerSprite_R = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        //input approach 1 smooth movement 
        /*moveValue = Input.GetAxis("Horizontal");*/

        //input approach 2 raw Movement and time.deltatime 
        moveValue = Input.GetAxisRaw("Horizontal");     
        if (moveValue > 0)
        {

            //sprite flip approach1 scale 
            transform.localScale = Vector3.one;
            //sprite flip approach2 flip value
<<<<<<< Updated upstream
    
=======
            //playerSprite_R.flipX = false;



>>>>>>> Stashed changes
        }

        if (moveValue < 0)
        {
            //sprite flip approach1 scale 
            transform.localScale = new Vector3(-1,1,1);
            //sprite flip approach2 flip value
            //playerSprite_R.flipX = true;
        }

<<<<<<< Updated upstream
        playerAnimator.SetFloat("Speed",Mathf.Abs(moveValue));

=======
       

    }

    private void FixedUpdate()
    {
        float finalMoveValue = moveValue * Time.fixedDeltaTime * speed;

        playerRb.velocity = new Vector2(finalMoveValue, playerRb.velocity.y);
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAnimator.SetBool("IsCrouch", true);
        }
        else
        {
            playerAnimator.SetBool("IsCrouch", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playerAnimator.GetBool("IsCrouch"))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAnimator.SetBool("IsJump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnimator.SetBool("IsJump", false);

        }
>>>>>>> Stashed changes
    }
}
