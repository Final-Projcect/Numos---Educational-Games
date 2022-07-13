using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUnACtive : MonoBehaviour
{
   
    public GameObject CurrentObject;
    public string Player;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Player)
        {
            CurrentObject.SetActive(false);
        }
    }
}
