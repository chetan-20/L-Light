using UnityEngine;


public class PlatformChildManager : MonoBehaviour
{    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() != null)
        {
            collision.transform.SetParent(this.transform);           
        }       
    }  
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() != null)
        {
            collision.transform.SetParent(null);            
        }
    }
}
