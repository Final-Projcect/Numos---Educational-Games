using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //levels items
    public GameObject attackMang;

    //level achiments 
    public GameObject gold;
    public GameObject item;
    public GameObject[] coinsone;
    public GameObject[] coinstwo;
    public GameObject[] coinsthree;
    public GameObject relseking;

    //Aritmatic Monster
    public GameObject fourhands;
    public GameObject therehands;
    public GameObject twohands;
    public GameObject onehands;



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
        else if (Input.GetKeyDown(KeyCode.C) || Input.GetKey("c"))
        {
            SceneManager.LoadScene("KingPotionNew");
            return transform.position; // Pass into ohter secne
        }

        //click on b
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("b"))
        {

            textdisplay.text = "<u>אחד:</u> אין לך סיכוי להגיע למלך לפני שתביס את מפלצת האריטמיק שלי!" + "\n" + "מה התגובה שלך:" + "\n" + " א. לברוח - לחצו על C" + "\n" + "ב. להלחם במפלצת ולהציל את המלך - לחצו על A";
            return transform.position;
        }


        //click on a
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey("a"))
        {

            textdisplay.text = "<u>אחד:</u> אני רואה שאומץ לא חסר לך, אבל חבל! אין לך סיכוי לנצח את מפלצת האירטמיק, כל רגל של האלופה הקטנה שלי כוללת הוכחה מסוג אחר, ככה שעל מנת לנצח אותה עליך לבחור את הכלים המתאימים ולהוכיח אותם, דבר שהוא לא אפשרי מוחעחעחעחע מפלצת האריטמיק אל תוותרי!!, ";
            startgame = true;
            AttackAritmatic();
            return transform.position;
        }

        else
        {
            return transform.position;
        }



    }

    
    public void AttackAritmatic ()
    {
        if (startgame == true)
        {
            if (attackManger==false)
            {
                attackMang.GetComponent<SpriteRenderer>().enabled = false;
                attackManger = true;
            }
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
