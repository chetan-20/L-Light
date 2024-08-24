
using UnityEngine;

public class LevelService : MonoBehaviour
{
    [SerializeField] private LevelSO[] levels;
    private int currentLevelNumber=0;
    private LevelSO activeLevel;
    public int CurrentLevelNumber => currentLevelNumber;
   
    public void SpawnLevel(int levelNumber)
    {
        activeLevel = FindLevel(levelNumber);
        if (activeLevel != null)
        {
            Instantiate(activeLevel.LevelObject);
            currentLevelNumber = activeLevel.Level;
        }
        else
        {
            Debug.Log("Level Not Found");
        }
    }
    public LevelSO GetLevel()//maybe make destroy level method here
    {
        if (activeLevel == null) return null;
        return activeLevel;
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
