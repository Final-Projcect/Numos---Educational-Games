using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovmentAtTreeQuest : MonoBehaviour
{
    enum names { R1=0, R2=1, R3=2};
    //jumping
    public float jumpForce = 10;
    public float jumpForceEffectByMomentomRatio;
    public float speed = 4f;
    //private Dictionary<string, GameObject> _woodInventory;
    private List <GameObject> _woodInventory;
    public int Fill;

    //public Canvas;
    //the invatory object
    public GameObject Instruction;
    private GameObject fordestroy;
    bool exist = false;

    //check if misson done
    bool done = LaFarmaBox.missiondone = false;

    //talking
    public TextMeshProUGUI textdisplay;

    public GameObject InvatoryForUSe;
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

        //W key down -> open invatory
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("hi" + transform.position);
            return transform.position;
        }
        //9.8 -3.5 00 - move to cave
        //194.1 -3.5 00 - left rnternce to landery
        //206.7 -3.5 00 - right enternce to landery
        //309.0 -3.5 00 - 315.0 -3.5 00 - entenrce to cave




        else
        {
            return transform.position;
        }
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

   /* private void UpdateWoodInventory(GameObject branch)
    {
        _woodInventory.Add(branch.name, branch);
    }*/

    private void UpdateWoodInventory(GameObject branch)
    {
        _woodInventory.Add(branch);
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
            for (int i = 0; i < count.Length ;i++)
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

    void Start()
    {
       // textdisplay.text =   "שלום, אמשח אם תוכלו בבקשה לעזור לי להגיע לצמרת העץ" + "\n" + "על מנת שאוכל לטפס למעלה עלי לאסוף צמדים של ענפים שהם מאותו הסוג והצבע על מנת שאוכל להרים ענף עלי ללחוץ על המקש G" + "\n" + "כל פעם אחרי שאספתי 2 ענפים עלי ללחוץ על המקש R על מנת לבדוק שהם זהים, במידה וכן אז הבר של הענפים יתמלא, ברגע שהבר יהיה מלא לחלוטין אוכל ללחוץ על L ולקבל סולם";
       //_woodInventory = new Dictionary<string, GameObject>();
        _woodInventory = new List<GameObject>();
    }

}
