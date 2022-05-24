using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutKey : MonoBehaviour
{
    
    public string sign;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == sign)
        {
            Debug.Log("stand on sign");
            int sign = collision.gameObject.GetComponent<NumberOnSign>().NumAtSign();


            /*int asnum = findNum.numonkey();

            //check if the number on sign and number on key are same
            if (asnum == sign)
            {
                Debug.Log("same is it");
                Destroy(gameObject.GetComponent<TakeAKey>());
            }*/
        }
    }


}

