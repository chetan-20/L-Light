using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField]private float amplitude = 45f;
    [SerializeField]private float speed = 1f;
    [SerializeField]private Vector2 pivotPoint;

    private void Update()
    {
        // Calculate the angle based on time and speed
        float angle = Mathf.Sin(Time.time * speed) * amplitude;
        Vector2 newPosition = pivotPoint + new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
        transform.position = newPosition;
    }

}
