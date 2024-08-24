
using UnityEngine;

public class LevelService : MonoBehaviour
{
    [SerializeField] private LevelSO[] levels;
    private int currentLevelNumber=0;
    public int CurrentLevelNumber => currentLevelNumber;
   
    public void SpawnLevel(int levelNumber)
    {
        LevelSO currentLevel = FindLevel(levelNumber);
        if (currentLevel != null)
        {
            Instantiate(currentLevel.LevelObject);
            currentLevelNumber = currentLevel.Level;
        }
        else
        {
            Debug.Log("Level Not Found");
        }
    }
    public LevelSO GetLevel()
    {
        LevelSO currentlevel = FindLevel(currentLevelNumber);
        if(currentlevel != null) { return currentlevel; }
        return null;
    }
    private LevelSO FindLevel(int levelNumber)
    {
        foreach (LevelSO data in levels)
        {
            if (data.Level == levelNumber)
            {
                return data;
            }
        }
        return null;
    }
}
