using UnityEngine;

[CreateAssetMenu (menuName = "LevelScriptableObject")]
public class LevelSO : ScriptableObject
{
    public int level;
    public GameObject levelObject;     
}
