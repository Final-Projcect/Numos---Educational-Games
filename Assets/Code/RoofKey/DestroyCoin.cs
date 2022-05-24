﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    public string Player;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Player)
        {
            Destroy(gameObject);
        }
    }
}