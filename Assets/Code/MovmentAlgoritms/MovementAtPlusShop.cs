using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementAtPlusShop : MonoBehaviour
{
    public float speed = 4f;

    //the invatory object
    public GameObject Instruction;
    private GameObject fordestroy;
    bool exist = false;

    //check if misson done
    bool done = LaFarmaBox.missiondone = false;

    //talking
    public TextMeshProUGUI textdisplay;

    public GameObject InvatoryForUSe;
    public GameObject Shop;

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

        //A key down -> giving things in levels
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey("a"))
        {
            //need to put here an option to gave object and destroy it
            Shop.SetActive(true);
            return transform.position;
        }


        else
        {
            return transform.position;
        }



    }

    private void Start()
    {
        textdisplay.text = "<u> הרוכל הנוכל:  </u>  הו שלום שלום אני רואה שפעם ראשונה שהגעת , האם אוכל לעניין אותך בכמה מהפריטים המיוחדים שיש אצלי בחנות?" + "\n" + "א. במידה וכן, יש ללחוץ על המקש A" + "\n" + "ב. במידה ולא, אז הדלת משמאל, חוצפה פשוט!" ; ;
    }

    public void CloseShop()
    {
        Shop.SetActive(false);
        textdisplay.text = "<u> הרוכל הנוכל:  </u>  הו שלום שלום אני רואה שפעם ראשונה שהגעת , האם אוכל לעניין אותך בכמה מהפריטים המיוחדים שיש אצלי בחנות?" + "\n" + "א. במידה וכן, יש ללחוץ על המקש A" + "\n" + "ב. במידה ולא, אז הדלת משמאל, חוצפה פשוט!"; ;
    }

    public void ShopNoEnoghtMoney()
    {
        textdisplay.text = "<u> הרוכל הנוכל:  </u> חוששני שאין לך מספיק מטבעות כדי לקנות את המוצר, ממליץ לך לבצע משימות ולהגיע שוב בעתיד";
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = NewPosition();
    }
}
