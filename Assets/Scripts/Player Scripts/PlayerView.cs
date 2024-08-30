using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public BoxCollider2D attackhitbox;
    public Animator animator;   
    public Rigidbody2D rb;
    public SpriteRenderer rbSprite;
    private PlayerControler playerControler;
    [HideInInspector]public Image healthbar;
    [HideInInspector]public Vector3 SpawnPoint;
    [HideInInspector]public Transform parentTransform;
    
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
        parentTransform = transform.parent;
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
    private void OnTriggerEnter2D(Collider2D collision)=>playerControler?.OnTriggerEnter2D(collision);

}

