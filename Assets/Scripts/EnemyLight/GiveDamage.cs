using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GiveDamage : MonoBehaviour
{
    [SerializeField] private float damagerate = 3f;
    [SerializeField] internal int objectlife = 3;
    [SerializeField] private Light2D light2d;
    private bool isinrange = false;   
    private void Update()
    {
        DisableLight();
    }       
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            isinrange = true;                     
        }                   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isinrange && objectlife>0)
        {
            Givedamage();          
        }
    } 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            isinrange = false;
        }
    } 
    private void Givedamage()
    {
        PlayerControler.instance.playerhealth -= (damagerate * Time.deltaTime);
    } 
    private void DisableLight()
    {
        if (objectlife <= 0)
        {
            light2d.enabled = false;
        }
    }
}
