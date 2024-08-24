using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public BoxCollider2D attackhitbox;
    public Animator animator;   
    public Rigidbody2D rb;
    public SpriteRenderer rbSprite;
    public Image healthbar;
    public Vector3 SpawnPoint;
    private PlayerControler playerControler;
    private void Awake()
    {
        playerControler = new PlayerControler(this);
    }
    private void Start()
    {
        GameService.Instance.SetCurrentPlayerController(playerControler);
        playerControler.Start();
        healthbar = GameService.Instance.UIService.greenHealthBar;
        SpawnPoint = transform.position;
    }
    private void Update()
    {
        if(playerControler != null)
        {
            playerControler.Update();
        }
    }
    public void TurnOffAttack()=>playerControler.TurnOffAttack();
    public void TurnOffSlide()=>playerControler.TurnOffSlide();
    public void TurnOffJump()=>playerControler.TurnOffJump();
}
