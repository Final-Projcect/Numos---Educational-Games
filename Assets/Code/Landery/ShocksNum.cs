using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShocksNum : MonoBehaviour
{
    public int shocksnumber;
    public string Player;
    public string handler;
    public bool alradyclicked = false;
    public MovmentATLanderyShocks movment;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Player)
        {
            movment.TheNumberOfSocks = shocksnumber;
           
            movment.sockDown = true;
            if (alradyclicked == false)
            {
                movment.ShocksShow();
                Debug.Log(shocksnumber);
                alradyclicked = true;
            }
            
        }

        if (collision.gameObject.tag == handler)
        {
            Destroy(collision.gameObject);
            this.gameObject.transform.position = new Vector3(transform.position.x, -5, transform.position.z);
            movment.fireOn = false;
        }
    }
}
