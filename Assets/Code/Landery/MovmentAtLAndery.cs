using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentAtLAndery : MonoBehaviour
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

    //talking
    public TextMeshProUGUI textdisplay;

    public GameObject InvatoryForUSe;

    private List<GameObject> _woodInventory;
    public int Fill;
    enum names { R1=0, R2=1, R3=2}; 

    private void UpdateWoodInventory(GameObject branch)
    {
        _woodInventory.Add(branch);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "RefBreach" && Input.GetKey(KeyCode.G))
        {
            collision.transform.parent = this.transform;
            collision.gameObject.SetActive(false);
            UpdateWoodInventory(collision.gameObject);
        }
    }



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

        //click on a
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey("a"))
        {
            SceneManager.LoadScene("TheLanderyChallange");
            return transform.position; //ToDo Pass into ohter secne
        }

        //click on b
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("b"))
        {
            if (exist == false)
            {
                textdisplay.text = "במידה וברצונך לשוחח או לעזור, תועיל בטובך ללחוץ על המקש X";
                fordestroy = Instantiate(Instruction);
                exist = true;
            }



            return transform.position; //ToDo Pass into ohter secne
        }

        //click on x
        else if (Input.GetKeyDown(KeyCode.X) || Input.GetKey("x"))
        {
            if (exist == true)
            {
                Destroy(fordestroy);
                exist = false;
            }



            textdisplay.text = " <u> רפלקטור:  </u> שלום אתה בוודאי חדש באזור! אני הוא הרפלקטור, האם אוכל לשאול מה חיפשת פה בסביבה?" + "\n" + "                  א . אם תעסוקה אתה מחפש - תלחץ על המקש A" + "\n" + "                   ב. להשיג זוג גרביים - לחצו על B                   " + "\n" + "                   ג. לבקש רמז - לחצו על C" + "\n" + "                   ד. לטייל פה באזור ולהסתכל - לחצו על D";
            return transform.position; //ToDo Pass into ohter secne
        }

        //click on c
        else if (Input.GetKeyDown(KeyCode.C) || Input.GetKey("c"))
        {
            if (done == true)
            {
                textdisplay.text = "כולנו חברים, האחד לשני תמיד עוזרים ,בייחוד אחרי שלנו טובה מכירים, במידה ואתה מחפש רמזים, גש אל המערה שמה בוודאי תמצא את הפיסה החסרה !";
            }
            else
                textdisplay.text = "הכביסה שלי לא תתלה את עצמה ולי אין זמן לבזבז, " + "\n" + "אם אתה מחפש אותי תלחץ על המקש R";
            return transform.position; //ToDo Pass into ohter secne
        }


        //click on d
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey("d"))
        {
            textdisplay.text = "אם אתה צריך עזרה או רוצה לעשות משהו אחר תקרא לי על ידי לחיצה על המקש X";
            return transform.position; //ToDo Pass into ohter secne
        }

        //click on R
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKey("r"))
        {
            textdisplay.text = " <u> רפלקטור:  </u> שלום אתה בוודאי חדש באזור! אני הוא הרפלקטור, האם אוכל לשאול מה חיפשת פה בסביבה?" + "\n" + "                  א . אם תעסוקה אתה מחפש - תלחץ על המקש A" + "\n" + "                   ב. להשיג זוג גרביים - לחצו על B                   " + "\n" + "                   ג. לבקש רמז - לחצו על C" + "\n" + "                   ד. לטייל פה באזור ולהסתכל - לחצו על D";
            return transform.position; //ToDo Pass into ohter secne
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


        else
        {
            return transform.position;
        }



    }



    // Update is called once per frame
    void Update()
    {
        transform.position = NewPosition();
        if (Input.GetKeyDown(KeyCode.R))
            if (checkedIdentical())
            {
                Fill = 1;
            }
    }

    private bool checkedIdentical()
    {
        int size = Enum.GetNames(typeof(names)).Length;
        int[] count = new int[size];


        foreach (GameObject B in _woodInventory)
        {
            names newName = (names)Enum.Parse(typeof(names), B.name);
            count[(int)newName]++;
        }




        if (_woodInventory.Count < 2)
        {
            textdisplay.text = " על מנת לבדוק האם שני ענפים זהים יש לאסוף קודם 2 ענפים" + _woodInventory.Count;
        }

        if (_woodInventory.Count > 2)
        {
            textdisplay.text = "לצערי אספתם יותר מדי, אנא השתדלו לאסוף כל פעם רק זוגות ענפים." + _woodInventory.Count;
            _woodInventory.Clear();
            return false;
        }
        bool check = false;
        if (_woodInventory.Count == 2)
        {
            textdisplay.text = "יש לך שני ענפים." + _woodInventory.Count;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] == 2)
                {
                    check = true;
                    break;
                }
            }

            if (check == true)
            {
                textdisplay.text = "מעולה מצאתם שני ענפים זהים! כל הכבוד, תאספו עוד שני צמדים ואוכל להכין מהם סולם.";
                _woodInventory.Clear();
                return true;
            }
            else
            {
                textdisplay.text = "לצערי שני הענפים שונים לכן אני לא יכול להכין מהם את הסולם.." + _woodInventory.Count;
                _woodInventory.Clear();
                return false;
            }
            return false;
        }

        /*foreach (int num in count)
        {
            

            if (num > 1)
            {
                return true;
            }
        }*/

        return false;
    }

    private void Start()
    {
        _woodInventory = new List<GameObject>();
        textdisplay.text = " <u> רפלקטור:  </u> שלום אתה בוודאי חדש באזור! אני הוא הרפלקטור, האם אוכל לשאול מה חיפשת פה בסביבה?" + "\n" + "                  א. אם תעסוקה אתה מחפש - תלחץ על המקש A" + "\n" + "                   ב. להשיג זוג גרביים - לחצו על B                   " + "\n" + "                   ג. לבקש רמז - לחצו על C" + "\n" + "                   ד. לטייל פה באזור ולהסתכל - לחצו על D";

    }
}
