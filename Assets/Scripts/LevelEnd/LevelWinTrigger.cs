using UnityEngine;

public class LevelWinTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameService.Instance.SoundService.PlaySound(Sounds.LevelCompleteSound);
        GameService.Instance.UIService.InvokeGameWon();
    }
}
