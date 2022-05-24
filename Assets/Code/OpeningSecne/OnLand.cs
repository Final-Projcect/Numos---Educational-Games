using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLand : MonoBehaviour
{
    public string ship;
    public bool onl = false;
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == ship)
        {
            onl = true;
        }
    }
}
