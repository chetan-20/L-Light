using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private float defaultspeed;
    private float slidingspeed;
    private bool isjumping=false;
    private bool issliding = false;
    [SerializeField] private float movingspeed=2;    
    [SerializeField] private float jumpspeed = 1;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = rb.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        defaultspeed = movingspeed;
        slidingspeed = movingspeed * 2;
    }
    private void Update()
    {
        MovePlayer();
        JumpPlayer();
        SlidePlayer();
        Attack();
    }
    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movingspeed, rb.velocity.y);
            rbSprite.flipX = false;
            animator.SetBool("IsMoving", true);          
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movingspeed, rb.velocity.y);
            rbSprite.flipX = true;
            animator.SetBool("IsMoving", true);           
        }
        else
        {            
            rb.velocity = new Vector2(0f, rb.velocity.y);
            animator.SetBool("IsMoving", false);           
        }
    }
    private void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !issliding && !isjumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            animator.SetBool("IsJumping", true);
            isjumping = true;
        }
    }   
    private void SlidePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isjumping && !issliding)
        {
            issliding = true;
            animator.SetBool("IsSliding", true);
            movingspeed = slidingspeed;
        }
    }   
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("IsAttacking", true);
        }
    }
    private void TurnOffAttack()
    {
        animator.SetBool("IsAttacking", false);
    } 
    private void TurnOffJump()
    {
        animator.SetBool("IsJumping", false);
        isjumping = false;
    } 
    private void TurnOffSlide()
    {
        issliding = false;
        movingspeed = defaultspeed;
        animator.SetBool("IsSliding", false);
    }
}
