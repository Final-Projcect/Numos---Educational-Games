using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeAKey : MonoBehaviour
{
    //key declertion
    //key tag
    public string key;


    //numbre of keys
    public int numberofkeys;

    //stack to contine the keys
    //public Stack<int> Keys = new Stack<int>();
    public List<GameObject> KeyList = new List<GameObject>();
    public List <int> Keys = new List<int>();

    public GameObject KeyStuff;
    public Transform KeyStuffParent;
    //public string NumberOnKey;
    [SerializeField] float speed = 3f;

    //public bool IsAdoptedStuff = false;
    int count = 0;
    //bool TouchLittleFarma = false;

    //sign tag
    public string sign;

    //text display
    public TextMeshProUGUI textdisplay;

    //the diviosrs of an sign
    public Stack<int> Thediviosr = new Stack<int>();

    //ontriggervalues use
    public int num = 0;
    public int signNum = 0;
    public int numofkeys = 0;
    public int index = 0;
    public int deleted = 0;
    public bool AllIn = false;





    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.tag == key)
        {
            if (numofkeys == 0)
            {
                //collect key
                KeyStuff = collision.gameObject;
                KeyStuffParent = collision.transform.parent;
                collision.gameObject.transform.parent = this.transform;
                collision.enabled = false;

                //make key move toward the chracther
                collision.gameObject.transform.localPosition = Vector2.MoveTowards(transform.position / 20, Vector3.zero, speed * Time.deltaTime);

                //find the number on the key
                int number = collision.gameObject.GetComponent<NumberOnKey>().NumAtKey();

                //put the key number on the global value for use it latter while check if the numbr of key is the same as the number of sign
                num = number;

                //put the key into the stack (becouse we allways check witch is the new key and use him first)
                //Keys.Push(num);
                Keys.Add(num);
         

                //added the key object into a list
                KeyList.Add(KeyStuff);

                //count the number of keys
                numofkeys++;
                index++;
                
                
                Debug.Log("----------------------i have a key yay" + " his num is: " + number );
            }

            else if (numofkeys > 0 && KeyList.Contains(collision.gameObject) != true )
            {
                //collect key
                KeyStuff = collision.gameObject;
                KeyStuffParent = collision.transform.parent;
                collision.gameObject.transform.parent = this.transform;

                //make key move toward the chracther
                if (numofkeys<3)
                {
                    Debug.Log("**************************" + transform.position + " the deleted is: " + deleted);
                    collision.gameObject.transform.localPosition = Vector2.MoveTowards(transform.position / ((numofkeys + deleted) + (10 / (numofkeys + deleted))), Vector3.zero, speed * Time.deltaTime);
                }

                else if (numofkeys == 3)
                {
                    Debug.Log("**************************" + transform.position +" the deleted is: " + deleted);
                    collision.gameObject.transform.localPosition = Vector2.MoveTowards(transform.position / ((numofkeys + deleted) + (7 / (numofkeys + deleted)) ), Vector3.zero, speed * Time.deltaTime);
                }

                else if (numofkeys == 4)
                {
                    Debug.Log("**************************" + transform.position + "  " + numofkeys);
                    collision.gameObject.transform.localPosition = Vector2.MoveTowards(transform.position / ((numofkeys + deleted) + (2 / (numofkeys + deleted))), Vector3.zero, speed * Time.deltaTime);
                }

                else if (numofkeys == 5)
                {
                    Debug.Log("**************************" + transform.position + "  " + numofkeys);
                    collision.gameObject.transform.localPosition = Vector2.MoveTowards(transform.position / ((numofkeys + deleted) + (1 / (numofkeys + 333 + deleted))), Vector3.zero, speed * Time.deltaTime);
                }


                //find the number on the key
                int number = collision.gameObject.GetComponent<NumberOnKey>().NumAtKey();

                //put the key number on the global value for use it latter while check if the numbr of key is the same as the number of sign
                num = number;

                //put the key into the stack (becouse we allways check witch is the new key and use him first)
                //Keys.Push(num);
                Keys.Add(num);

                //added the key object into a list
                KeyList.Add(KeyStuff);

                //count the number of keys
                numofkeys++;
                index++;
                Debug.Log("----------------------i have more then a one key yofido" + " his num is: " + number + "-----------");
            }





            //}

            //  }


        }

        if (collision.gameObject.tag == sign)
        {
            if (collision.gameObject.GetComponent<NumberOnSign>().isText()!=true)
            {
                signNum = collision.gameObject.GetComponent<NumberOnSign>().NumAtSign();
                textdisplay.text = "הו! אנחנו מעל בית מגורים מספר " + signNum + "\n" + "כלומר עליך לפתוח את הדירה באמצעות מפתח עם פס 1" + "\n" + "במידה ויש כזה ברשותך אז תעמוד מתחת לשלט והקישו t במקלדת";
            }
            else
            {
                textdisplay.text = "כל הכבוד! נראה שכבר הצלחתם לפתוח את הדלת של הבית הזה";
            }
            
            
            //Debug.Log("stand on sign");
            int diviosrs;

            //T key down -> take staff
            //if (Input.GetKeyUp(KeyPanel.Take))
            if (Input.GetKeyUp(KeyCode.T))

            {
                if (collision.gameObject.GetComponent<NumberOnSign>().isText() != true)
                {

                    numberofkeys++;
                    Debug.Log("the number of keys is la la");
                    signNum = collision.gameObject.GetComponent<NumberOnSign>().NumAtSign();
                    diviosrs = collision.gameObject.GetComponent<NumberOnSign>().Divisors(signNum);
                    Thediviosr = collision.gameObject.GetComponent<NumberOnSign>().TheDivisiors(signNum);

                    //num = Keys.Pop();
                    bool contains = false;
                    if (signNum == 1)
                    {
                        contains = Keys.Contains(signNum);
                        Debug.Log("the contains state is: " + contains);
                    }

                    if (signNum > 1)
                    {
                        int[] divarr = Thediviosr.ToArray();
                        Debug.Log("the diviors is: " + diviosrs + "the divid: " + divarr.ToString());
                        Debug.Log("i am here 183: " + signNum);
                        AllIn = false;
                        contains = true;
                    }

                    int indexlocation = Keys.IndexOf(signNum);
                    if (contains == true)
                    {
                        Debug.Log("line 189 + the diviorsrs is: " + diviosrs);
                        if (diviosrs == 1)
                        {
                            Debug.Log("line 192");
                            num = signNum;
                            Keys.Remove(signNum);
                            deleted++;


                            Debug.Log("the sign num is: " + signNum + "and the key number is: " + num);
                            //bool HaveBeen = collision.gameObject.GetComponent<NumberOnSign>().unCheck;
                            if (signNum == num)
                            {
                                int numtoopen = collision.gameObject.GetComponent<NumberOnSign>().NumberToOpen(diviosrs)-1;
                                if (numtoopen == 0)
                                {
                                    Debug.Log("well done you bring one key: " + numtoopen);
                                    textdisplay.text = "כל הכבוד הצלחת לפתוח את הבית בהצלחה!";
                                    collision.gameObject.GetComponent<NumberOnSign>().AlradyUsed();
                                    SingleToon.getInstance().curmoney.gain(250);
                                     SingleToon.getInstance().curscore.raise(25);
                                    Destroy(KeyList[indexlocation]);
                                }
                                else
                                    textdisplay.text = "צריך להביא עוד מפתחות על מנת לפתוח את הדלת והם !" + "\n" + Thediviosr.ToArray().ToString();

                            }


                        }
                        else if (diviosrs > 1)
                        {
                            int[] numbersfordivide = new int[diviosrs];
                            Debug.Log("the num for divide is: line 225 " + numbersfordivide.ToString());
                            int i = 0;
                            numbersfordivide = Thediviosr.ToArray();
                            num = signNum;
                            AllIn = false;
                            while (Keys.Contains(numbersfordivide[i]) != true)
                            {
                                i++;
                                if (i== numbersfordivide.Length)
                                {
                                    Debug.Log("line 233 dont have a keys that needed");
                                    textdisplay.text = "נראה שעדיין לא מצאתם מפתחות שמתאימים לדלת הזו, תמשיכו לחפש";
                                    i = i - 1;
                                    break;

                                }

                            }



                            if (Keys.Contains(numbersfordivide[i]) == true)
                            {
                                int indextodelete=0;
                                num = numbersfordivide[i];
                                //if (numbersfordivide.Length>1)
                               // {
                                    indextodelete = Keys.IndexOf(num);
                                //}
                                Keys.Remove(num);
                                deleted++;

                                Debug.Log("the sign num is: " + signNum + "and the key number is: " + num);
                                int numtoopen = collision.gameObject.GetComponent<NumberOnSign>().NumberToOpen(diviosrs);
                                if (numtoopen == 0)
                                {
                                    Debug.Log("well done you bring one key: " + numtoopen);
                                    textdisplay.text = "כל הכבוד הצלחת לפתוח את הבית בהצלחה!";
                                    collision.gameObject.GetComponent<NumberOnSign>().AlradyUsed();
                                    SingleToon.getInstance().curmoney.gain(250);
                                    SingleToon.getInstance().curscore.raise(25);
                                    AllIn = true;
                                    Destroy(KeyList[i]);

                                }
                                else
                                {
                                    AllIn = false;
                                    Debug.Log("well done you bring one key but you need more: " + (numtoopen-1));
                                    textdisplay.text = "כל הכבוד הצלחת לפתוח את אחד ממפתחות הבית בהצלחה, כעת עליך למצוא את שאר המפתחות המתאימים!" + "\n" + "נשארו עוד " + (numtoopen) + " מפתחות";
                                    collision.gameObject.GetComponent<NumberOnSign>().GonnaBeDone();
                                    SingleToon.getInstance().curmoney.gain(100);
                                    SingleToon.getInstance().curscore.raise(15);
                                    Destroy(KeyList[indextodelete]);
                                }
                            }
                        }
                    }
                }
            }
        }

        textdisplay.text = "עליך לפתוח את כל הדלתות לכל הבתים, יש לעשות זאת באמצעות מיצוי כל המפתחות שמספר הפינים שלהם הוא מספרים המתחלקים במספר שעל השלט" + "\n" + "יש להיזהר לא ליפול מגובה, אחרת צריך להתחיל את כל השלב מהתחלה!";



        }

    // Update is called once per frame
    /*void Update()
{
    if (TouchLittleFarma != true)
    {
        //G key down -> take staff
        if (Input.GetKeyDown(KeyPanel.Put))
        {
            if (IsAdoptedStuff == true)
            {
                float height;
                IsAdoptedStuff = false;
                Stuff.transform.parent = StuffParent;
                height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                Stuff.transform.position = new Vector3(transform.position.x, transform.position.y - height / 4, transform.position.z);
                Debug.Log("mon bian 89: " + Stuff.transform.position);

            }

        }
    }*/
}
    
