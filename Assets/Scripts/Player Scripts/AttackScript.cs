using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        collision.gameObject.TryGetComponent(out  EnemyDamageHandler enemy);
        if (enemy != null)
        {
            enemy.TakeDamage();
        }        
    }
}
