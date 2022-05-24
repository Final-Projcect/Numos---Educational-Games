using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movmentworkpostion : MonoBehaviour
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


        else
        {
            return transform.position;
        }



    }
}
