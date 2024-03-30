using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] protected Transform BaseObject;
    [SerializeField] protected Transform PointA;
    [SerializeField] protected Transform PointB;    
    [SerializeField] protected float MovingSpeed;
    [SerializeField] protected SpriteRenderer sprite;   
    private int direction = 1;
    
    void Update()
    {
        Vector2 Target = CurrentMovementTarget();
        BaseObject.position = Vector2.Lerp(BaseObject.position, Target, MovingSpeed * Time.deltaTime);
        float distance = (Target - (Vector2)BaseObject.position).magnitude;
        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }
    private Vector2 CurrentMovementTarget()
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
