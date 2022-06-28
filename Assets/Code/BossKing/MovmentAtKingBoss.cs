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
    public int numchose2;
    public int primechose3;
    public int normalchose2;
    public int levelonecheck2;
    public int primenum;
    int theprime;

    //wop level
    public TextMeshProUGUI[] aritmaticheadtwohend;
    public int numwop1;
    public int numwop2;
    public int num3;
    public int leveltherecheck;
    public int thesmallest;
    public int wopone;
    public GameObject one;

    //divides level
    public TextMeshProUGUI[] aritmaticheadonehend;
    public int levelfourcheck = 0;
    public int firstprime;
    public int secondprime;
    public int thirdprime;
    public int sumofprimes;
    public int thesum;

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
    public string itemname;
    public GameObject[] coinsone;
    public GameObject[] coinstwo;
    public GameObject[] coinsthree;
    public int getcoin;
    public string coins;
    public GameObject relseking;
    public GameObject fishking;
    public GameObject kinghuman;
    public GameObject five;
    public GameObject exitbox;
    public string onexit;
    private int[] Primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 47, 53, 59, 71, 83, 89, 101, 107, 113 };
    public List<int> PrimeNumbs = new List<int>();

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

        //E key down -> return king into human
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKey("e"))
        {
            textdisplay.text = "<u>המלך אינסוף:</u> תודה רבה לכם! אני אהיה אסיר תודה לכם לנצח! בני חוזרים לארמון יש לנו כמה דברים לדבר עליהם, ואתם מוזמנים להסתובב בכבוד בממלכת נאמברין שלי, תודה רבה על עזרתכם!";
            fishking.GetComponent<SpriteRenderer>().enabled = false;
            kinghuman.GetComponent<SpriteRenderer>().enabled = true;
            exitbox.GetComponent<BoxCollider2D>().enabled = true;
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
                inlevel = true;

                //show the base of numbers for check
                aritmaticheadonehend[0].GetComponent<TextMeshProUGUI>().enabled = true;
                aritmaticheadonehend[1].GetComponent<TextMeshProUGUI>().enabled = true;
                aritmaticheadonehend[2].GetComponent<TextMeshProUGUI>().enabled = true;

                //show the inputbox area
                inputfield.GetComponent<SpriteRenderer>().enabled = true;
                canvaholder.GetComponent<Canvas>().enabled = true;
                inputdata.GetComponent<TMP_InputField>().enabled = true;
                
                Debug.Log(200);
                AttackDivdes();
                // attackwop();
            }
            else if (composedone == true && primedone == true && wopdone == false || composedone == true && primedone == false || composedone == false)
            {
                textdisplay.text = "<u>אחד:</u> האריטמטיק שלי ממש חזקה, עדיף לך לוותר";
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
            }

            else
            {
                textdisplay.text = "<u>אחד:</u> אני חייב לכם את התנצלותי הכנה, תודה שהצלתם אותי";

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
                textdisplay.text = "<u>אחד:</u> מפלצת האריטמטיק עדיין חזקה, נראה איך ילך לך עם מחשבות האריטמטיק עכשיו!!" + "\n" + " ,אין לך סיכוי לענות נכונה על המחשבות של האריטמטיק מוחעחעחע, אני מקווה מאוד שאתה לא זוכר מה זה מספרים פריקים ולא יודע איך להבדיל בינם לבין ראשוניים";
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
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
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
            InitilizePrimes();
            attackMang.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("the key you pressed is: " + 'w');
            if (composedone == true && primedone == true && wopdone == false)
            {
                textdisplay.text = "<u>אחד:</u> אומנם הצלחת להוריד לה כמה רגליים, אך עדיין אין לך סיכוי להביס אותה, אריטמטיק אל תוותרי!!";
                inlevel = true;

                //show the base of numbers for check
                aritmaticheadtwohend[0].GetComponent<TextMeshProUGUI>().enabled = true;
                aritmaticheadtwohend[1].GetComponent<TextMeshProUGUI>().enabled = true;
                aritmaticheadtwohend[2].GetComponent<TextMeshProUGUI>().enabled = true;

                //show the inputbox area
                inputfield.GetComponent<SpriteRenderer>().enabled = true;
                canvaholder.GetComponent<Canvas>().enabled = true;
                inputdata.GetComponent<TMP_InputField>().enabled = true;
                Debug.Log(285);
                attackwop();
            }
            else if (composedone == true && primedone == false || wopdone == false)
            {
                textdisplay.text = "<u>אחד:</u> מוקדם לך מדי להתמודד מולה, עדיף לך לפרוש בשיא";
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
            }

            else
            {
                textdisplay.text = "<u>אחד:</u> גם עם רגל אחת היא תצליח לנצח אותך!!! רגע, שניה! אוי לא, חכי, תורידי אותי!!! שמישהו יעזור לי, הצילווו";
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
            }

            return transform.position;

        }
        return transform.position;
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
            gold.GetComponent<SpriteRenderer>().enabled = false ;
            gold.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject.tag == Obstic)
        {
            Debug.Log("the obstic touched you");
            // SingleToon.getInstance().curlife.damage(2);

        }

        if (collision.gameObject.tag == itemname)
        {
           
            item.GetComponent<SpriteRenderer>().enabled = false;
            item.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("you touch an iteam");
            relseking.GetComponent<SpriteRenderer>().enabled = false;
            textdisplay.text = "<u>המלך אינסוף:</u> בני אני סולח לך, אבל בבקשה החזירו אותי להיות בנאדם ברגע זה!!" + "\n" + "<u>אחד:</u> זה בעיה, אני גנבתי לאפס את השיקוי כשהוא עבר לידי, אין שום דרך להחזיר אותך להיות אדם שוב" + "\n" + "<u>האח חמש:</u> כל הכבוד אחי!!! אני רואה שהצלחת לשחרר את המלך ולהביס את המפלצת, ראיתי במקרה שהשארת את השיקוי להצלתו על הריצפה, ככה שתרגיש חופשי להשתמש בו" + "<u>אחד:</u> על מנת להחזיר את אחי להיות בן אדם לחצו על המקש E במקלדת";
            five.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (collision.gameObject.tag == onexit)
        {

            SceneManager.LoadScene("FinishGame");

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

    public void AttackDivdes()
    {
        if (levelfourcheck == 0)
        {
            textdisplay.text = "<u>אחד:</u> אומנם הצלחת להוריד לה רגל אחת, אך אין סיכוי שתצליח להוריד לה אחת נוספת, הרי אין סיכוי שבעולם שתוכל לנחש מי מהמספרים הבאים הוא ראשוני";
        }
        int randchosee7 = 0;

        int chose1;
        int chose2;
        int chose3;

        int randchosee8 = 0;
        int head7 = 5;
        numchose = 0;
        randchosee7 = UnityEngine.Random.Range(0, 2);
        randchosee8 = UnityEngine.Random.Range(0, 2);
        while (randchosee7 == randchosee8)
        {
            randchosee8 = UnityEngine.Random.Range(1, 3);
        }
        chose1 = UnityEngine.Random.Range(0, 6);
        chose2 = UnityEngine.Random.Range(0, 6);
        while (chose1 == chose2)
        {
            chose1 = UnityEngine.Random.Range(0, 6);
        }

        firstprime = Primes[chose1];
        secondprime = Primes[chose2];
        aritmaticheadonehend[randchosee7].text = firstprime.ToString();
        //theprime = Primes[primechose3];
        aritmaticheadonehend[randchosee8].text = secondprime.ToString();


        if (randchosee7 == 0 && randchosee8 == 1)
        {
            head7 = 2;
        }

        else if (randchosee7 == 1 && randchosee8 == 2)
        {
            head7 = 0;
        }

        else if (randchosee7 == 2 && randchosee8 == 1)
        {
            head7 = 0;
        }

        else if (randchosee7 == 2 && randchosee8 == 0)
        {
            head7 = 1;
        }

        else if (randchosee7 == 1 && randchosee8 == 0)
        {
            head7 = 2;
        }

        else if (randchosee7 == 0 && randchosee8 == 1)
        {
            head7 = 2;
        }

        else if (randchosee7 == 0 && randchosee8 == 2)
        {
            head7 = 1;
        }

        chose3 = UnityEngine.Random.Range(0, 6);
        while (chose1 == chose3 || chose3 == chose2)
        {
            chose3 = UnityEngine.Random.Range(0, 6);
        }
        thirdprime = Primes[chose3];
        aritmaticheadonehend[head7].text = thirdprime.ToString();
        sumofprimes = firstprime * secondprime * thirdprime;
        Debug.Log("the first prime is: " + firstprime + " the second prime is: " + secondprime + " the third prime is: " + thirdprime + " the sum is: " + sumofprimes);
    }

    public void AttackPrimes()
    {
        if (levelonecheck2 == 0)
        {
            textdisplay.text = "<u>אחד:</u> אומנם הצלחת להוריד לה רגל אחת, אך אין סיכוי שתצליח להוריד לה אחת נוספת, הרי אין סיכוי שבעולם שתוכל לנחש מי מהמספרים הבאים הוא ראשוני";
        }
        int randchosee3 = 0;
        int randchosee4 = 0;
        int head4 = 5;
        numchose = 0;
        randchosee3 = UnityEngine.Random.Range(0, 2);
        randchosee4 = UnityEngine.Random.Range(0, 2);
        while (randchosee3 == randchosee4)
        {
            randchosee4 = UnityEngine.Random.Range(1, 3);
        }
        primechose3 = UnityEngine.Random.Range(0, Primes.Length);
        normalchose2 = UnityEngine.Random.Range(0, 200);
        while (PrimeNumbs.Contains(normalchose2))
        {
            normalchose2 = UnityEngine.Random.Range(0, 200);
        }


        aritmaticheadthrerehend[randchosee3].text = Primes[primechose3].ToString();
        theprime = Primes[primechose3];
        aritmaticheadthrerehend[randchosee4].text = normalchose2.ToString();


        if (randchosee3 == 0 && randchosee4 == 1)
        {
            head4 = 2;
        }

        else if (randchosee3 == 1 && randchosee4 == 2)
        {
            head4 = 0;
        }

        else if (randchosee3 == 2 && randchosee4 == 1)
        {
            head4 = 0;
        }

        else if (randchosee3 == 2 && randchosee4 == 0)
        {
            head4 = 1;
        }

        else if (randchosee3 == 1 && randchosee4 == 0)
        {
            head4 = 2;
        }

        else if (randchosee3 == 0 && randchosee4 == 1)
        {
            head4 = 2;
        }

        else if (randchosee3 == 0 && randchosee4 == 2)
        {
            head4 = 1;
        }

        numchose = UnityEngine.Random.Range(0, 200);
        while (PrimeNumbs.Contains(numchose) || normalchose2 == numchose)
        {
            numchose = UnityEngine.Random.Range(0, 200);
        }

        aritmaticheadthrerehend[head4].text = numchose.ToString();
    }

    public void attackwop()
    {
        Debug.Log(426);
        if (leveltherecheck == 0)
        {
            textdisplay.text = "<u>אחד:</u> אתה יותר חזק ממה שחשבתי שתהיה, אך עדיין אתה לא משתווה בכוחך למפלצת האריטמטיק שלי, אין לך סיכוי להצליח להבין איך עובד עיקרון ה-POW";
        }
        int randchosee5 = 0;
        int randchosee6 = 0;
        int randchosee7 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        int head5 = 5;
        thesmallest = 0;
        randchosee5 = UnityEngine.Random.Range(0, 2);
        randchosee6 = UnityEngine.Random.Range(0, 2);
        while (randchosee5 == randchosee6)
        {
            randchosee6 = UnityEngine.Random.Range(1, 3);
        }

        num4 = UnityEngine.Random.Range(0, 200);
        num5 = UnityEngine.Random.Range(0, 200);
        while (num4 == num5)
        {
            num5 = UnityEngine.Random.Range(0, 200);
        }


        aritmaticheadtwohend[randchosee5].text = num4.ToString();
        aritmaticheadtwohend[randchosee6].text = num5.ToString();


        if (randchosee5 == 0 && randchosee6 == 1)
        {
            head5 = 2;
        }

        else if (randchosee5 == 1 && randchosee6 == 2)
        {
            head5 = 0;
        }

        else if (randchosee5 == 2 && randchosee6 == 1)
        {
            head5 = 0;
        }

        else if (randchosee5 == 2 && randchosee6 == 0)
        {
            head5 = 1;
        }

        else if (randchosee5 == 1 && randchosee6 == 0)
        {
            head5 = 2;
        }

        else if (randchosee5 == 0 && randchosee6 == 1)
        {
            head5 = 2;
        }

        else if (randchosee5 == 0 && randchosee6 == 2)
        {
            head5 = 1;
        }

        num6 = UnityEngine.Random.Range(0, 200);
        while (num4 == num6 || num5 == num6)
        {
            num6 = UnityEngine.Random.Range(0, 200);
        }

        aritmaticheadtwohend[head5].text = num6.ToString();
        int tempnum = 0;
       
        if (num4 < num5)
        {
            thesmallest = num4;
            if (thesmallest > num6)
            {
                thesmallest = num6;
                numwop1 = num4;
                numwop2 = num5;
            }

            else
            {
                thesmallest = num4;
                numwop1 = num6;
                numwop2 = num5;
            }
        }

        else if (num5 < num4)
        {
            thesmallest = num5;
            if (thesmallest > num6)
            {
                thesmallest = num6;
                numwop1 = num4;
                numwop2 = num5;
            }
            else
            {
                thesmallest = num5;
                numwop1 = num4;
                numwop2 = num6;
            }
        }

        else if (num6 < num4)
        {
            thesmallest = num6;
            if (thesmallest > num5)
            {
                thesmallest = num5;
                numwop1 = num4;
                numwop2 = num6;
            }
            else
            {
                thesmallest = num6;
                numwop1 = num4;
                numwop2 = num5;
            }
        }

        Debug.Log("the smallest is: " + thesmallest + " the first num is: " + num4 + " the second num is: " + num5 + " the third num is: " + num6);






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

    public void findtheprime(string s)
    {
        input = s;//contiue from here
        string a = inputdata.GetComponent<TMP_InputField>().text;
        if (a == "")
        {
            a = inputdata.text;
            Debug.Log(a);
        }
        Debug.Log("the chosen is: " + a);
        //Debug.Log("the string is: " + input);
        primenum = Convert.ToInt32(a);
        checkprimeis();
    }

    public void checkprimeis()
    {
        Debug.Log("the prime is: " + theprime);
        Debug.Log("the number chosen num is: " + primenum);
        if (theprime == primenum)
        {
            Debug.Log(505);
            textdisplay.text = "<u>אחד:</u> אוי לא ! נראה שאני זלזלתי בכם לחינם, הצלחתם לפגוע במפלצת שלי, אך לא די בכך על מנת להביס אותה!";
            levelonecheck2++;
            if (levelonecheck2 < 3)
            {
                theprime = 0;
                primenum = 0;
                primechose3 = 0;
                inputdata.GetComponent<TMP_InputField>().text = string.Empty;
                normalchose2 = 0;

                AttackPrimes();
            }

            else
            {
                Debug.Log(521);
                textdisplay.text = "<u>אחד:</u> אני לא מאמין!!!! הצלחתם להוריד לה עוד זרוע, אבל אל חשש ואל דאגה, גם עם שתי זרועות היא אלופה מוחעחעחעחעחע!";
                inputdata.GetComponent<TMP_InputField>().text = string.Empty;
                primedone = true;

                //hide the inputbox area and hide the old obstic
                inputfield.GetComponent<SpriteRenderer>().enabled = false;
                canvaholder.GetComponent<Canvas>().enabled = false;
                inputdata.GetComponent<TMP_InputField>().enabled = false;
                therehands.GetComponent<SpriteRenderer>().enabled = false;

                //hide the base of numbers for check
                aritmaticheadthrerehend[0].GetComponent<TextMeshProUGUI>().enabled = false;
                aritmaticheadthrerehend[1].GetComponent<TextMeshProUGUI>().enabled = false;
                aritmaticheadthrerehend[2].GetComponent<TextMeshProUGUI>().enabled = false;

                //show the mang and the new obstic
                twohands.GetComponent<SpriteRenderer>().enabled = true;
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
                inlevel = false;


            }

        }
        else if (primenum == numchose || primenum == normalchose2)
        {
            inputdata.GetComponent<TMP_InputField>().text = string.Empty;
            Debug.Log(548);
            textdisplay.text = "<u>אחד:</u> אתה לא מבדיל עדיין בין מספר ראשוני למספר פריק!!! איזה אפס אתה!";
        }
        else
        {
            inputdata.GetComponent<TMP_InputField>().text = string.Empty;
            Debug.Log(553);
            textdisplay.text = "<u>אחד:</u> ידעתי שאין לך סיכוי מול המפלצת שלי, אולי כדי שתחזור ללמוד מה זה מספרים ראשונים ורק אחרי זה תנסה לבוא נגדה עוד פעם";
        }
    }


    public void findthecompose(string s)
    {
        if (composedone == false)
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

        else if (composedone == true && primedone == false)
        {
            input = s;//contiue from here
            string a = inputdata.GetComponent<TMP_InputField>().text;
            if (a == "")
            {
                a = inputdata.text;
                Debug.Log(a);
            }
            Debug.Log("the chosen is: " + a);
            //Debug.Log("the string is: " + input);
            primenum = Convert.ToInt32(a);
            checkprimeis();
        }

        else if (composedone == true && primedone == true && wopdone == false)
        {
            input = s;//contiue from here
            string a = inputdata.GetComponent<TMP_InputField>().text;
            if (a == "")
            {
                a = inputdata.text;
                Debug.Log(a);
            }
            Debug.Log("the chosen is: " + a);
            //Debug.Log("the string is: " + input);
            wopone = Convert.ToInt32(a);
            checkwop();
        }

        else if (composedone == true && primedone == true && wopdone == true && primediviesdone == false)
        {
            input = s;//contiue from here
            string a = inputdata.GetComponent<TMP_InputField>().text;
            if (a == "")
            {
                a = inputdata.text;
                Debug.Log(a);
            }
            Debug.Log("the chosen is: " + a);
            //Debug.Log("the string is: " + input);
            thesum = Convert.ToInt32(a);
            cheackdivides();
        }



        }

    public void checkwop()
    {
        Debug.Log("the wop is: " + thesmallest);
        Debug.Log("the number chosen num is: " + wopone);
        if (thesmallest == wopone)
        {
            Debug.Log(769);
            textdisplay.text = "<u>אחד:</u> אני לא מאמין שאני אומר את זה, אך אני מתרשם שעמדתי את כוכחם לא נכון, אך עדיין לא די בכך על מנת להביס את המפלצת שלי";
            leveltherecheck++;
            if (leveltherecheck < 3)
            {
                thesmallest = 0;
                inputdata.GetComponent<TMP_InputField>().text = string.Empty;
                attackwop();
            }

            else
            {
                Debug.Log(780);
                textdisplay.text = "<u>אחד:</u> אני לא מאמין!!!! הצלחתם להוריד לה עוד זרוע, אבל אל חשש ואל דאגה, גם עם שתי זרועות היא אלופה מוחעחעחעחעחע!";
                inputdata.GetComponent<TMP_InputField>().text = string.Empty;
                wopdone = true;

                //hide the inputbox area and hide the old obstic
                inputfield.GetComponent<SpriteRenderer>().enabled = false;
                canvaholder.GetComponent<Canvas>().enabled = false;
                inputdata.GetComponent<TMP_InputField>().enabled = false;
                twohands.GetComponent<SpriteRenderer>().enabled = false;

                //hide the base of numbers for check
                aritmaticheadtwohend[0].GetComponent<TextMeshProUGUI>().enabled = false;
                aritmaticheadtwohend[1].GetComponent<TextMeshProUGUI>().enabled = false;
                aritmaticheadtwohend[2].GetComponent<TextMeshProUGUI>().enabled = false;

                //show the mang and the new obstic
                onehands.GetComponent<SpriteRenderer>().enabled = true;
                attackMang.GetComponent<SpriteRenderer>().enabled = true;
                inlevel = false;
                one.GetComponent<SpriteRenderer>().enabled = false;


            }

        }
        else if (wopone == numwop1 || wopone == numwop2)
        {
            Debug.Log(819);
            inputdata.GetComponent<TMP_InputField>().text = string.Empty;
            textdisplay.text = "<u>אחד:</u> אתה לא יודע אפילו מהו מספר גדול ומהו מספר קטן, חחחחח";
        }
        else
        {
            Debug.Log(824);
            inputdata.GetComponent<TMP_InputField>().text = string.Empty;
            textdisplay.text = "<u>אחד:</u> ידעתי שאין לך סיכוי מול המפלצת שלי, אולי כדי שתחזור כמה צעדים אחורה ותלמד מה זה ציר המספרים, למה הכיוון שלך שגוי";
        }
    }

    public void cheackdivides()
    {
        Debug.Log("the sum is: " + sumofprimes);
        Debug.Log("the number chosen num is: " + thesum);
        if (sumofprimes == thesum)
        {
            Debug.Log(858);
            textdisplay.text = "<u>אחד:</u> אני מרגיש שמפלצת האריטמיק הולכת להיות מובאסת בקרוב, עוד קצת, בבקשה אני חייב את עזרתך";
            levelfourcheck++;
            if (levelfourcheck < 3)
            {
                sumofprimes = 0;
                thesum = 0;
                inputdata.GetComponent<TMP_InputField>().text = string.Empty;
                AttackDivdes();

            }

            else
            {
                Debug.Log(976);
                textdisplay.text = "<u>אחד:</u> אני מצטער ,אני מצטער, אין ביכולתך את האפשרות לדעת כמה אסיר תודה אני על כך שהצלת אותי, אני מצטער!";
                inputdata.GetComponent<TMP_InputField>().text = string.Empty;
                primediviesdone = true;

                //hide the inputbox area and hide the old obstic
                inputfield.GetComponent<SpriteRenderer>().enabled = false;
                canvaholder.GetComponent<Canvas>().enabled = false;
                inputdata.GetComponent<TMP_InputField>().enabled = false;
                onehands.GetComponent<SpriteRenderer>().enabled = false;

                //hide the base of numbers for check
                aritmaticheadonehend[0].GetComponent<TextMeshProUGUI>().enabled = false;
                aritmaticheadonehend[1].GetComponent<TextMeshProUGUI>().enabled = false;
                aritmaticheadonehend[2].GetComponent<TextMeshProUGUI>().enabled = false;

                //show the mang and the new obstic
                //onehands.GetComponent<SpriteRenderer>().enabled = true;
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                inlevel = false;
                one.GetComponent<SpriteRenderer>().enabled = true;
                gold.GetComponent<SpriteRenderer>().enabled = true;
                item.GetComponent<SpriteRenderer>().enabled = true;


            }

        }
        else if (thesum == firstprime || thesum == secondprime || thesum ==theprime)
        {
            inputdata.GetComponent<TMP_InputField>().text = string.Empty;
            Debug.Log(1001);
            textdisplay.text = "<u>אחד:</u> אני חושש שהמטרה היא שתגיד מה הכפולה המשותפת של שלוש המספרים הראשוניים הללו";
        }
        else
        {
            inputdata.GetComponent<TMP_InputField>().text = string.Empty;
            Debug.Log(1007);
            textdisplay.text = "<u>אחד:</u> בבקשה אני מאמין ביכולתך, תעשה כל מה שאתה יכול על מנת להצליח לנחש מהי הכפולה המשותפת שלהם";
        }
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
                inputdata.GetComponent<TMP_InputField>().text = string.Empty;

                attackcompose();
            }

            else
            {
                textdisplay.text = "<u>אחד:</u> הצלחת אומנם להוריד למפלצת שלי את אחת הזרועות, אך היא עדיין חזקה ממך!";
                inputdata.GetComponent<TMP_InputField>().text = string.Empty;
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
            inputdata.GetComponent<TMP_InputField>().text = string.Empty;
            textdisplay.text = "<u>אחד:</u> אתה לא מבדיל עדיין בין מספר ראשוני למספר פריק!!! איזה אפס אתה!";
        }
        else
        {
            inputdata.GetComponent<TMP_InputField>().text = string.Empty;
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

    public void InitilizePrimes()
    {
        PrimeNumbs.Add(2);
        PrimeNumbs.Add(3);
        PrimeNumbs.Add(5);
        PrimeNumbs.Add(7);
        PrimeNumbs.Add(11);
        PrimeNumbs.Add(13);
        PrimeNumbs.Add(17);
        PrimeNumbs.Add(19);
        PrimeNumbs.Add(23);
        PrimeNumbs.Add(29);
        PrimeNumbs.Add(31);
        PrimeNumbs.Add(37);
        PrimeNumbs.Add(41);
        PrimeNumbs.Add(47);
        PrimeNumbs.Add(53);
        PrimeNumbs.Add(59);
        PrimeNumbs.Add(71);
        PrimeNumbs.Add(83);
        PrimeNumbs.Add(89);
        PrimeNumbs.Add(101);
        PrimeNumbs.Add(107);
        PrimeNumbs.Add(113);
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
