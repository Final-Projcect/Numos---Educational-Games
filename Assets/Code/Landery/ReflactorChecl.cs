using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReflactorChecl : MonoBehaviour
{
    public int TheNumberOfSocks;
    public string Shock;
    public int[] DoubleShock = new int[2];
    public ShocksNum shock;
    Stack<int> AlradyGreat = new Stack <int>();
    public int counter;
    public TextMeshProUGUI textdisplay;
    public GameObject gold;
    public bool goldtaken = false;
    public GameObject exit;
    public bool firstaken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Shock)
        {
            Debug.Log(16);
            if (DoubleShock[0]==-1)
            {
                Debug.Log(17);
                TheNumberOfSocks = collision.gameObject.GetComponent<ShocksNum>().shocksnumber;
                DoubleShock[0] = TheNumberOfSocks;
            }

            else if (DoubleShock[1]==-2)
            {
                Debug.Log(24);
                TheNumberOfSocks = collision.gameObject.GetComponent<ShocksNum>().shocksnumber;
                DoubleShock[1] = TheNumberOfSocks;
            }

            else if (DoubleShock[0]!=-1&&DoubleShock[1]!=-2)
            {
                Debug.Log(32);
                if (DoubleShock[0] == DoubleShock[1])
                {
                    counter++;
                    if (AlradyGreat.Contains(DoubleShock[0]) == false && counter<2)
                    {
                        Debug.LogError("great");
                        textdisplay.text = "<u> הרפלקטור:</u> מעולה הצלחת להשיג" + (counter) + "זוגות מתוך 2 זוגות" + "\n" + "אשמח אם הגרב תועבר למקום אחור יותר שלא נמצא סביבי";
                        AlradyGreat.Push(DoubleShock[0]);
                        Debug.Log(counter + "line 49");
                        
                        Debug.Log(counter + "line 51");
                        resetArray();
                        resetArray(); 
                    }

                    if (counter == 2)
                    {
                        textdisplay.text = "<u> הרפלקטור:</u> תודה רבה על עזרתך הרבה! מצרף לידך שי קטן של מטבעות שיקלו על מסעך";
                        gold.SetActive(true);
                        exit.SetActive(true);
                        Debug.Log("you done!!!");
                    }

                    


                }
                else
                {
                    resetArray();
                    resetArray();
                    // resetArray();
                    textdisplay.text = "<u> הרפלקטור:</u> חוששני שהבאת לי גרביים לא תואמות, נסה שנית"  +"\n" + "אשמח אם הגרב תועבר למקום אחר";
                     Debug.LogError("bed");
                }



            }

           
        }
    }


    private void Start()
    {
        resetArray();
    }

    public void resetArray()
    {
        DoubleShock[0] = -1;
        DoubleShock[1] = -2;
        Debug.Log("we are reseted");
    }
    /*
     *     else if (alradyCounted <= 2)
            {
                if (DoubleShock[alradyCounted] == TheNumberOfSocks)
                {
                    Debug.Log(73);
                    alradyCounted++;
                    DoubleShock[alradyCounted] = TheNumberOfSocks;


                }
                else
                {
                    alradyCounted = 0;
                    reSetArray();
                }
            }

            else if (alradyCounted == 0)
            {
                Debug.Log(87);
                DoubleShock[0] = TheNumberOfSocks;
                alradyCounted++;

            }

            else if (alradyCounted == 2)
            {
                if(DoubleShock[0] == TheNumberOfSocks && DoubleShock[1] ==TheNumberOfSocks)
                {
                    Debug.Log("great");
                }
            }
     */
}
