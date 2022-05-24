using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentAtCave : MonoBehaviour
{
    //jumping
    public float jumpForce = 10;
    public float jumpForceEffectByMomentomRatio;
    public float speed = 4f;
    public Rigidbody2D rb;
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }

    //for coliision use
    public bool isGrounded = false;
    public bool canMomentumJump = false;
    public LayerMask groundLayer;

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

        void Update()
        {
            transform.position = NewPosition();
        }

    }
}
