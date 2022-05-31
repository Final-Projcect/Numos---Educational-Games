using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WrongStand : MonoBehaviour
{
    public string player;
    public TextMeshProUGUI textdisplay;
    public bool right = false;

    private void Start()
    {
        Debug.Log("line 11");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == player)
        {
           // textdisplay.text =  "תנסה שוב, עלית על הקרש הפסל הלא נכון";
        }
    }
}