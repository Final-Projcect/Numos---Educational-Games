using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumOnking : MonoBehaviour
{
    private TextMeshProUGUI textfind;
    public int NumAtking()
    {
        int NumberOfSign;
        textfind = this.GetComponentInChildren<TextMeshProUGUI>();
        NumberOfSign = Convert.ToInt32(textfind.text);
        Debug.Log("i am a: " + NumberOfSign);
        return NumberOfSign;


    }
}
