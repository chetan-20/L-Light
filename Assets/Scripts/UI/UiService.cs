using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button muteButton;
    //[SerializeField] private Button menuButton;
    //[SerializeField] private Button restartButton;
    [SerializeField] private GameObject menuObject;
    //[SerializeField] private GameObject levelWonObject;
    //[SerializeField] private GameObject levellostObject;   
    private void Start()
    {
        SetButtons();
    }
    private void SetButtons()
    {
        playButton.onClick.AddListener(LoadNext);
        muteButton.onClick.AddListener(GameService.Instance.GetSoundService().ToggleMute);
        quitButton.onClick.AddListener(QuitGame);
        //menuButton.onClick.AddListener(LoadMenu);
        //restartButton.onClick.AddListener(RestartLevel);
    }
    private void LoadMenu()
    {
        GameService.Instance.GetSoundService().PlayClickSound();
        SceneManager.LoadScene(0);
    }
    private void LoadNext()
    {
        GameService.Instance.GetSoundService().PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void RestartLevel()
    {
        GameService.Instance.GetSoundService().PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void QuitGame()
    {
        GameService.Instance.GetSoundService().PlayClickSound();
        Application.Quit();
    }  
}
