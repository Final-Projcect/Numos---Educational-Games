using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCode : MonoBehaviour
{
    public string obstic;
    public MovmentATLanderyShocks movment;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == obstic)
        {
            Debug.LogError("im in");
           Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == obstic)
        {
            
            Destroy(collision.gameObject);
            movment.sockDown = true;
            movment.fireOn = false;
        }
    }
}
