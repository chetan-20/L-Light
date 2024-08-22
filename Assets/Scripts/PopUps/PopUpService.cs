using System.Collections;
using TMPro;
using UnityEngine;

public class PopUpService : MonoBehaviour
{
    [SerializeField] public TMP_Text popUpMsgText;
    [SerializeField] public GameObject popUpMsgGameobject;
    private Coroutine currentCoroutine;

    public float popUpMsgDelay = 3f;

    private void Start()
    {
        popUpMsgGameobject.SetActive(false);
    }

    public IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(popUpMsgDelay);
        popUpMsgGameobject.SetActive(false);
        currentCoroutine = null;
    }
    public void ShowPopupMessage(string message)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        popUpMsgGameobject.SetActive(true);
        popUpMsgText.text = message;
        currentCoroutine = StartCoroutine(DisableAfterDelay());
    }
}
