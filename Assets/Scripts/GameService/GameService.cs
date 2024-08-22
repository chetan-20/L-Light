using UnityEngine;

public class GameService : MonoBehaviour
{
    [SerializeField] private GameObject levelObject;
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
    private void Start()
    {
        EnableLevel(false);
    }
    public SoundService GetSoundService() => soundService;
    public PopUpService GetPopUpService() => popUpService;
    public void EnableLevel(bool status) => levelObject.SetActive(status);
}
