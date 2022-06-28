using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landing : MonoBehaviour
{
    public string land;
    public GameObject boat;
    public GameObject boat2;
    public int num;
    private void OnTriggerStay2D(Collider2D collision)
    {
        // poski = new InventoryItem(positem.GetComponent<SpriteRenderer>().sprite, 1, 1, "Posking", "postion for king");
        //InvatoryForUSe.GetComponent<InventoryGUI>().additem(poski);

        if (collision.gameObject.tag == land)
        {
            if (num == 1)
            {
                boat.GetComponent<SpriteRenderer>().enabled = false;
            }

            else if (num == 2)
            {
                boat2.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
