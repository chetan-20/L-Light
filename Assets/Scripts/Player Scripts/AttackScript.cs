using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<GiveDamage>() != null)
        {
            GiveDamage givedamageobj = collision.gameObject.GetComponent<GiveDamage>();
            givedamageobj.objectlife--;
            Debug.Log("Object Lives : " + givedamageobj.objectlife);
        }
    }
}
