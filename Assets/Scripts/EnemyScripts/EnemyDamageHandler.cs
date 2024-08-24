using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyDamageHandler : MonoBehaviour
{
    [SerializeField] private int damagerate = 3;
    [SerializeField] private int objectlife = 3;
    [SerializeField] private Light2D light2d;
    private bool isinrange = false;   
    private void Update()
    {
        DisableLight();
    }
    public void TakeDamage()
    {
        objectlife--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() != null)
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
        if (collision.gameObject.GetComponent<PlayerView>() != null)
        {
            isinrange = false;
        }
    }
    private void Givedamage()
    {
       GameService.Instance.PlayerController.TakeDamage(damagerate);
    }
    private void DisableLight()
    {
        if (objectlife <= 0)
        {
            light2d.enabled = false;
        }
    }
}
