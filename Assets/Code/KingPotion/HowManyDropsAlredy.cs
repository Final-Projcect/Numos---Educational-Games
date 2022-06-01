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
        //textfind.text = drops.ToString();
        textfind.text = (drops/2).ToString();
    }




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
        textfind.text = (drops/2).ToString();
       // textfind.text = (drops).ToString();
    }

    private void Start()
    {
        textfind.text = (drops/2).ToString();
    }

    //public void Start()
    // {
    //      textfind.text = drops.ToString();
    //}
}
