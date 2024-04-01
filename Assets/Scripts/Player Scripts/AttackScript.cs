using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {                 
        GiveDamage givedamageobj = collision.gameObject.GetComponent<GiveDamage>();
        if (givedamageobj != null)
        {
            givedamageobj.objectlife--;           
        }
    }
}
