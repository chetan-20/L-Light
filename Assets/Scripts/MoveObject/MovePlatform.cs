using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MovePlatform : MonoBehaviour
{    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            collision.transform.SetParent(this.transform);           
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
