using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Transform BaseObject;
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;    
    [SerializeField] private float MovingSpeed;
    [SerializeField] private SpriteRenderer sprite;   
    private int direction = 1;
    
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector2 Target = CurrentTarget();
        BaseObject.position = Vector2.Lerp(BaseObject.position, Target, MovingSpeed * Time.deltaTime);
        float distance = (Target - (Vector2)BaseObject.position).magnitude;
        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }
    private Vector2 CurrentTarget()
    {
        if (direction == 1)
        {
            sprite.flipX = false;
            return PointA.position;           
        }
        else
        {
            sprite.flipX = true;
            return PointB.position;            
        }
    }
}
