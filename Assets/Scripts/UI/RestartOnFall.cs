using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            GameService.Instance.SoundService.PlaySound(Sounds.DeathSound);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
