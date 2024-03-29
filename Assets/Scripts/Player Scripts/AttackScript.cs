using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<GiveDamage>() != null)
        {
            SoundManager.Instance.PlaySound(Sounds.LightOffSound);
            GiveDamage givedamageobj = collision.gameObject.GetComponent<GiveDamage>();
            givedamageobj.objectlife--;           
        }
    }
}
