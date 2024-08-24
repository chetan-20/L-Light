using UnityEngine;

public class LevelWinTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() != null)
        {
            GameService.Instance.SoundService.PlaySound(Sounds.LevelCompleteSound);
            GameService.Instance.UIService.InvokeGameWon();
        }
    }
}
