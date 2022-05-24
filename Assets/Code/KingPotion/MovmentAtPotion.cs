﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovmentAtPotion : MonoBehaviour
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
    public string coin;
    public string gold;
    int getgold = 0;
    int getcoin = 0;

    //potion
    public string potion;
    public string allpotion;
    public string king;

    //talkingwithbrow
    public GameObject say1;
    public GameObject say2;
    public GameObject instructions;
    public GameObject clue1;
    public GameObject clue2;
    public GameObject youonyouron;
    public GameObject cleanthemachine;

    //public GameObject welldone;
    bool done = false;
    bool alradyin = false;

    //toolsforscleanmachine
    public GameObject CyanPotion;
    public GameObject GoldPotion;
    public GameObject WinePotine;


    // The initial position of the GameObject
    Vector3 initialPosition;

    //block the next place
    //public GameObject block;

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

        //clean the machine
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CyanPotion.GetComponent<HowManyDropsAlredy>().reset();
            GoldPotion.GetComponent<HowManyDropsAlredy>().reset();
            WinePotine.GetComponent<HowManyDropsAlredy>().reset();
            return transform.position;
        }


        else
        {
            return transform.position;
        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {

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

        if (collision.gameObject.tag == potion)
        {
            if (Input.GetKeyDown(KeyPanel.Take))
            {
                collision.gameObject.GetComponent<HowManyDropsAlredy>().incresedrop();
            }
        }


        if (collision.gameObject.tag == king)
        {
            textdisplay.text = "<u> אפס:  </u> אחי! מצאתי אותך! מה עשית עד עכשיו?" + "\n" + "על מנת לשמוע את מה שיש לאחי להגיד הקישו על V";
            if (Input.GetKeyDown(KeyCode.V))
            {
                Instantiate(say1);
                textdisplay.text = "<u> אפס:  </u> בוא נברח מכאן! תגיד לי איך לשחרר אותך ונחזור חזרה לארץ שלנו" + "\n" + "על מנת לשמוע את מה שיש לאחי להגיד הקישו על K";
                alradyin = true;
                ///////////////
                if (Input.GetKeyDown(KeyCode.K))
                {
                    alradyin = false;
                    Destroy(say1);
                    Instantiate(say2);
                    alradyin = true;
                    textdisplay.text = "<u> אפס:  </u> על מנת לשאול את האח שאלות בחרו באחת האפשרויות הבאות:" + "\n" + "א. איך אני עושה את זה? - לחצו על V" + "\n" + "ב. אולי נוותר על זה, אשחרר אותך ואלך - לחצו על B." + "\n" + "ג. תן לי הנחיות איך לשחרר אותך ותכין את השיקוי אתה - לחצו על C";
                    /////////////////////
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(say2);
                        alradyin = false;
                        Instantiate(instructions);
                        alradyin = true;
                        textdisplay.text = "<u> אפס:  </u> על מנת לשאול את האח שאלות בחרו באחת האפשרויות הבאות:" + "\n" + "א. אולי נוותר על זה, אשחרר אותך ואלך - לחצו על A." + "\n" + "ב. תן לי הנחיות איך לשחרר אותך ותכין את השיקוי אתה - לחצו על B" + "\n" + "ג. אפשר בבקשה רמז נוסף? - לחצו על C";
                        /////////////////////////////
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            Destroy(instructions);
                            alradyin = false;
                            Instantiate(youonyouron);
                            alradyin = true;
                            textdisplay.text = "<u> אפס:  </u> על מנת לשאול את האח שאלות בחרו באחת האפשרויות הבאות:" + "\n" + "א. במידה ואני טועה איך אני יכול לאפס את המכונה? - לחצו על B" + "\n" + "ב. אפשר בבקשה רמז נוסף? - לחצו על C";

                            ///////////////////////////////////
                             if (Input.GetKeyDown(KeyCode.B))
                            {
                                Destroy(youonyouron);
                                alradyin = false;
                                Instantiate(cleanthemachine);
                                alradyin = true;
                                textdisplay.text = "<u> אפס:  </u> על מנת לשאול את האח שאלות בחרו באחת האפשרויות הבאות:" + "\n" + "א. אפשר רמז נוסף? - לחצו על A";
                                //////////////////////////////////////
                                if (Input.GetKeyDown(KeyCode.A))
                                {
                                    Destroy(cleanthemachine);
                                    alradyin = false;
                                    Instantiate(clue1);
                                    alradyin = true;
                                    textdisplay.text = "<u> אפס:  </u> על מנת להשיג רמז נוסף לחצו על C";
                                    ////////////////////////////////////////
                                    if (Input.GetKeyDown(KeyCode.C))
                                    {
                                        Destroy(clue1);
                                        alradyin = false;
                                        Instantiate(clue2);
                                        alradyin = true;
                                        textdisplay.text = "<u> אפס:  </u> תודה אחי, אני לא אאכזב אותך";
                                    }
                                }
                                //////////////////////////////////////
                            }
                            ///////////////////////////////////

                            ///////////////////////////////////
                            else if (Input.GetKeyDown(KeyCode.C))
                            {
                                Destroy(clue1);
                                alradyin = false;
                                Instantiate(clue2);
                                alradyin = true;
                                textdisplay.text = "<u> אפס:  </u> תודה אחי, אני לא אאכזב אותך";
                            }
                            ///////////////////////////////////
                        }
                        /////////////////////////////

                        /////////////////////////////
                        else if (Input.GetKeyDown(KeyCode.B))
                        {
                            Destroy(instructions);
                            alradyin = false;
                            Instantiate(cleanthemachine);
                            alradyin = true;
                            textdisplay.text = "<u> אפס:  </u> על מנת לשאול את האח שאלות בחרו באחת האפשרויות הבאות:" + "\n" + "א. אפשר רמז נוסף? - לחצו על A";
                            ///////////////////////////////////
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                Destroy(cleanthemachine);
                                alradyin = false;
                                Instantiate(clue1);
                                alradyin = true;
                                textdisplay.text = "<u> אפס:  </u> על מנת להשיג רמז נוסף לחצו על C";
                                ///////////////////////////////////
                                if (Input.GetKeyDown(KeyCode.C))
                                {
                                    Destroy(clue1);
                                    alradyin = false;
                                    Instantiate(clue2);
                                    alradyin = true;
                                    textdisplay.text = "<u> אפס:  </u> תודה אחי, אני לא אאכזב אותך";
                                }
                                ///////////////////////////////////
                            }
                            ///////////////////////////////////

                            ///////////////////////////////////
                            else if (Input.GetKeyDown(KeyCode.B))
                            {
                                Destroy(say2);
                                alradyin = false;
                                Instantiate(youonyouron);
                                alradyin = true;
                                textdisplay.text = "<u> אפס:  </u> על מנת לשאול את האח שאלות בחרו באחת האפשרויות הבאות:" + "\n" + "א. איך אני עושה את זה? - לחצו על A";
                                ///////////////////////////////////
                                if (Input.GetKeyDown(KeyCode.A))
                                {
                                    Destroy(youonyouron);
                                    alradyin = false;
                                    Instantiate(instructions);
                                    alradyin = true;
                                    textdisplay.text = "<u> אפס:  </u> תוכלו לשאול את האח את השאלות הבאות:" + "\n" + "א. אפשר בבקשה רמז נוסף? - לחצו על B" + "\n" + "ב. איך אני מאפס את המכונה במידה והתבלבלתי? - לחצו על C. ";

                                    ///////////////////////////////////
                                    if (Input.GetKeyDown(KeyCode.B))
                                    {
                                        ///////////////////////////////////
                                        Destroy(instructions);
                                        alradyin = false;
                                        Instantiate(cleanthemachine);
                                        alradyin = true;
                                        textdisplay.text = "<u> אפס:  </u> תודה אחי, אני לא אאכזב אותך";
                                        //////////////////////////////////
                                    }
                                    /////////////////////////////////
                                    else if (Input.GetKeyDown(KeyCode.C))
                                    {
                                        Destroy(cleanthemachine);
                                        alradyin = false;
                                        Instantiate(clue1);
                                        alradyin = true;
                                        textdisplay.text = "<u> אפס:  </u> על מנת להשיג רמז נוסף לחצו על A";
                                        ///////////////////////////////////
                                        if (Input.GetKeyDown(KeyCode.A))
                                        {
                                            Destroy(clue1);
                                            alradyin = false;
                                            Instantiate(clue2);
                                            alradyin = true;
                                            textdisplay.text = "<u> אפס:  </u> תודה אחי, אני לא אאכזב אותך";
                                        }
                                        /////////////////////////////////
                                    }
                                    /////////////////////////////////
                                }
                                ///////////////////////////////////
                            }
                        }

                        ///////////////////////////////////
                        else if (Input.GetKeyDown(KeyCode.C))
                        {
                            Destroy(say2);
                            alradyin = false;
                            Instantiate(clue1);
                            alradyin = true;
                            textdisplay.text = "<u> אפס:  </u> על מנת להשיג רמז נוסף לחצו על A";
                            ///////////////////////////////////
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                Destroy(clue1);
                                alradyin = false;
                                Instantiate(clue2);
                                alradyin = true;
                                textdisplay.text = "<u> אפס:  </u> תודה אחי, אני לא אאכזב אותך";
                            }
                        }
                        ///////////////////////////////////
                    }
                }
            }
        }
                
            


            if (collision.gameObject.tag == allpotion)
            {
                int howmac = collision.gameObject.GetComponent<AllDropsInOne>().marge();
                if (howmac == 8)
                {
                    bool finish = collision.gameObject.GetComponent<AllDropsInOne>().checkcolors();
                    if (finish == true)
                    {
                        Debug.Log("great job");
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
        textdisplay.text = "מעניין האם אחי נמצא כאן, אם כן אשמח לתקשר איתו באמצעות לחיצה על המקש - L";
    }
}
