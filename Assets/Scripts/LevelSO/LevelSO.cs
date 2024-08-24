using UnityEngine;

[CreateAssetMenu (menuName = "LevelScriptableObject")]
public class LevelSO : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private GameObject levelObject;
    
    public int Level => level;
    public GameObject LevelObject => levelObject;
}
