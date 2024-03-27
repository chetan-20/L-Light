using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{   
    [SerializeField] private float speed = 1f;
    [SerializeField] private float minRotation = 140f;
    [SerializeField] private float maxRotation = 220f;
    private void Update()
    {      
        float angle = Mathf.Sin(Time.time * speed);       
        float rotation = Mathf.Lerp(minRotation, maxRotation, (angle+1f)/2f);        
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}
