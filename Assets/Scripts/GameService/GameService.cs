using UnityEngine;

public class GameService : MonoBehaviour
{  
    [SerializeField] private SoundService soundService;
    [SerializeField] private PopUpService popUpService;
    [SerializeField] private UIService uiService;
    [SerializeField] private LevelService levelService;
    public SoundService SoundService { get { return soundService; } }
    public PopUpService PopUpService { get { return popUpService; } }
    public UIService UIService { get { return uiService; } } 
    public LevelService LevelService { get { return levelService; } }
    private static GameService instance;
    public static GameService Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;           
        }
        else
        {
            Destroy(gameObject);
        }
    }  
    
}
