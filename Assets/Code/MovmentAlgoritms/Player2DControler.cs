using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class Player2DControler : MonoBehaviour
{

    //jumping
    public float jumpForce = 10;
    public float jumpForceEffectByMomentomRatio;
    public float speed = 4f;


    //for coliision use
    public bool isGrounded = false;
    public bool canMomentumJump = false;
    public LayerMask groundLayer;

    public GameObject InvatoryForUSe;

    //coins
    [SerializeField] public string Coin;
    public Transform coinswap;
    int gotcoins = 0;

    //shiptake
    public string ship;
    public GameObject ships;
    public GameObject ship2;
    public GameObject returnship;
    public Transform StuffParent;
    public Transform StuffParent2;
    public bool ocean = true;
    public bool inisidted = false;
    public string onland;
    public string returnland;
    public GameObject rightland;
    public bool onit = false;
    public GameObject leftlamnd;


    public Vector3 OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Cave" && Input.GetKey(KeyPanel.EnterToPlaces))
        {
            Debug.Log("cave");
            Location.SaveLocation(col.transform.position);
            SceneManager.LoadScene("Cave");
            return col.transform.position;
        }
        return col.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == Coin)
        {
            gotcoins = gotcoins + 1;
            Debug.Log("you have: " + gotcoins);
            SingleToon.getInstance().curmoney.gain(100);
            SingleToon.getInstance().curscore.raise(10);
        }

        if (collision.gameObject.tag == ship)
        {

            ships = collision.gameObject;
            float height;

            StuffParent = collision.transform.parent;
            collision.gameObject.transform.parent = this.transform;
            collision.gameObject.transform.localPosition = Vector3.zero;
            ships.transform.parent = StuffParent;
            height = this.GetComponent<SpriteRenderer>().bounds.size.y;
            ships.transform.position = new Vector3(transform.position.x, transform.position.y - (height / 4), transform.position.z);
            Debug.Log("i got a ship");
            inisidted = true;
            

        }

        if (collision.gameObject.tag == onland && inisidted == true && onit == false )
        {
            Destroy(ships);
            //Destroy(rightland);
            ///
           // Instantiate(leftlamnd);
            onit = true;
            Instantiate(returnship);
            inisidted = false;
            }

        //
        if (collision.gameObject.tag == returnland && inisidted == false && onit ==true)
        {
            Destroy(returnship);
            Destroy(rightland);
            Instantiate(leftlamnd);
            onit = true;
            Instantiate(ships);
            inisidted = true;
        }
        ////


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


        //H key down -> getting into places
        else if (Input.GetKeyDown(KeyPanel.EnterToPlaces))

        {
            Debug.Log(transform.position);
            double rightEnternceLaFarmaBaginDistance = -15.55;
            double leftEnternceLfarmaEndDistance = -13.55;
            Vector3 move = transform.position + Vector3.down;
            if (transform.position.x < leftEnternceLfarmaEndDistance && transform.position.x > rightEnternceLaFarmaBaginDistance)
            {
                Location.SaveLocation(transform.position);
                SceneManager.LoadScene("LaFarma");
                return transform.position; //ToDo Pass into ohter secne
                //Debug.Log("we are the chmpions");
            }

            double rightEnternceGuessTasteaBaginDistance = 54.45;
            double leftEnternceGuessTasteEndDistance = 58.45;
            if (transform.position.x > rightEnternceGuessTasteaBaginDistance && transform.position.x < leftEnternceGuessTasteEndDistance)
            {
                Location.SaveLocation(transform.position);
                SceneManager.LoadScene("GuessTaste");
                return transform.position;
                //return transform.position + move; //ToDo Pass into ohter secne
            }

            //cave area 
            double rightCaveLimit = 13;
            double LeftCaveLimit = 8.2;
            if (transform.position.x > LeftCaveLimit && transform.position.x < rightCaveLimit)
            {

                Debug.Log("here i am"); 
                Location.SaveLocation(transform.position);
               // Debug.Log(transform.position);
                SceneManager.LoadScene("Cave");
                
                return transform.position;
                
            }

            //Palace area 
            double rightPalace = -48.4;
            double LeftPalace = -54.3;
            if (transform.position.x > LeftPalace && transform.position.x < rightPalace)
            {

                Debug.Log("here i am");
                Location.SaveLocation(transform.position);
                // Debug.Log(transform.position);
                SceneManager.LoadScene("CloseCastle");

                return transform.position;

            }

            //right now the shop is not ready yet so it sends you temporary to la farma
            double PlusShopLimitEnternceLeft = 114.45;
            double PlusShopLimitEntrenceRight = 116.5;

            if (transform.position.x > PlusShopLimitEnternceLeft && transform.position.x < PlusShopLimitEntrenceRight)
            {
                Location.SaveLocation(transform.position);
                SceneManager.LoadScene("PlusShop");
                return transform.position;
                //return transform.position + move; //ToDo Pass into ohter secne
            }

            //the landery area 
            double rightlanderyLimita = 206.7;
            double rightlanderyLimitb = 204.7;
            double LeftlanderyLimita = 193.1;
            double LeftlanderyLimitb = 197.1;
            //Debug.Log(transform.position);
            if (transform.position.x > LeftlanderyLimita && transform.position.x < LeftlanderyLimitb || transform.position.x > rightlanderyLimitb && transform.position.x < rightlanderyLimita)
            {

                Debug.Log("here i am");
                Location.SaveLocation(transform.position);
                //Debug.Log(transform.position);
                SceneManager.LoadScene("TheLanderyBase");

                return transform.position;

            }


            //the roofkey area 
            double rightroofkey = 220;
            double Leftroofkeyb = 217;
            Debug.Log(transform.position.x);
            if (transform.position.x > Leftroofkeyb && transform.position.x < rightroofkey)
            {

                Debug.Log("here i am");
                Location.SaveLocation(transform.position);
                //Debug.Log(transform.position);
                SceneManager.LoadScene("KeyOnTheRoof");

                return transform.position;

            }

            //foresrt cave area 
            double rightForestCaveLimit = 354.1;
            double LeftForestCaveLimit = 350.4;
            if (transform.position.x > LeftForestCaveLimit && transform.position.x < rightForestCaveLimit)
            {
                Location.SaveLocation(transform.position);
                //Debug.Log(transform.position);
                SceneManager.LoadScene("GcdPlane");

                return transform.position;

            }

            else
                return transform.position;
        
       
        }

        //9.8 -3.5 00 - move to cave
        //194.1 -3.5 00 - left rnternce to landery
        //206.7 -3.5 00 - right enternce to landery
        //309.0 -3.5 00 - 315.0 -3.5 00 - entenrce to cave



        //I key down -> getting info
        else if (Input.GetKeyDown(KeyCode.I) || Input.GetKey("i"))
        {
            SceneManager.LoadScene("Instructions");
            return transform.position;
        }

        //M key down -> open invatory
        else if (Input.GetKeyDown(KeyCode.M))
        { 
            Instantiate(InvatoryForUSe);
            return transform.position;
        }

        /* //T key down -> taking things in levels
         else if (Input.GetKeyDown(KeyCode.T) || Input.GetKey("t"))
         {
             //need to put here an option to take object and clone it
             //plas return the posion of him and find what is the value inside of him.
             SceneManager.LoadScene("Instructions");
             return transform.position;
         }

         //G key down -> giving things in levels
         else if (Input.GetKeyDown(KeyCode.G) || Input.GetKey("g"))
         {
             //need to put here an option to gave object and destroy it
             SceneManager.LoadScene("Instructions");
             return transform.position;
         }*/

        //P key down -> giving things in levels
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKey("p"))
        {
            //need to put here an option to gave object and destroy it
            SceneManager.LoadScene("PausePage");
            return transform.position;
        }


        //if nofing preesed
        else
        {
            return transform.position;
        }





    }

    void FixedUpdate()
    {
        /*bool isTouchingGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.6f), 0.2f, groundLayer);
        isGrounded = isTouchingGround && rb2d.velocity.y < 0.1;
        bool isNearGroundF = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.85f), 0.4f, groundLayer);
        if (isNearGroundF && rb2d.velocity.y < -1)
            canMomentumJump = true;
        else canMomentumJump = false;


        Debug.Log("is GROUNDED: " + isGrounded);*/
    }


    // Update is called once per frame
    void Update()
    {
                transform.position = NewPosition();
    }

    
}
