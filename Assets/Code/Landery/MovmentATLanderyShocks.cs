using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentATLanderyShocks : MonoBehaviour
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
  //  bool done = LaFarmaBox.missiondone = false;


    //mission items
    public GameObject[] Shocks;
    public Stack<int> ShocksStack;
    public int TheNumberOfSocks;
    public string Shock;
    public int current = 0;
    public bool sockDown = false;
    public bool IsAdoptedStuff = false;
    public GameObject Ashock;
    public Transform StuffParent;
    public int[] DoubleShock = new int[2];
    public int[] allshocksin = new int[16];
    int alradyCounted;
    public string gold;
    public int getgold = 0;

    //talking
    public TextMeshProUGUI textdisplay;

    public GameObject InvatoryForUSe;
    public ReflactorChecl refl;

    //fire handler
    public FireHAndler fires;
    public bool fireOn;




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Shock)
        {
            //T key down -> take staff
            if (Input.GetKeyDown(KeyCode.T) || Input.GetKey("t"))
            {
                // Debug.LogError("54");
                if (IsAdoptedStuff == false)
                {
                    if (refl.firstaken == false)
                    {
                        textdisplay.text = "<u> הרפלקטור:</u> הו אני רואה שהצלחת לתפוס גרב ביד, במידה ואין גרב על המסך תעבור ליד הגרב האחרונה שהפלת מהחבל" ;
                       // refl.firstaken = true;
                    }
                    
                    Ashock = collision.gameObject;
                    StuffParent = collision.transform.parent;
                    collision.gameObject.transform.parent = this.transform;
                    collision.gameObject.transform.localPosition = Vector3.zero;
                    IsAdoptedStuff = true;
                    Debug.Log("here with la farma 28");

                }

            }


        }

        if (collision.gameObject.tag == gold)
        {
            getgold = getgold + 1;
            Debug.Log("you have: " + getgold);
            refl.gold.SetActive(false);
            SingleToon.getInstance().curmoney.gain(1200);
            //SingleToon.getInstance().curscore.raise(50);
        }
    }


    public void reSetArray()
    {
        DoubleShock[0] = -1;
        DoubleShock[1] = -2;
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

        //click on f
        else if (Input.GetKeyDown(KeyCode.F) || Input.GetKey("f"))
        {

            shoot();
            return transform.position;
        }

        //M key down -> open invatory
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(InvatoryForUSe);
            return transform.position;
        }


        //G key down -> take staff
        else if (Input.GetKeyDown(KeyPanel.Put))
        {
            if (IsAdoptedStuff == true)
            {
                float height;
                IsAdoptedStuff = false;
                if (refl.firstaken == false)
                {
                    textdisplay.text = "<u> הרפלקטור:</u> תודה רבה על הגרב, האם תוכל למצוא גרב מתאימה לה?" + "\n" + "אשמח אם הגרב תועבר למקום אחר";
                    refl.firstaken = true;
                }
                
                Ashock.transform.parent = StuffParent;
                height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                Ashock.transform.position = new Vector3(transform.position.x, transform.position.y - height / 4, transform.position.z);
                Debug.Log("mon bian 89: " + Ashock.transform.position);
                //return transform.position;
            }
            else
            {
                return transform.position;
            }
            return transform.position;

        }


        return transform.position;
    }

    public void shoot()
    {
        if (!fireOn)
        {
            Instantiate(this.fires, this.transform.position, Quaternion.identity);
            fireOn = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = NewPosition();
    }


    private void Start()
    {

        textdisplay.text = " <u> רפלקטור:  </u> עליך לאסוף צמדים זהים של גרביים, על מנת לתפוס גרב, יש תחילה להוריד אותה מהחבל על ידי שימוש בדומיין בעזרת לחיצה על המקש H" + "\n" + "על מנת להרים גרב ולהביא אותה אלי, יש לחכות שהיא תגיע לאדמה וברגע שהיא על האדמה, לקחת אותה באמצעות T לכניסה לבית מימין " + "\n" + "על מנת  לשים את הגרב יש ללחוץ על המקש G.";
        sockDown = true;
        ShocksShow();
        reSetArray();
    }

    public void ShocksShow()
    {
        if (sockDown == true && current!= Shocks.Length)
        {
            Debug.LogWarning(180);
            int randomNum = Random.Range(0, Shocks.Length);
            Debug.LogWarning("the random num is:" +randomNum);
            while (alradyPushd(randomNum) == true)
            {
                randomNum = Random.Range(0, Shocks.Length);
            }
            Shocks[randomNum].SetActive(true);
            Debug.LogWarning("the random num is:" + randomNum + "set active");
            allshocksin[current] = randomNum;
            current++;
            sockDown = false;

        }


    }

    public bool alradyPushd(int randomnum)
    {
        int countin = 0;
        for (int i = 0; i < allshocksin.Length; i++)
        {
            if (randomnum == allshocksin[i])
            {
                if (randomnum > 5)
                {
                    return true;
                }

                else if (randomnum <= 5)
                {
                    countin++;
                    if (countin == 2)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
        }
        return false;
    }



}
