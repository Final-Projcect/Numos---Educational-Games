using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovmentAtKingBoss : MonoBehaviour
{
    //jumping
    public float jumpForce = 10;
    public float jumpForceEffectByMomentomRatio;
    public float speed = 4f;

    //the invatory object
    public GameObject Instruction;
    private GameObject fordestroy;
    bool exist = false;

    //check if misson done
    bool done = LaFarmaBox.missiondone = false;

    public GameObject InvatoryForUSe;

    //text display
    public TextMeshProUGUI textdisplay;

    //begin level
    public bool startgame = false;
    public bool attackManger = false;
    public bool clickona = false;
    public bool clickonb = false;
    public bool clickonc = false;
    public int compose;
    public int numchose;
    public int primechose1;
    public int primechose2;
    public int levelonecheck;

    //prime level
    public TextMeshProUGUI[] aritmaticheadthrerehend;

    //levels items
    public GameObject attackMang;
    public TextMeshProUGUI[] aritmatichead;
    public GameObject inputfield;
    public GameObject canvaholder;
    public TMP_InputField inputdata;
    public bool inlevel = false;
    private string input;


    //level achiments 
    public GameObject gold;
    public int getgold;
    public string golds;
    public GameObject item;
    public GameObject[] coinsone;
    public GameObject[] coinstwo;
    public GameObject[] coinsthree;
    public int getcoin;
    public string coins;
    public GameObject relseking;
    private int[] Primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 47, 53, 59, 71, 83, 89, 101, 107, 113 };

    //Aritmatic Monster
    public string Obstic;
    public GameObject fourhands;
    public bool composedone = false;
    public GameObject therehands;
    public bool primedone = false;
    public GameObject twohands;
    public bool wopdone = false;
    public GameObject onehands;
    public bool primediviesdone = false;



    protected Vector3 NewPosition()
    {
        //leftMovement
        if (Input.GetKey(KeyPanel.MoveLeft))
        {
            return transform.position + Vector3.left * Time.deltaTime * speed;
        }

        //RightMovement
        else if (Input.GetKey(KeyPanel.MoveRight))
        {
            return transform.position + Vector3.right * Time.deltaTime * speed;
        }

        //DownMovement
        else if (Input.GetKey(KeyPanel.MoveDown))
        {
            return transform.position + Vector3.down * Time.deltaTime * speed;
        }

        //UpMovement
        else if (Input.GetKey(KeyPanel.MoveUp))
        {
            return transform.position + Vector3.up * Time.deltaTime * speed;
        }

        //M key down -> open invatory
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(InvatoryForUSe);
            return transform.position;
        }

        //P key down -> giving things in levels
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKey("p"))
        {
            //need to put here an option to gave object and destroy it
            SceneManager.LoadScene("PausePage");
            return transform.position;
        }

        //click on c
        else if (Input.GetKeyDown(KeyCode.C) && clickonc == false && inlevel == false || Input.GetKey("c") && clickonc == false && inlevel == false)
        {
            SceneManager.LoadScene("KingPotionNew");
            return transform.position; // Pass into ohter secne
        }

        //click on b
        else if (Input.GetKeyDown(KeyCode.B) && clickonb == false && inlevel == false || Input.GetKey("b") && clickonb == false && inlevel == false)
        {

            textdisplay.text = "<u>אחד:</u> אין לך סיכוי להגיע למלך לפני שתביס את מפלצת האריטמיק שלי!" + "\n" + "מה התגובה שלך:" + "\n" + " א. לברוח - לחצו על C" + "\n" + "ב. להלחם במפלצת ולהציל את המלך - לחצו על A";
            return transform.position;
        }


        //click on a
        else if (Input.GetKeyDown(KeyCode.A) && clickona == false && inlevel == false || Input.GetKey("a") && clickona == false && inlevel == false)
        {
            clickona = true;
            clickonb = true;
            clickonc = true;
            textdisplay.text = "<u>אחד:</u> אני רואה שאומץ לא חסר לך, אבל חבל! אין לך סיכוי לנצח את מפלצת האירטמיק, כל רגל של האלופה הקטנה שלי כוללת הוכחה מסוג אחר, ככה שעל מנת לנצח אותה עליך לבחור את הכלים המתאימים ולהוכיח אותם, דבר שהוא לא אפשרי מוחעחעחעחע מפלצת האריטמיק אל תוותרי!!, ";
            startgame = true;

            AttackAritmatic();
            return transform.position;
        }

        //click on g - gcd
        else if (Input.GetKeyDown(KeyCode.G) && inlevel == false || Input.GetKeyDown("g") && inlevel == false)
        {
            attackMang.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("the key you pressed is: " + 'g');
            textdisplay.text = "<u>אחד:</u> מפלצת האריטמיק לא קשורה בכלל ל-DCG ממליץ לך לברוח ומהר כי אין לך סיכוי נגדה!!!";
            attackMang.GetComponent<SpriteRenderer>().enabled = true;
            return transform.position;
        }

        //click on d - divides
        else if (Input.GetKeyDown(KeyCode.D) && inlevel == false || Input.GetKeyDown("d") && inlevel == false)
        {
            attackMang.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("the key you pressed is: " + 'd');
            if (composedone == true && primedone == true && wopdone == true)
            {
                textdisplay.text = "<u>אחד:</u> אוי לא, שחרררי אותי!!! שמישהו יעזור לי, הצילו, הצילו!!!" + "\n" + " בבקשה עליך לעזור לי ולענות על שאלות האריטמטיק נכונה על מנת להביס אותה ולשחרר אותי מידיה!! אני הנסיך ואני מצווה עלייך לעשות זאת במיידי!!";
            }
            else
            {
                textdisplay.text = "<u>אחד:</u> האריטמטיק שלי ממש חזקה, עדיף לך לוותר";
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
            }
            return transform.position;
        }

        //click on r - primes
        else if (Input.GetKeyDown(KeyCode.R) && inlevel == false || Input.GetKeyDown("r") && inlevel == false)
        {
            
            attackMang.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("the key you pressed is: " + 'r');
            if (composedone == true && primedone == false)
            {
                textdisplay.text = "<u>אחד:</u> מפלצת האריטמטיק עדיין חזקה, נראה איך ילך לך עם מחשבות האריטמטיק עכשיו!!" + "\n" + "אין לך סיכוי לענות נכונה על המחשבות של האריטמטיק מוחעחעחע";
                inlevel = true;

                //show the base of numbers for check
                aritmaticheadthrerehend[0].GetComponent<TextMeshProUGUI>().enabled = true;
                aritmaticheadthrerehend[1].GetComponent<TextMeshProUGUI>().enabled = true;
                aritmaticheadthrerehend[2].GetComponent<TextMeshProUGUI>().enabled = true;

                //show the inputbox area
                inputfield.GetComponent<SpriteRenderer>().enabled = true;
                canvaholder.GetComponent<Canvas>().enabled = true;
                inputdata.GetComponent<TMP_InputField>().enabled = true;

                AttackPrimes();
            }

            else if (composedone == true && primedone == true)
            {
                textdisplay.text = "<u>אחד:</u> כבר הצלחת להביס את כף הראשוניים של מפלצת האריטמטיק שלי";
            }

            else
            {
                textdisplay.text = "<u>אחד:</u> לאריטמטיק שלי יש הרבה רגליים ואין לך סיכוי להביס אותה, אולי עדיף לך לוותר ולחזור למקום ממנו באת";
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
            }
            return transform.position;
        }

        //click on o - composite
        else if (Input.GetKeyDown(KeyCode.O) && inlevel == false || Input.GetKeyDown("o") && inlevel == false)
        {
            if (composedone == false)
            {
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("the key you pressed is: " + 'o');

                inlevel = true;

                //let the player know that he is in the right level
                textdisplay.text = "<u>אחד:</u> אוי לא! חשפת את אחד מרגליי הארטימטיק, אך לא די בכך כדי להביס אותה, היא תראה לך מזה, אריטמטיק צאי לדרך!" + "\n" + "אין לך סיכוי להצליח לעמוד בלקט המחשבות שלה, אבל בוא נראה מה יכולתיך , תענה נכונה בחלונות התשובה וככה תצליח להחליש את המפלצת";

                //show the base of numbers for check
                aritmatichead[0].GetComponent<TextMeshProUGUI>().enabled = true;
                aritmatichead[1].GetComponent<TextMeshProUGUI>().enabled = true;
                aritmatichead[2].GetComponent<TextMeshProUGUI>().enabled = true;

                //show the inputbox area
                inputfield.GetComponent<SpriteRenderer>().enabled = true;
                canvaholder.GetComponent<Canvas>().enabled = true;
                inputdata.GetComponent<TMP_InputField>().enabled = true;

                //put numbers in the head area - two primes and one compose
                attackcompose();
            }
            else if (composedone == true)
            {
                textdisplay.text = "<u>אחד:</u> כבר הבסת את רגל המספרים הפריקים של מפלצת האריטמטיק היקרה שלי";
            }
            
            return transform.position;
        }

        //click on W - wop
        else if (Input.GetKeyDown(KeyCode.W) && inlevel == false || Input.GetKeyDown("w") && inlevel == false)
        {
            attackMang.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("the key you pressed is: " + 'w');
            if (composedone == true && primedone == true)
            {
                textdisplay.text = "<u>אחד:</u> אומנם הצלחת להוריד לה כמה רגליים, אך עדיין אין לך סיכוי להביס אותה, אריטמטיק אל תוותרי!!";
            }
            else
            {
                textdisplay.text = "<u>אחד:</u> מוקדם לך מדי להתמודד מולה, עדיף לך לפרוש בשיא";
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
            }
            return transform.position;
        }

        else
        {
            return transform.position;
        }



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // poski = new InventoryItem(positem.GetComponent<SpriteRenderer>().sprite, 1, 1, "Posking", "postion for king");
        //InvatoryForUSe.GetComponent<InventoryGUI>().additem(poski);

        if (collision.gameObject.tag == coins)
        {
            getcoin = getcoin + 1;
            Debug.Log("you have: " + getcoin);
            SingleToon.getInstance().curmoney.gain(100);
            SingleToon.getInstance().curscore.raise(10);
        }

        if (collision.gameObject.tag == golds)
        {
            getgold = getgold + 1;
            Debug.Log("you have: " + getgold);
            SingleToon.getInstance().curmoney.gain(500);
            SingleToon.getInstance().curscore.raise(50);
        }

        if (collision.gameObject.tag == Obstic)
        {
            Debug.Log("the obstic touched you");
            // SingleToon.getInstance().curlife.damage(2);

        }
    }


    public void AttackAritmatic()
    {
        char attackkey;
        if (startgame == true)
        {
            if (attackManger == false)
            {
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
                attackManger = true;
                // attacking(attackkey);

            }
        }
    }

    public void AttackPrimes()
    {
        textdisplay.text = "אז הינה אנו כאן";
    }


    public void attackcompose()
    {
        int randchosee1 = 0;
        int randchosee2 = 0;
        int head3 = 5;
        numchose = 0;
        randchosee1 = UnityEngine.Random.Range(0, 2);
        randchosee2 = UnityEngine.Random.Range(0, 2);
        while (randchosee1 == randchosee2)
        {
            randchosee2 = UnityEngine.Random.Range(1, 3);
        }
         primechose1 = UnityEngine.Random.Range(0, Primes.Length);
         primechose2 = UnityEngine.Random.Range(0, Primes.Length);

        while (primechose1 == primechose2)
        {
            primechose2 = UnityEngine.Random.Range(0, Primes.Length);
        }
        aritmatichead[randchosee1].text = Primes[primechose1].ToString();
        aritmatichead[randchosee2].text = Primes[primechose2].ToString();


        if (randchosee1 == 0 && randchosee2 == 1)
        {
            head3 = 2;
        }

        else if (randchosee1 == 1 && randchosee2 == 2)
        {
            head3 = 0;
        }

        else if (randchosee1 == 2 && randchosee2 == 1)
        {
            head3 = 0;
        }

        else if (randchosee1 == 2 && randchosee2 == 0)
        {
            head3 = 1;
        }

        else if (randchosee1 == 1 && randchosee2 == 0)
        {
            head3 = 2;
        }

        else if (randchosee1 == 0 && randchosee2 == 1)
        {
            head3 = 2;
        }

        else if (randchosee1 == 0 && randchosee2 == 2)
        {
            head3 = 1;
        }

        numchose = UnityEngine.Random.Range(0, 200);
        while (primechose1 == numchose || primechose2 == numchose)
        {
            numchose = UnityEngine.Random.Range(0, 200);
        }

        aritmatichead[head3].text = numchose.ToString();

        /*string userInput = inputdata.GetComponent<TMP_InputField>().text;
        if (userInput == "")
        {
            userInput = inputdata.text;
            Debug.Log(userInput);
        }
        

        int a = 124;
        Debug.Log("1245");

        
        Debug.Log(userInput);*/
       
        
        

    }
    
    
    public void findthecompose(string s)
    {
        input = s;//contiue from here
        string a = inputdata.GetComponent<TMP_InputField>().text;
        if (a == "")
        {
            a = inputdata.text;
            Debug.Log(a);
        }
        Debug.Log("a is: " + a);
        //Debug.Log("the string is: " + input);
        compose = Convert.ToInt32(a);
        checkidentical();
    }

    public void checkidentical()
    {
        Debug.Log("the compose is: " + compose);
        Debug.Log("the ok num is: " + numchose);
        if (compose == numchose)
        {
            textdisplay.text = "<u>אחד:</u> אוי לא ! הצלחת לענות נכונה ולהערים על המפלצת שלי, אבל היא עדיין חזקה ואין לך סיכוי נגדה!" ;
            levelonecheck++;
            if (levelonecheck < 3)
            {
                compose = 0;
                numchose = 0;
                primechose1 = 0;
                primechose2 = 0;

                attackcompose();
            }

            else
            {
                textdisplay.text = "<u>אחד:</u> הצלחת אומנם להוריד למפלצת שלי את אחת הזרועות, אך היא עדיין חזקה ממך!";

                composedone = true;

                //hide the inputbox area and hide the old obstic
                inputfield.GetComponent<SpriteRenderer>().enabled = false;
                canvaholder.GetComponent<Canvas>().enabled = false;
                inputdata.GetComponent<TMP_InputField>().enabled = false;
                fourhands.GetComponent<SpriteRenderer>().enabled = false;
              
                //hide the base of numbers for check
                aritmatichead[0].GetComponent<TextMeshProUGUI>().enabled = false;
                aritmatichead[1].GetComponent<TextMeshProUGUI>().enabled = false;
                aritmatichead[2].GetComponent<TextMeshProUGUI>().enabled = false;

                //show the mang and the new obstic
                therehands.GetComponent<SpriteRenderer>().enabled = true;
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
                inlevel = false;


            }
            
        }
        else if (compose == Primes[primechose1] || compose == Primes[primechose2])
        {
            textdisplay.text = "<u>אחד:</u> אתה לא מבדיל עדיין בין מספר ראשוני למספר פריק!!! איזה אפס אתה!";
        }
        else
        {
            textdisplay.text = "<u>אחד:</u> ידעתי שאין לך סיכוי מול המפלצת שלי, אולי כדי שתחזור ללמוד מה זה מספרים פריקים ורק אחרי זה תבוא נגדה";
        }
    }

   




    public char GetKeyForAttack()
    {
        char key;
        if (Input.GetKeyDown(KeyCode.G) || Input.GetKey("g"))
        {
            return 'g';
        }

        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey("w"))
        {
            return 'w';
        }

        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey("d"))
        {
            return 'd';
        }

        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKey("r"))
        {
            return 'r';
        }

        else if (Input.GetKeyDown(KeyCode.O) || Input.GetKey("o"))
        {
            return 'o';
        }

        else
            return 'm';

    }

    public void attacking(char key)
    {
        switch (key)
        {
            case 'g':
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 'w':
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 'd':
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 'r':
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 'o':
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 'm':
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                break;
            default:
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                break;
        }
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = NewPosition();
    }

    public void Start()
    {
        //text desplay
        textdisplay.text = "<u>אחד:</u>אוי לא! איך הגעת לכאן? טוב, זה לא באמת משנה, אין לך סיכוי לעצור אותי ולעמוד מול מפלצת האריתמטיק שלי!!! מוחעחעחעחע " +  "\n" + "א. להילחם במפלצת ולהציל את המלך - לחצו על A" + "\n" + "ב. להציל את המלך ולברוח - לחצו על B" + "\n" + "ג. לברוח - לחצו על C";
    }
}
