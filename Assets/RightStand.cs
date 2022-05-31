using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RightStand : MonoBehaviour
{
    public string player;
    public TextMeshProUGUI textdisplay;
    public bool right = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == player)
        {
            right = true;
            Debug.Log("yu are the one");
        }
    }
}
