using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    private float damagerate = 3f;
    private bool isinrange = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            isinrange = true;                     
        }                   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isinrange)
        {
            Givedamage();
            Debug.Log("Player HP : " + PlayerControler.instance.playerhealth);
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
}
