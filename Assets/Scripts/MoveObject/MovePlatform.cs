using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MovePlatform : MonoBehaviour
{
    //[SerializeField] internal int Platformlive = 3;
   // [SerializeField] private float damagerate = 1f;
    //[SerializeField] private Light2D light2d;
    /*public static MovePlatform instance;
    private void Awake()
    {
        instance = this;
    } 
    private void Update()
    {
        DisableLight();
    }
    private void DisableLight()
    {
        if(Platformlive <= 0)
        {
            light2d.enabled = false;
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            collision.transform.SetParent(this.transform);
            /*if (Platformlive != 0)
            {
                PlayerControler.instance.playerhealth -= (damagerate * Time.deltaTime);
                Debug.Log("Player HP : " + PlayerControler.instance.playerhealth);
            }*/
        }       
    }  
    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {       
            if (Platformlive != 0)
            {
                PlayerControler.instance.playerhealth -= (damagerate * Time.deltaTime);
                Debug.Log("Player HP : " + PlayerControler.instance.playerhealth);
            }
        }
    }*/
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            collision.transform.SetParent(null);            
        }
    }
}
