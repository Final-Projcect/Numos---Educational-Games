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
    public GameObject KingHead2;
    public GameObject KingHead3;
    public GameObject KingHead4;
    public GameObject KingHead5;
    private GameObject takenkinghead;
    private Transform KingHeadParent;
    public string king;
    private bool haveking = false;
    private bool onplace = false;

    //StandJump Lev2
    public GameObject stand1;
    public GameObject stand2;
    public GameObject stand3;
    public GameObject KingHead6;
    public GameObject KingHead7;
    public string jumpstand;
    public string stand;
    public string water;

    //StandJump Lev3
    public GameObject stand4;
    public GameObject stand5;
    public GameObject stand6;
    public GameObject KingHead8;
    public GameObject KingHead9;
    public string blocks;
    public GameObject welldone;

    // The initial position of the GameObject
    Vector3 initialPosition;

    //block the next place
    public GameObject block;

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

        if (collision.gameObject.tag == king)
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

        if (haveking == true)
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
                    int num = collision.gameObject.GetComponent<RandomNumbs>().NumAtSign(takenkinghead);
                    Debug.Log("pi 207 " + num);
                    if (num == 1)
                    {
                        Debug.Log("do 210");
                        collision.gameObject.GetComponent<RandomNumbs>().getit = true;
                    }
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
        textdisplay.text = "אוי! לאן הגעתי איפה אני? ??" + "\n" + "נראה שהכניסה שלי למערה קרסה, עלי למצוא דרך לצאת מכאן." + "\n" + "במידה ואתם רואים מישהו שיכול לעזור לנו עימדו לידו ולחצו על הכפתור L";

    }
}
