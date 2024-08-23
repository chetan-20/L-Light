using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button muteButton;
    [SerializeField] private Button menuButton1;
    //[SerializeField] private Button menuButton2(pause menu);
    [SerializeField] private Button restartButton1;
    [SerializeField] private Button restartButton2;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject menuObject;
    [SerializeField] private GameObject levelWonObject;
    [SerializeField] private GameObject levellostObject;
    private event Action OnGameWon;
    private void OnEnable()
    {
        OnGameWon += OnLevelWin;
    }
    private void Start()
    {
        SetButtons();      
    }
    private void SetButtons()
    {
        playButton.onClick.AddListener(LoadNext);
        muteButton.onClick.AddListener(GameService.Instance.SoundService.ToggleMute);
        quitButton.onClick.AddListener(QuitGame);
        menuButton1.onClick.AddListener(LoadMenu);
        //menuButton2.onClick.AddListener(LoadMenu);
        restartButton1.onClick.AddListener(RestartLevel);
        restartButton2.onClick.AddListener(RestartLevel);
    }
    private void LoadMenu()
    {
        GameService.Instance.SoundService.PlayClickSound();
        SceneManager.LoadScene(0);
    }
    private void LoadNext()
    {
        GameService.Instance.SoundService.PlayClickSound();
        levelWonObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
    private void RestartLevel()
    {
        GameService.Instance.SoundService.PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void QuitGame()
    {
        GameService.Instance.SoundService.PlayClickSound();
        Application.Quit();
    }
    public void InvokeGameWon()=>OnGameWon?.Invoke();
    private void OnLevelWin()
    {        
        Time.timeScale = 0f;
        levelWonObject.SetActive(true);
    }
    private void OnDisable()
    {
        OnGameWon -= OnLevelWin;
    }
}
