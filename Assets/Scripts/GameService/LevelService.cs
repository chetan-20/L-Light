using UnityEngine;

public class LevelService : MonoBehaviour
{
    [SerializeField] private LevelSO[] levels;
    private int numberOfLevels;
    private int currentLevelNumber=0;
    private GameObject activeLevel;
    public int CurrentLevelNumber => currentLevelNumber;
    private void Start()
    {
        GameService.Instance.UIService.OnGameWon += DestroyCurrentLevel;
        GameService.Instance.UIService.OnGameLost += DestroyCurrentLevel;
        numberOfLevels = levels.Length;
    }
    public void SpawnLevel(int levelNumber)
    {
        GameObject levelPrefab = FindLevel(levelNumber);
        if (levelPrefab != null)
        {
            activeLevel = Instantiate(levelPrefab);           
        }
        else
        {
            Debug.Log("Level Not Found");
        }
    }
    private void DestroyCurrentLevel()
    {
      Destroy(activeLevel);
    }
    private GameObject FindLevel(int levelNumber)
    {
        foreach (LevelSO data in levels)
        {
            if (data.level == levelNumber)
            {
                currentLevelNumber = data.level;
                return data.levelObject; 
                
            }
        }
        return null;
    }
    private void OnDisable()
    {
        GameService.Instance.UIService.OnGameWon -= DestroyCurrentLevel;
        GameService.Instance.UIService.OnGameLost -= DestroyCurrentLevel;
    }
    public void LoadNextLevel()
    {
        if ( CurrentLevelNumber + 1 <= numberOfLevels)
        {
            SpawnLevel(CurrentLevelNumber + 1);
        }
        else
        {
            GameService.Instance.UIService.LoadMenu();
        }
    }
    public void ResetLevelNumber() => currentLevelNumber = 0;
}
