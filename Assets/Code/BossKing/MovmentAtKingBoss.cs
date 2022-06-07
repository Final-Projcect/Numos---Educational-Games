using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovmentAtKingBoss : MonoBehaviour
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
    bool done = LaFarmaBox.missiondone = false;

    public GameObject InvatoryForUSe;

    //text display
    public TextMeshProUGUI textdisplay;

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



    // Update is called once per frame
    void Update()
    {
        transform.position = NewPosition();
    }

    public void Start()
    {
        //text desplay
        textdisplay.text = "<u>אחד:</u>אוי לא! איך הגעת לכאן? טוב, זה לא באמת משנה, אין לך סיכוי לעצור אותי ולעמוד מול מפלצת האריתמטיק שלי!!! מוחעחעחעחע ";
    }
}
