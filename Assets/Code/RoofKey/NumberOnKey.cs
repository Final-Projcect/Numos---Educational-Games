using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOnKey : MonoBehaviour
{
    public string number;

    public int NumAtKey()
    {
        int numofkey;
        //numofkey = Convert.ToInt32(number);
        int.TryParse(number, out numofkey);
        Debug.Log("i am a: " + numofkey);
        return numofkey;
    }
}
