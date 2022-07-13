using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumOnStone : MonoBehaviour
{
    TextMeshProUGUI textfind;
    bool unCheck = true;
    bool text = false;
    public string zero;
    public string one;
    public string two;
    public string threr;
    public string four;
    public string five;

    public int NumAtSign()
    {

        int NumberOnStone;
        textfind = this.GetComponentInChildren<TextMeshProUGUI>();
        NumberOnStone = Convert.ToInt32(textfind.text);
        Debug.Log("i am a stone of: " + NumberOnStone);
        unCheck = true;
        String place = Area(NumberOnStone);
        return NumberOnStone;


    }

    public string Area(int num)
    {
        if (num < 0)
        {
            if (num <= 0 && num > -10)
            {
                return "011";
            }

            else if (num <= -10 && num > -20)
            {
                return ("2010");
            }

            else if (num <= -20 && num >= -30)
            {
                return ("3020");
            }
        }

        else if (num > 0)
        {
            if (num > 0 && num < 10)
            {
                return ("110");
            }

            else if (num >= 10 && num < 20)
            {
                return ("1020");
            }

            else if (num >= 20 && num <= 30)
            {
                return ("2030");
            }
        }
        return ("0");
    }

}
