using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeAStone : MonoBehaviour
{
    public TextMeshProUGUI textdisplay;
    public string stone;
    //public string LaFarmaTag;
    public GameObject AStone;
    public Transform StuffParent;
    public bool IsAdoptedStuff = false;
    // bool TouchLittleFarma = false;

     //places to put in them stones
    private GameObject CurrentStone;
    public string oneonezero;
    public string onezerotwozero;
    public string twozerothtreezero;
    public string zerooneone;
    public string twozeroonezero;
    public string threezerotwozero;

    //check stone number
    private int thestonenum = 0;

    //blocks
    public GameObject firstblock;
    private bool firstdestroy = false;

    public GameObject secondblock;
    private bool seconddestroy = false;

    public GameObject thirdblock;
    private bool thirddestroy = false;

    public GameObject fourthblock;
    private bool fourthdestroy = false;

    public GameObject block;

    public int count = 0;
    public GameObject gold;
    bool inisited = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == stone)
        {
            //T key down -> take staff
            if (Input.GetKeyDown(KeyPanel.Take))
            {
                if (IsAdoptedStuff == false)
                {
                    textdisplay.text = "<u> המשרת האוויל:</u> האם תוכלו למצוא את המקום המתאים עבור האבן?";
                    AStone = collision.gameObject;
                    StuffParent = collision.transform.parent;
                    collision.gameObject.transform.parent = this.transform;
                    collision.gameObject.transform.localPosition = Vector3.zero;
                    IsAdoptedStuff = true;
                    Debug.Log("here with la farma 28");

                }

            }


        }

        //G key down -> take staff
        if (Input.GetKeyDown(KeyPanel.Put))
        {
            if (IsAdoptedStuff == true)
            {
                float height;
                IsAdoptedStuff = false;
                AStone.transform.parent = StuffParent;
                height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                AStone.transform.position = new Vector3(transform.position.x, transform.position.y - height / 4, transform.position.z);
                Debug.Log("mon bian 89: " + AStone.transform.position);
                thestonenum = AStone.GetComponent<NumOnStone>().NumAtSign();

               if (collision.gameObject.tag == oneonezero)
                {
                    if (thestonenum>=1 && thestonenum<=10)
                    {
                        Debug.Log("good job its wonderfull");
                        textdisplay.text = "<u> המשרת האוויל:</u> כל הכבוד! הצלחתם לשים כבר " + (count + 1) + " במקום ";
                        if (firstdestroy == false)
                        {
                            Destroy(firstblock);
                            firstdestroy = true;
                            count++;


                        }

                        else if (firstdestroy == true && seconddestroy == false)
                        {
                            Destroy(secondblock);
                            seconddestroy = true;
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == false)
                        {
                            Destroy(thirdblock);
                            thirddestroy = true;
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == true && fourthdestroy == false)
                        {
                            Destroy(fourthblock);
                            fourthdestroy = true;
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים" + "\n" + "  זכית ב-1500 נקודות ואוצר מטבעות זהב" + "\n" + "כמו כן התווסף לתרמיל האישי שלך חפץ שיעזור לך להכין את השיקוי להצלת המלך";
                            SingleToon.getInstance().curscore.raise(1500);
                            if (inisited == false)
                            {
                                Instantiate(gold);
                                inisited = true;
                            }
                        }

                        else
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים";
                            Destroy(block);
                        }
                            


                    }
                    else {
                        if (thestonenum < 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> אולי כדי שתנסה באזור היותר קריר של המערה";
                        }

                        else if (thestonenum-10>0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> מתחמם, אתה קרוב לאזור הנכון להנחת האבן";
                        }
                        else
                        textdisplay.text = "<u> המשרת האוויל:</u> אולי כדאי שתנסה פעם נוספת...";
                    }
                        
                }
                ///
                else if (collision.gameObject.tag == onezerotwozero)
                {
                    if (thestonenum > 10 && thestonenum <= 20)
                    {
                        Debug.Log("good job its wonderfull");
                        textdisplay.text = "<u> המשרת האוויל:</u> כל הכבוד! הצלחתם לשים כבר " + (count + 1) + " במקום ";
                        if (firstdestroy == false)
                        {
                            Destroy(firstblock);
                            firstdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;

                        }

                        else if (firstdestroy == true && seconddestroy == false)
                        {
                            Destroy(secondblock);
                            seconddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == false)
                        {
                            Destroy(thirdblock);
                            thirddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == true && fourthdestroy == false)
                        {
                            Destroy(fourthblock);
                            fourthdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים" + "\n" + "  זכית ב-1500 נקודות ואוצר מטבעות זהב" + "\n" + "כמו כן התווסף לתרמיל האישי שלך חפץ שיעזור לך להכין את השיקוי להצלת המלך";
                            SingleToon.getInstance().curscore.raise(1500);
                            if (inisited == false)
                            {
                                Instantiate(gold);
                                inisited = true;
                            }
                        }

                        else
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים";
                            Destroy(block);
                        }
                            



                    }
                    else
                    {
                        if (thestonenum < 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> אולי כדי שתנסה באזור היותר קריר של המערה";
                        }

                        else if (thestonenum - 10 > 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> מתחמם, אתה קרוב לאזור הנכון להנחת האבן";
                        }
                        else
                        textdisplay.text = "<u> המשרת האוויל:</u> אולי כדאי שתנסה פעם נוספת...";
                    }
                }

                ///
                else if (collision.gameObject.tag == twozerothtreezero)
                {
                    if (thestonenum > 20 && thestonenum <= 30)
                    {
                        Debug.Log("good job its wonderfull");
                        textdisplay.text = "<u> המשרת האוויל:</u> כל הכבוד! הצלחתם לשים כבר " + (count + 1) + " במקום ";
                        if (firstdestroy == false)
                        {
                            Destroy(firstblock);
                            firstdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == false)
                        {
                            Destroy(secondblock);
                            seconddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == false)
                        {
                            Destroy(thirdblock);
                            thirddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == true && fourthdestroy == false)
                        {
                            Destroy(fourthblock);
                            fourthdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים" + "\n" + "  זכית ב-1500 נקודות ואוצר מטבעות זהב" + "\n" + "כמו כן התווסף לתרמיל האישי שלך חפץ שיעזור לך להכין את השיקוי להצלת המלך";
                            SingleToon.getInstance().curscore.raise(1500);
                            if (inisited == false)
                            {
                                Instantiate(gold);
                                inisited = true;
                            }
                        }


                        else
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים";



                    }

                    else
                    {
                        if (thestonenum < 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> אולי כדי שתנסה באזור היותר קריר של המערה";
                        }

                        else if (thestonenum - 10 > 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> מתחמם, אתה קרוב לאזור הנכון להנחת האבן";
                        }
                        else
                        textdisplay.text = "<u> המשרת האוויל:</u> אולי כדאי שתנסה פעם נוספת...";
                    }
                }

                ///
                else if (collision.gameObject.tag == zerooneone)
                {
                    Debug.Log("326");
                    if (thestonenum <= -1 && thestonenum >= -10)
                    {
                        Debug.Log("329");
                        Debug.Log("good job its wonderfull");
                        textdisplay.text = "<u> המשרת האוויל:</u> כל הכבוד! הצלחתם לשים כבר " + (count + 1) + " במקום ";
                        if (firstdestroy == false)
                        {
                            Destroy(firstblock);
                            firstdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == false)
                        {
                            Destroy(secondblock);
                            seconddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == false)
                        {
                            Destroy(thirdblock);
                            thirddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == true && fourthdestroy == false)
                        {
                            Destroy(fourthblock);
                            fourthdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים"  + "\n" + "  זכית ב-1500 נקודות ואוצר מטבעות זהב" + "\n" + "כמו כן התווסף לתרמיל האישי שלך חפץ שיעזור לך להכין את השיקוי להצלת המלך";
                            SingleToon.getInstance().curscore.raise(1500);
                            if (inisited == false)
                            {
                                Instantiate(gold);
                                inisited = true;
                            }

                        }

                        else
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים";



                    }
                    else
                    {
                        if (thestonenum > 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> אולי כדי שתנסה באזור היותר חמים של המערה";
                        }

                        else if (thestonenum + 10 > 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> מתחמם, אתה קרוב לאזור הנכון להנחת האבן";
                        }

                        else
                        textdisplay.text = "<u> המשרת האוויל:</u> אולי כדאי שתנסה פעם נוספת...";
                    }
                }

                else if (collision.gameObject.tag == twozeroonezero)
                {
                    Debug.Log("412");
                    if (thestonenum < -10 && thestonenum >= -20)
                    {
                        Debug.Log("415");
                        Debug.Log("good job its wonderfull");
                        textdisplay.text = "<u> המשרת האוויל:</u> כל הכבוד! הצלחתם לשים כבר " + (count + 1) + " במקום ";
                        if (firstdestroy == false)
                        {
                            Destroy(firstblock);
                            firstdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == false)
                        {
                            Destroy(secondblock);
                            seconddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == false)
                        {
                            Destroy(thirdblock);
                            thirddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == true && fourthdestroy == false)
                        {
                            Destroy(fourthblock);
                            fourthdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים" + "\n" + "  זכית ב-1500 נקודות ואוצר מטבעות זהב" + "\n" + "כמו כן התווסף לתרמיל האישי שלך חפץ שיעזור לך להכין את השיקוי להצלת המלך";
                            SingleToon.getInstance().curscore.raise(1500);
                            if (inisited == false)
                            {
                                Instantiate(gold);
                                inisited = true;
                            }
                        }

                        else
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים";



                    }
                    else
                    {
                        if (thestonenum > 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> אולי כדי שתנסה באזור היותר חמים של המערה";
                        }

                        else if (thestonenum + 10 > 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> מתחמם, אתה קרוב לאזור הנכון להנחת האבן";
                        }
                        else
                        textdisplay.text = "<u> המשרת האוויל:</u> אולי כדאי שתנסה פעם נוספת...";
                    }
                }

                else if (collision.gameObject.tag == threezerotwozero)
                {
                    Debug.Log("496");
                    if (thestonenum < -20 && thestonenum >= -30)
                    {
                        Debug.Log("499");
                        Debug.Log("good job its wonderfull");
                        textdisplay.text = "<u> המשרת האוויל:</u> כל הכבוד! הצלחתם לשים כבר " + (count + 1) + " במקום ";
                        if (firstdestroy == false)
                        {
                            Destroy(firstblock);
                            firstdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == false)
                        {
                            Destroy(secondblock);
                            seconddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;
                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == false)
                        {
                            Destroy(thirdblock);
                            thirddestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            count++;

                        }

                        else if (firstdestroy == true && seconddestroy == true && thirddestroy == true && fourthdestroy == false)
                        {
                            Destroy(fourthblock);
                            fourthdestroy = true;
                            if (SingleToon.getInstance().curlife.currentlife < 100)
                            {
                                int needed = 100 - SingleToon.getInstance().curlife.currentlife;
                                SingleToon.getInstance().curlife.heal(needed);
                            }
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים" + "\n" + "  זכית ב-1500 נקודות ואוצר מטבעות זהב" + "\n" + "כמו כן התווסף לתרמיל האישי שלך חפץ שיעזור לך להכין את השיקוי להצלת המלך";
                            SingleToon.getInstance().curscore.raise(1500);
                            if (inisited == false)
                            {
                                Instantiate(gold);
                                inisited = true;
                            }
                        }

                        else
                            textdisplay.text = "<u> המשרת האוויל:</u> מעולה הצלחת לפתור את המעבר יציאה מהמערה, תודה רבה!!" + "\n" + "כמו שאפשר לראות המספרים החיוביים נמצאים מימין לציר האיקס ואילו השליליים נמצאים משמאל, מספרים שהם חיוביים גדולים מהמספרים השליליים";



                    }
                    else
                    {
                        if (thestonenum > 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> אולי כדי שתנסה באזור היותר חמים של המערה";
                        }

                        else if (thestonenum + 10 > 0)
                        {
                            textdisplay.text = "<u> המשרת האוויל:</u> מתחמם, אתה קרוב לאזור הנכון להנחת האבן";
                        }
                        else
                        textdisplay.text = "<u> המשרת האוויל:</u> אולי כדאי שתנסה פעם נוספת...";
                    }
                }


                


            }

            /*if (collision.gameObject.tag == ret1)
            {

            }*/

        }
    }
}
