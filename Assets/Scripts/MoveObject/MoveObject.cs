using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Transform BaseObject;
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;    
    [SerializeField] private float MovingSpeed;
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
            return PointA.position;
        }
        else
        {
            return PointB.position;
        }
    }
}
