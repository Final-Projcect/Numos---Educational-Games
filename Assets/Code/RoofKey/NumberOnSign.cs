using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberOnSign : MonoBehaviour
{
    TextMeshProUGUI textfind;
    bool unCheck = true;
    bool text = false;

    public int NumAtSign()
    {
        //if (unCheck == false)
        //{
            int NumberOfSign;
            textfind = this.GetComponentInChildren<TextMeshProUGUI>();
            NumberOfSign = Convert.ToInt32(textfind.text);
            Debug.Log("i am a: " + NumberOfSign);
            unCheck = true;
            return NumberOfSign;
       // }
       // else
        //{
       //     return 29;
       // }

    }

    public void AlradyUsed()
    {
        textfind.text = "כל הכבוד";
        //text = true;
       // unCheck = true;

    }

    public void GonnaBeDone()
    {
        //textfind.text = "עוד קצת והדלת פתוחה";
        unCheck = false;
    }

    public bool isText()
    {
        textfind = this.GetComponentInChildren<TextMeshProUGUI>();
        if (textfind.text == "כל הכבוד")
        {
            return true;
        }
        else
            return false;
    }

    public int Divisors(int num)
    {
        List<int> divisors = new List<int>();

        if (num < 2)
        {
            return 1;
        }

        else if (IsPrime(num))
        {
          return 2;
        }

        else
        {
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    divisors.Add(i);
        }

        return divisors.Count;
    }


    public Stack<int> TheDivisiors(int num)
    {
        Stack<int> divisors = new Stack<int>();

        if (num < 2)
        {
            divisors.Push(1);
            return divisors;
        }

        else if (IsPrime(num))
        {
            divisors.Push(num);
            divisors.Push(1);
            return divisors;
        }

        else
        {
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    divisors.Push(i);
        }

        return divisors;
    }

    public int NumberToOpen (int num)
    {
        if (num > 0)
        {
            return num--;
        }

        else
            return 0;
        
    }

    public static bool IsPrime(int n)
    {
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        for (int x = 3; x * x <= n; x += 2)
            if (n % x == 0)
                return false;

        return true;
    }
}