using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void LoadMenu()
    {
        SoundManager.Instance.PlaySound(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
    public void LoadNext()
    {
        SoundManager.Instance.PlaySound(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SoundManager.Instance.PlaySound(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        SoundManager.Instance.PlaySound(Sounds.ButtonClick);
        Application.Quit();
    }
}
