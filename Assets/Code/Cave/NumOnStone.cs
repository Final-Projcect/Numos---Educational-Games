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

    public int NumAtSign()
    {

        int NumberOnStone;
        textfind = this.GetComponentInChildren<TextMeshProUGUI>();
        NumberOnStone = Convert.ToInt32(textfind.text);
        Debug.Log("i am a stone of: " + NumberOnStone);
        unCheck = true;
        return NumberOnStone;


    }

}
