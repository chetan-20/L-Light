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
    [SerializeField] private Button restartButton1;
    [SerializeField] private Button restartButton2;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject menuObject;
    [SerializeField] private GameObject levelWonObject;
    [SerializeField] private GameObject levellostObject;
    [SerializeField] private GameObject healthObject;   
    public Image greenHealthBar;
    public event Action OnGameWon;
    public event Action OnGameLost;
    private void OnEnable()
    {
        OnGameWon += OnLevelWin;
        OnGameLost += OnLevelLost;
    }
    private void Start()
    {
        SetButtons();      
    }
    private void SetButtons()
    {
        playButton.onClick.AddListener(LoadNextLevel);
        muteButton.onClick.AddListener(GameService.Instance.SoundService.ToggleMute);
        nextButton.onClick.AddListener(LoadNextLevel);
        quitButton.onClick.AddListener(QuitGame);
        menuButton1.onClick.AddListener(LoadMenu);      
        restartButton1.onClick.AddListener(RestartLevel);
        restartButton2.onClick.AddListener(RestartLevel);
    }
    private void LoadMenu()
    {
        GameService.Instance.SoundService.PlayClickSound();
        GameService.Instance.LevelService.ResetLevelNumber();
        DisableUIPanels();
        menuObject.SetActive(true);               
    }
    private void LoadNextLevel()
    {
        GameService.Instance.SoundService.PlayClickSound();
        GameService.Instance.LevelService.SpawnLevel(GameService.Instance.LevelService.CurrentLevelNumber+1);
        DisableUIPanels();
        healthObject.SetActive(true);        
    }
    private void RestartLevel()
    {
        GameService.Instance.SoundService.PlayClickSound();
        DisableUIPanels();
        greenHealthBar.fillAmount = 100f;
        healthObject.SetActive(true);
        GameService.Instance.LevelService.SpawnLevel(GameService.Instance.LevelService.CurrentLevelNumber);
    }
    private void QuitGame()
    {
        GameService.Instance.SoundService.PlayClickSound();
        Application.Quit();
    }
    public void InvokeGameWon()=>OnGameWon?.Invoke();
    public void InvokeGameLost()=>OnGameLost?.Invoke();
    private void OnLevelWin()
    {              
        levelWonObject.SetActive(true);
        healthObject.SetActive(false);       
    }
    private void OnLevelLost()
    {
        levellostObject.SetActive(true);
        healthObject.SetActive(false);
    }
    private void DisableUIPanels()
    {
        menuObject.SetActive(false);
        levellostObject.SetActive(false);
        levelWonObject.SetActive(false);
        healthObject.SetActive(false);
    }
    private void OnDisable()
    {
        OnGameWon -= OnLevelWin;
        OnGameLost -= OnLevelLost;
    }
}
