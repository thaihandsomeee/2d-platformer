using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sp;

    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5;

    private bool canMove = true;
    private bool canDoubleJump = true;
    private bool canWallSlide = true;
    private bool isWallSliding = true;

    private bool facingRight = true;
    private float movingInput;
    private int facingDirection = 1;
    [SerializeField] private Vector2 wallJumpDirection;


    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    private bool isWallDetected = true;
    private bool isGrounded = true;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    public static PlayerMovement Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            JumpButton();

        if (canMove)
            movingInput = Input.GetAxisRaw("Horizontal");

        if (isGrounded)
        {
            canMove = true;
            canDoubleJump = true;
        }

        if (Input.GetAxis("Vertical") < 0)
            canWallSlide = false;

        if (isWallDetected && canWallSlide)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.1f);
        }
        else if (!isWallDetected)
        {
            isWallSliding = false;    
            Move();
        }
        Time.timeScale = 1f;
        CollisionCheck();
        FlipController();
        AnimatorController();
    }

    private void Move()
    {
        if (canMove && KBCounter <= 0)
            rb.velocity = new Vector2(movingInput * speed, rb.velocity.y);
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
    }

    private void JumpButton()
    {       
        if (isWallSliding)
            WallJump();
        else if (isGrounded)
            Jump();
        else if (canDoubleJump)
        {
            canMove = true;
            canDoubleJump = false;
            Jump();
        }
        canWallSlide = false;
    }

    private void Jump()
    {
        SoundManager.Instance.PlayJumpSound();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void WallJump()
    {
        canMove = true;
        canDoubleJump = true;
        SoundManager.Instance.PlayJumpSound();
        Vector2 direction = new Vector2(wallJumpDirection.x * -facingDirection, wallJumpDirection.y);
        rb.AddForce(direction, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        //transform.Rotate(0, 180, 0);
    }
    private void FlipController()
    {

        if (isGrounded && isWallDetected)
        {
            if (facingRight && movingInput < 0)
            {
                sp.flipX = true;
                Flip();
            }
            else if (!facingRight && movingInput > 0)
            {
                sp.flipX = false;
                Flip();
            }
        }

        if (rb.velocity.x > 0 && !facingRight)
        {
            sp.flipX = false;
            Flip();
        }
            
        else if (rb.velocity.x < 0 && facingRight)
        {
            sp.flipX = true;
            Flip();
        }
    }

    private void AnimatorController()
    {
        bool isRunning = rb.velocity.x != 0;

        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isWallSliding", isWallSliding);
    }

    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position,Vector2.down, groundCheckRadius, whatIsGround);
        isWallDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);

        if (!isGrounded && rb.velocity.y < 0)
            canWallSlide = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance,transform.position.y));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x,transform.position.y - groundCheckRadius));
    }
}
