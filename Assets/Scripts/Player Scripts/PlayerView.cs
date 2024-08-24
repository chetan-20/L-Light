using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private BoxCollider2D attackhitbox;
    [SerializeField] private Animator animator;
    public static PlayerControler instance;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
}
