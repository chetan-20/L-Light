using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerView pView = collision.gameObject.GetComponent<PlayerView>();
        if(pView != null)      
        {
            GameService.Instance.SoundService.PlaySound(Sounds.DeathSound);
            pView.transform.position = pView.SpawnPoint;
        }
    }
}
