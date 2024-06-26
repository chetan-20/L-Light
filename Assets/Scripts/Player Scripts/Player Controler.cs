using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static PlayerControler instance;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private float defaultspeed;
    private float slidingspeed;
    private bool isjumping=false;
    private bool issliding = false;
    internal float playerhealth = 100f;   
    [SerializeField] private float movingspeed=2;    
    [SerializeField] private float jumpspeed = 1;
    [SerializeField] internal BoxCollider2D attackhitbox;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D WinTrigger;
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        rbSprite = rb.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        defaultspeed = movingspeed;
        slidingspeed = movingspeed * 2;
        attackhitbox.enabled = false;
        Time.timeScale = 1f;      
    }
   
    private void Update()
    {  
        MovePlayer();
        JumpPlayer();      
        SlidePlayer();
        Attack();
        LevelLost();
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
            SoundManager.Instance.PlaySound(Sounds.JumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            animator.SetBool("IsJumping", true);
            isjumping = true;
        }
    }   
    private void SlidePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isjumping && !issliding)
        {
            SoundManager.Instance.PlaySound(Sounds.SlideSound);
            issliding = true;
            animator.SetBool("IsSliding", true);
            movingspeed = slidingspeed;
        }
    }   
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !issliding && !isjumping)
        {
            SoundManager.Instance.PlaySound(Sounds.AttackSound);
            animator.SetBool("IsAttacking", true);          
            attackhitbox.enabled = true;
            attackhitbox.transform.localPosition = new Vector2(rbSprite.flipX ? -2.5f : 0f, attackhitbox.transform.localPosition.y);           
        }
    }
   
    private void TurnOffAttack()
    {
        animator.SetBool("IsAttacking", false);
        attackhitbox.enabled = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == WinTrigger)
        {          
            LevelManager.Instance.OnGameWon();
        }
    }

    private void LevelLost()
    {
        if (playerhealth <= 0)
        {           
            LevelManager.Instance.OnGameLost();
        }
    }
}
