using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private int Platformlive = 2;
    [SerializeField] private float damagerate = 1f;
    [SerializeField] private Light2D light2d;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            collision.transform.SetParent(this.transform);
            if (Platformlive != 0)
            {
                PlayerControler.instance.playerhealth -= (damagerate * Time.deltaTime);
                Debug.Log("Player HP : " + PlayerControler.instance.playerhealth);
            }
        }
        else if(collision.gameObject.GetComponent<PlayerControler>().attackhitbox != null)
        {
            Platformlive--;
            Debug.Log("Platform Live : " + Platformlive);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {       
            if (Platformlive != 0)
            {
                PlayerControler.instance.playerhealth -= (damagerate * Time.deltaTime);
                Debug.Log("Player HP : " + PlayerControler.instance.playerhealth);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            collision.transform.SetParent(null);            
        }
    }
}
