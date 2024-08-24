using UnityEngine;

public class PlayerControler
{  
   
    private PlayerView playerView;
    private PlayerModel playerModel;

    public PlayerControler(PlayerView playerView)
    {
        this.playerView = playerView;
        playerModel = new PlayerModel();
    }
      
    public void Start()
    {
        playerModel.defaultspeed = playerModel.movingspeed;
        playerModel.slidingspeed = playerModel.movingspeed * 2;
        playerView.attackhitbox.enabled = false;            
    }
    public void Update()
    {
        MovePlayer();
        JumpPlayer();
        SlidePlayer();
        Attack();
        LevelLost();
        UpdateHealthBar();
    }
    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GameService.Instance.SoundService.PlayFootStep();
            playerView.rb.velocity = new Vector2(playerModel.movingspeed, playerView.rb.velocity.y);
            playerView.rbSprite.flipX = false;
            playerView.animator.SetBool("IsMoving", true);          
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GameService.Instance.SoundService.PlayFootStep();
            playerView.rb.velocity = new Vector2(-playerModel.movingspeed, playerView.rb.velocity.y);
            playerView.rbSprite.flipX = true;
            playerView.animator.SetBool("IsMoving", true);           
        }
        else
        {
            GameService.Instance.SoundService.StopFootStep();
            playerView.rb.velocity = new Vector2(0f, playerView.rb.velocity.y);
            playerView.animator.SetBool("IsMoving", false);           
        }
    }
    private void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !playerModel.issliding && !playerModel.isjumping)
        {
            GameService.Instance.SoundService.PlaySound(Sounds.JumpSound);
            playerView.rb.velocity = new Vector2(playerView.rb.velocity.x, playerModel.jumpspeed);
            playerView.animator.SetBool("IsJumping", true);
            playerModel.isjumping = true;
        }
    }   
    private void SlidePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !playerModel.isjumping && !playerModel.issliding)
        {
            GameService.Instance.SoundService.PlaySound(Sounds.SlideSound);
            playerModel.issliding = true;
            playerView.animator.SetBool("IsSliding", true);
            playerModel.movingspeed = playerModel.slidingspeed;
        }
    }   
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !playerModel.issliding && !playerModel.isjumping & !playerModel.isjumping)
        {
            GameService.Instance.SoundService.PlaySound(Sounds.AttackSound);
            playerView.animator.SetBool("IsAttacking", true);
            playerView.attackhitbox.enabled = true;
            playerView.attackhitbox.transform.localPosition = new Vector2(playerView.rbSprite.flipX ? -2.5f : 0f, playerView.attackhitbox.transform.localPosition.y);           
        }
    }  
    private void TurnOffAttack()
    {
        playerView.animator.SetBool("IsAttacking", false);
        playerView.attackhitbox.enabled = false;
    } 
    private void TurnOffJump()
    {
        playerView.animator.SetBool("IsJumping", false);
        playerModel.isjumping = false;
    } 
    private void TurnOffSlide()
    {
        playerModel.issliding = false;
        playerModel.movingspeed = playerModel.defaultspeed;
        playerView.animator.SetBool("IsSliding", false);
    }
   
    public void TakeDamage(int damagerate)
    {
        playerModel.playerhealth -= (damagerate*Time.deltaTime);
    }    
    private void UpdateHealthBar()
    {
        if (playerView.healthbar.fillAmount >= 0)
        {
            playerView.healthbar.fillAmount = playerModel.playerhealth / 100f;
        }
    }

    private void LevelLost()
    {
        if (playerModel.playerhealth <= 0)
        {
            GameService.Instance.SoundService.PlaySound(Sounds.DeathSound);           
        }
    }
}
