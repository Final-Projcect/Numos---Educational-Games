using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDireaction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // used for timers,detection of inputs
    void Update()
    {
        //if player push on "up arrow" it will defined as 1,
        //if player push on "down arrow" it will defined as -1;
        float directionY = Input.GetAxisRaw("Vertical");
        ///float directionX = Input.GetAxis("Horizontal");
        playerDireaction = new Vector2(0, directionY).normalized;
        ///playerDireaction = new Vector2(0, directionX).normalized;
    }

    //used for rigibody
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDireaction.y * playerSpeed);
        ///rb.velocity = new Vector2(0, playerDireaction.x * playerSpeed);

    }
}
