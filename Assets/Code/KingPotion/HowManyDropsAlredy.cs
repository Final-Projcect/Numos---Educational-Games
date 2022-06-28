using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HowManyDropsAlredy : MonoBehaviour
{
    public TextMeshProUGUI textfind;
    bool unCheck = true;
    bool text = false;
    public int drops = 0;
    public bool takedrop = false;
    public string player;

    public string potion;
    //public string color;
    public GameObject potions;

    public int numatbag()
    {
        int numatbag;
        //textfind = this.GetComponentInChildren<TextMeshProUGUI>();
        numatbag = Convert.ToInt32(textfind.text);
        Debug.Log("i am a: " + numatbag);
        unCheck = true;
        return numatbag;

    }

    public int dropsinbag()
    {

        return drops;

    }

    public void reset()
    {
        drops = 0;
        textfind.text = drops.ToString();
        //textfind.text = (drops/2).ToString();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == player)
        {
            Debug.Log("49");
            //if (Input.GetKeyDown(KeyCode.T) || Input.GetKey("t"))
            if (Input.GetKeyDown(KeyCode.T) )
            //if (Input.GetKeyDown(KeyCode.Z))
            {
                takedrop = false;
               // droptake = collision.gameObject.GetComponent<HowManyDropsAlredy>().takedrop = false;
                Debug.Log("167");
                incresedrop();
                Debug.Log("180");
                Debug.Log("enter h");
            }

            else if (Input.GetKeyDown(KeyCode.H) || Input.GetKey("h"))
            {
                Debug.Log("push t");
                takedrop = false;
            }

           
        }
    }

   /* private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == player)
        {
            Debug.Log("49");
            if (Input.GetKeyDown(KeyCode.T) || Input.GetKey("t"))
            //if (Input.GetKeyDown(KeyCode.Z))
            {
                takedrop = false;
                // droptake = collision.gameObject.GetComponent<HowManyDropsAlredy>().takedrop = false;
                Debug.Log("167");
                incresedrop();
                Debug.Log("180");
                Debug.Log("enter h");
            }

            else if (Input.GetKeyDown(KeyCode.H) || Input.GetKey("h"))
            {
                Debug.Log("push t");
                takedrop = false;
            }


        }
    }*/



    public void incresedrop()
    {
        Debug.Log(48);
        if (takedrop == false)
        {
            drops = drops + 1;
            Debug.Log("you have a drop");
            takedrop = true;
        }
        else
        {
            takedrop = true;
        }
        Debug.Log(54);
        
        Debug.Log("the bag have: " + drops);
        //textfind.text = (drops/2).ToString();
        textfind.text = (drops).ToString();
    }

    private void Start()
    {
        //textfind.text = (drops/2).ToString();
        textfind.text = (drops).ToString();
    }

    //public void Start()
    // {
    //      textfind.text = drops.ToString();
    //}
}
