using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
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

    //tags for use in the game
    public string firstTalkWithSix;
    public string rabbitcatch;
    public string foodjar;

    //booleans cheack
    bool alredyrabbitinhand = false;
    bool alredytalk = false;
    bool inthejar = false;
    bool hitjar = false;
    bool nextfive = false;

    //rabit take
    [SerializeField] public GameObject[] rabbit;
    public GameObject rabb;
    public GameObject rabb2;
    public GameObject rabb3;
    public GameObject rabb4;
    public GameObject rabb5;
    int rab = 0;
    public Transform rabbitParent;
    int jarrabbit = 0;

    //shake screen
    // Transform of the GameObject you want to shake
    private Transform transforms;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    //snow and lava modifay fast
    public string snow;
    public string lava;
    public string key;
    public string star;

    //six appers in diffrent location
    public string six; //the second time when six apper, after the first task done
    public GameObject sixchar;
    public GameObject firstsix;
    private GameObject instisinatesixchar;
    bool alradyon = false;

    //block the next place
    public GameObject block;
    public string gold;
    public int getgold = 0;



    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == firstTalkWithSix )
        {

            //talk with six - first instruction  && alredytalk == false
            if (Input.GetKeyDown(KeyCode.L))
            {
                firstsix = collision.gameObject;
                //text desplay
                textdisplay.text = "<u> המשרת האוויל:</u> שלום לך, אתה בטח רוצה לדעת האם יש דרך נוספת לצאת מהמערה, טוב..בוא נתחיל מזה שבתור התחלה " + "\n" + "אשמח אם תוכל בבקשה לשים 2 חרפוג'י מערות לתוך הקערה" + "\n" + "על מנת לתפוס חרפוג'י יש לעמוד מעל אחד וללחוץ על המקש T , ועל מנת להניח אותו בתוך הקערה יש לגשת אל הקערה (עם החרפוג'י שתפסנו) וללחוץ על G";
            }
            alredytalk = true;


        }

        if (collision.gameObject.tag == gold)
        {
            getgold = getgold + 1;
            Debug.Log("you have: " + getgold);
            SingleToon.getInstance().curmoney.gain(1200);
            //SingleToon.getInstance().curscore.raise(50);
        }

        if (collision.gameObject.tag == rabbitcatch)
        {
            //T key down -> take staff
            if (Input.GetKeyDown(KeyPanel.Take))
            {
                // if (alredyrabbitinhand == false)
                //{
                rabbit[0] = collision.gameObject;
                //BrickParent = collision.transform.parent;
                //collision.gameObject.transform.parent = this.transform;
                // collision.gameObject.transform.localPosition = Vector3.zero;
                // alredyrabbitinhand = true;


                rabbit[0] = collision.gameObject;
                rabbitParent = collision.transform.parent;
                collision.gameObject.transform.parent = this.transform;
                collision.gameObject.transform.localPosition = Vector3.zero;
                alredyrabbitinhand = true;
                Debug.Log("yay we got rabbit");
                textdisplay.text = "כל הכבוד תפסת חרפוג'י! כעת עלייך להניח אותו בקערה על ידי עמידה לידה ולחיצה על המקש G";
                


                //}

            }


        }

        //if (collision.gameObject.tag == )

        if (collision.gameObject.tag == snow)
        {
            speed = 15f;
        }

        if (collision.gameObject.tag == lava)
        {
            SingleToon.getInstance().curlife.damage(1);
        }

        if (collision.gameObject.tag == key)
        {
            speed = 10f;
        }

        if (collision.gameObject.tag == star)
        {
            SingleToon.getInstance().curlife.damage(100);
        }


        if (collision.gameObject.tag == foodjar)
            {
                hitjar = true;
                Debug.Log("hitjar ");
                if (alredyrabbitinhand == true)
                {
                    Debug.Log("line 157 is currect? ");
                    if (Input.GetKeyDown(KeyPanel.Put))
                    {
                        Debug.Log("line 176 is currect? ");
                        float height;
                        alredyrabbitinhand = false;
                    //rabbit[0].transform.parent = rabbitParent;
                    // height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                    // rabbit[0].transform.position = new Vector3(transform.position.x, transform.position.y - (height / 4), transform.position.z);

                    if (rab == 0)
                    {
                        Instantiate(rabb);
                        rab++;
                        textdisplay.text = "איזה יופי, הנחתם חרפוג'י אחד בקערה!! עליכם למצוא עוד חרפוג'ים!";
                    }

                    else if (rab == 1)
                    {
                        Instantiate(rabb2);
                        rab++;
                        //textdisplay.text = "איזה יופי, הנחתם שני חרפוג'ים בקערה!! עליכם למצוא עוד חרפוג'ים!";
                    }

                    else if (rab == 2)
                    {
                        Instantiate(rabb3);
                        rab++;
                        textdisplay.text = "איזה יופי, הנחתם שלושה בקערה!! כמה לדעתכם עוד חרפוג'ים צריך על מנת שיהיה ארבעה חרפוג'ים ב?";
                    }

                    else if (rab == 3)
                    {
                        Instantiate(rabb4);
                        rab++;
                    }

                    else if (rab == 4)
                    {
                        Instantiate(rabb5);
                        rab++;
                    }



                    //change it to destroy   //rabbit.transform.position = new Vector3(transform.position.x, transform.position.y - height / 2, transform.position.z);
                    if (jarrabbit < 2 && inthejar == false)
                        {
                        jarrabbit = jarrabbit + 1;
                        hitjar = false;
                        }

                        if (jarrabbit == 2)
                        {
                        Debug.Log("we made it " + jarrabbit);
                        textdisplay.text = "<u> המשרת האוויל:</u> מעולה, עכשיו תוכלו להוסיף עוד כמה חרפוג'יי מערות על מנת שיהיו לנו ארבעה חרפוג'ים בקערה, ככה נמנמי הכוח יזיזו עבורנו את האבן החוסמת?? ?? ";
                        nextfive = true;
                        inthejar = true;
                        }

                        if (nextfive == true)
                        {
                           if (jarrabbit<5)
                            {
                            jarrabbit++;
                             }
                           
                           if (jarrabbit == 5)
                          {
                            textdisplay.text = "<u> המשרת האוויל:</u> כל הכבוד! יש לנו חמש חרפוג'ים בתוך הקערה, על מנת לצאת מהמערה עליכם לדרוך על הלבנים המעופפות ולהעביר אבנים למקומם על ציר המספרים החיוביים שליליים." + "\n" + "הלבנים החוסמות את היציאה מהמערה נמצאות בצידה השני, המשיכו עם מסלול הלבה והקרח עד שתגיעו אליהם" + "\n" + "על מנת לתפוס לבנה יש ללחוץ על המקש T במקביל ועל מנת להניח אותם יש ללחוץ על החץ המצביע מעלה ועל המקש G, השתדלו להניח את הלבנים במקום הנכון על ציר הלבה קרח המספרי שלנו";
                            Destroy(firstsix);
                            Destroy(block);
                            Instantiate(sixchar);
                            alradyon = true;
                        }
                        }
                    
                    }
                }
            
        }
    }

    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }

    void Awakes()
    {
        if (transforms == null)
        {
            transforms = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void shake ()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
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
        textdisplay.text = "<u> אפס:</u> אוי! לאן הגעתי איפה אני? ??" + "\n" + "נראה שהכניסה שלי למערה קרסה, עלי למצוא דרך לצאת מכאן." + "\n" + "במידה ואתם רואים מישהו שיכול לעזור לנו עימדו לידו ולחצו על הכפתור L";

    }
}