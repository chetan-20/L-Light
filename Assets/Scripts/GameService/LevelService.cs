using UnityEngine;

public class LevelService : MonoBehaviour
{
    [SerializeField] private LevelSO[] levels;
    private int currentLevelNumber=0;
    private GameObject activeLevel;
    public int CurrentLevelNumber => currentLevelNumber;
    private void Start()
    {
        GameService.Instance.UIService.OnGameWon += DestroyCurrentLevel;
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
    }
    public void ResetLevelNumber() => currentLevelNumber = 0;
}
