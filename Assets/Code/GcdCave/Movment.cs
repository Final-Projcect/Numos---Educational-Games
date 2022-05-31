using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //How much time the player can hang in the air before jumping
    private float coyoteCounter; //How much time passed since the player ran off the edge

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpX; //Horizontal wall jump force
    [SerializeField] private float wallJumpY; //Vertical wall jump force

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    public GameObject InvatoryForUSe;


    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    //the invatory object
    public GameObject Instruction;
    private GameObject fordestroy;
    bool exist = false;

    //check if misson done
    public static bool missiondone = false;

    //text display
    public TextMeshProUGUI textdisplay;

    //gold prize
    public GameObject Goldwin1;
    public GameObject Goldwin2;
    public GameObject Goldwin3;
    public string coin;
    public string gold;
    int getgold = 0;
    int getcoin = 0;

    //TreeKing Lev1
    public GameObject KingHead;
    public GameObject leaf;
    public bool leaded = false;
    public bool handeddd = false;
    public bool golded = false;
    public GameObject hanged;
    public GameObject KingHead2;
    public GameObject KingHead3;
    public GameObject KingHead4;
    public GameObject KingHead5;
    private GameObject takenkinghead;
    private Transform KingHeadParent;
    public string king;
    private bool haveking = false;
    private bool onplace = false;
    public GameObject blocklevel1;

    //StandJump Lev2
    public GameObject stand1;
    public GameObject stand2;
    public GameObject stand3;
    public GameObject KingHead6;
    public GameObject KingHead7;
    private GameObject standonstand;
    public string jumpstand;
    public string stand;
    public string water;
    public bool lev2done = false;
    public GameObject cantgoafter;

    //change the places after finish level2
    public GameObject waterground1;
    public GameObject ground1;

    //change the places after finish level3
    public GameObject waterground2;
    public GameObject ground2;


    //StandJump Lev3
    public GameObject stand4;
    public GameObject stand5;
    public GameObject stand6;
    public GameObject KingHead8;
    public GameObject KingHead9;
    public string blocks;
    public bool lev3done = false;
    public string jumpstand2;
    public GameObject welldone;

    // The initial position of the GameObject
    Vector3 initialPosition;

    //block the next place
    public GameObject block;
    public RandomNumbs ranums = new RandomNumbs();
    public WrongStand rigt = new WrongStand();
    bool donald = false;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected Vector3 NewPosition()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(transform.position);
            return transform.position;
        }

        else if (Input.GetKey(KeyCode.C))
        {
            Debug.Log(transform.position);
            return transform.position;
        }

        //leftMovement
        else if (Input.GetKey(KeyPanel.MoveLeft))
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


        else
        {
            return transform.position;
        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == water)
        {
            SingleToon.getInstance().curlife.damage(100);
        }

        if (collision.gameObject.tag == coin)
        {
            getcoin = getcoin + 1;
            Debug.Log("you have: " + getcoin);
            SingleToon.getInstance().curmoney.gain(100);
            SingleToon.getInstance().curscore.raise(10);
        }

        if (collision.gameObject.tag == gold)
        {
            getgold = getgold + 1;
            Debug.Log("you have: " + getgold);
            SingleToon.getInstance().curmoney.gain(500);
            SingleToon.getInstance().curscore.raise(50);
        }

        //rigt = new WrongStand()
        //donald = rigt.right;

        else if (collision.gameObject.tag == jumpstand)
        {
            golded = false;
            Debug.Log("276");
            // int standnum = collision.gameObject.GetComponent<NumOnking>().NumAtking();
            standonstand = collision.gameObject;
            //int standnum = standonstand.GetComponent<NumOnking>().NumAtking();
            bool good = standonstand.GetComponent<WrongStand>().right;
            //collision.gameObject.GetComponent<WrongStand>().right ;
            //ranums = new RandomNumbs();
            //int oneside = Int32.Parse(ranums.Stand1Package[0].text);
            //Debug.Log("the first is: " + oneside);
            //int secondside = Int32.Parse(ranums.Stand1Package[2].text);
            //Debug.Log("the second is: " + secondside);


            // if (standnum == oneside || standnum == secondside)
            if (good == true && lev2done == false)
            {
                textdisplay.text = "<u> קווין תשע:</u> כל הכבוד! ,כמו שאתה רואה ישנם מספרים שהם המחלקים המשותפים של עצמם ושל מספרים הגבוהים מהם" + "\n" + "כעת הגענו לרגע המכריע, האם תוכל למצוא את המחלק המשותף של המספרים הללו?";

                Debug.Log("288");
                {
                    Destroy(cantgoafter);
                    //Instantiate(ground1);
                    Destroy(waterground1);
                    lev2done = true;
                    Destroy(stand1);
                    Destroy(stand2);
                    Destroy(stand3);
                    //lev3done = true;
                    if (golded == false)
                    {
                        Instantiate(Goldwin2);
                        golded = true;
                    }

                }
            }

            else
            {
                Debug.Log("309");
                if (lev2done==false)
                {
                    textdisplay.text = "<u> קווין תשע:</u> כדאי שתנסה פעם נוספת";
                }
                
            }
        }

        else if (collision.gameObject.tag == jumpstand2)
        {
            golded = false;
            Debug.Log("276");
            // int standnum = collision.gameObject.GetComponent<NumOnking>().NumAtking();
            standonstand = collision.gameObject;
            //int standnum = standonstand.GetComponent<NumOnking>().NumAtking();
            bool good = standonstand.GetComponent<WrongStand>().right;

            if (good == true && lev3done == false)
            {
                textdisplay.text = "<u> קווין תשע:</u> כל הכבוד! הצלחת לסיים את המשימה בהצלחה" + "\n" + "כעת אתה מכיר את עיקרון ה-GCD שאומר שקיים מספר שהוא המחלק המשותף הגבוהה ביותר של שני מספרים" + "\n" + "רכיב ה-DCG נוסף לתרמילך, תמשיך עם כיוון המערה וייתכן שתגיע ליעדך";

                Debug.Log("233");
                {

                    Destroy(welldone);
                    //Instantiate(ground1);
                    Destroy(waterground2);
                    Destroy(stand4);
                    Destroy(stand5);
                    Destroy(stand6);
                    //lev2done = true;
                    if (golded == false)
                    {
                        Instantiate(Goldwin3);
                        golded = true;
                    }


                }
            }

            else
            {
                Debug.Log("309");
                textdisplay.text = "<u> קווין תשע:</u> כדאי שתנסה פעם נוספת, תנסה למצוא את המספר הכי גבוהה שמתחלק בין שני המספרים התלויים";
            }
        }

        else if (collision.gameObject.tag == king)
        {
            if (haveking != true)
            {
                //T key down -> take staff
                if (Input.GetKeyDown(KeyPanel.Take))
                {

                    takenkinghead = collision.gameObject;
                    //BrickParent = collision.transform.parent;
                    //collision.gameObject.transform.parent = this.transform;
                    // collision.gameObject.transform.localPosition = Vector3.zero;
                    // alredyrabbitinhand = true;


                    takenkinghead = collision.gameObject;
                    KingHeadParent = collision.transform.parent;
                    collision.gameObject.transform.parent = this.transform;
                    collision.gameObject.transform.localPosition = Vector3.zero;
                    haveking = true;
                    Debug.Log("yay we got a king");

                }
            }

        }

        else if (haveking == true)
        {

            if (Input.GetKeyDown(KeyPanel.Put))
            {
                Debug.Log("yay 193");
                float height;
                haveking = false;
                bool currectstuff = false;
                //int currectLevel = collision.gameObject.GetComponent<RandomeNumbers>().level;
                takenkinghead.transform.parent = KingHeadParent;
                height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                takenkinghead.transform.position = new Vector3(transform.position.x, transform.position.y - (height / 4), transform.position.z);
                //currectstuff = collision.gameObject.GetComponent<RandomeNumbers>().checkifcurrect(takenkinghead);
                if (collision.gameObject.tag == stand)
                {
                    Debug.Log("yo 204");
                    onplace = true;
                    //int num = collision.gameObject.GetComponent<RandomNumbs>().NumAtSign(takenkinghead);
                    int num = 0;

                    num = takenkinghead.gameObject.GetComponent<NumOnking>().NumAtking();

                    Debug.Log("pi 207 " + num);
                    ranums = new RandomNumbs();
                    if (num == 1)
                    {

                        //donald = ranums.getit;
                        Debug.Log("do 210 " + donald);
                        //donald = true;
                        ranums.getit = true;////fix with ofek
                        //donald = rigt.right;
                        Debug.Log("do 234");
                        Destroy(takenkinghead);
                        if (leaded == false)
                        {
                            //Destroy(leaf);
                            leaded = true;
                        }

                        if (handeddd == false)
                        {
                            Instantiate(hanged);
                            handeddd = true;
                        }

                        if (golded == false)
                        {
                            Instantiate(Goldwin1);
                            golded = true;
                        }

                        Destroy(blocklevel1);
                        //textdisplay.text = "כל הכבוד, כעת עליך לעבור את חידת המחלק המשותף של המספרים הבאים, במידה ותעמוד על האבן הנכונה אז אולי תוכל להשיג יבשה";
                        textdisplay.text = "<u> קווין תשע:</u> כל הכבוד לך!! הצלחת למצוא את המחלק המשותף הגבוהה בין השני הענפים " + "\n" + "  כמו שאתה רואה בגלל שהמספרים על הענפים הם זרים - כלומר אין קשר בין האחד לשני, אז המחלק המשותף בינהם הוא 1. כי שניהם בעצם מתחלקים רק ב-1" + "\n" + " כעת על מנת לעבור את המשימה הבאה, עלייך לדרוך על הסטנד עם המחלק המשותף הנכון המתאים לשני המחלקים התלויים, היזהר לא ליפול למים, הם עמוקים.";


                    }
                    else
                        textdisplay.text = "<u> קווין תשע:</u> חוששני שזה לא המחלק המשותף ביניהם, אם תשים לב אז הם לא מתחלקים בו יחד.";


                }
            }
        }

        
    }



  

        private void Update()
    {

        //moving
        transform.position = NewPosition();



        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //shake();
            Jump();

        }



        //Adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        if (onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isGrounded())
            {
                coyoteCounter = coyoteTime; //Reset coyote counter when on the ground
                jumpCounter = extraJumps; //Reset jump counter to extra jump value
            }
            else
                coyoteCounter -= Time.deltaTime; //Start decreasing coyote counter when not on the ground
        }
    }

    private void Jump()
    {
        if (coyoteCounter <= 0 && !onWall() && jumpCounter <= 0) return;
        //If coyote counter is 0 or less and not on the wall and don't have any extra jumps don't do anything



        if (onWall())
            WallJump();
        else
        {
            if (isGrounded())
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            else
            {
                //If not on the ground and coyote counter bigger than 0 do a normal jump
                if (coyoteCounter > 0)
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                else
                {
                    if (jumpCounter > 0) //If we have extra jumps then jump and decrease the jump counter
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpCounter--;
                    }
                }
            }

            //Reset coyote counter to 0 to avoid double jumps
            coyoteCounter = 0;
        }
    }

    private void WallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
        wallJumpCooldown = 0;
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    public void Start()
    {
        //text desplay
        textdisplay.text = "<u> קווין תשע:</u> הו אני רואה שהצלחת להגיע עד כאן, אתה ממש קרוב למציאת אחיך ואני מקווה שלהצלת המלך היקר שלי." + "\n" + "על מנת שתוכל להגיע ליעדך עלייך לשים על הסטנד המוגבה את המספר הכי גבוהה שמתחלק בין שני האיברים התלויים על העץ."; ;

    }
}
