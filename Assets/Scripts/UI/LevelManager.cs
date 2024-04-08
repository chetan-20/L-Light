using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject LevelLostPanel;
    [SerializeField] private GameObject LevelWonPanel;
    [SerializeField] private GameObject LevelObject;
    [SerializeField] private GameObject HealthUI;
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void OnGameWon()
    {
        SoundManager.Instance.PlaySound(Sounds.LevelCompleteSound);
        Time.timeScale = 0f;
        LevelObject.SetActive(false);
        LevelLostPanel.SetActive(false);
        HealthUI.SetActive(false);
        LevelWonPanel.SetActive(true);
    }
    public void OnGameLost()
    {
        SoundManager.Instance.PlaySound(Sounds.DeathSound);
        Time.timeScale = 0f;
        LevelObject.SetActive(false);
        LevelLostPanel.SetActive(true);
        HealthUI.SetActive(false);
        LevelWonPanel.SetActive(false);
    }
}
