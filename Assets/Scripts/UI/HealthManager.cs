using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthbar;

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthbar.fillAmount >= 0)
        {
            healthbar.fillAmount = PlayerControler.instance.playerhealth / 100f;
        }
    }
}
