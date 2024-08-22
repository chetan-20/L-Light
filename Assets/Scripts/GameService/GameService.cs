using UnityEngine;

public class GameService : MonoBehaviour
{  
    [SerializeField] private SoundService soundService;
    [SerializeField] private PopUpService popUpService;
    private static GameService instance;
    public static GameService Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }  
    public SoundService GetSoundService() => soundService;
    public PopUpService GetPopUpService() => popUpService;
  
}
