using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAStone : MonoBehaviour
{
    public string stone;
    //public string LaFarmaTag;
    public GameObject AStone;
    public Transform StuffParent;
    public bool IsAdoptedStuff = false;
    // bool TouchLittleFarma = false;

    //numeronstonereturn
    public string ret1;
    public string ret2;
    public string ret3;

    public string ret4;
    public string ret5;
    public string ret6;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == stone)
        {
            //T key down -> take staff
            if (Input.GetKeyDown(KeyPanel.Take))
            {
                if (IsAdoptedStuff == false)
                {
                    AStone = collision.gameObject;
                    StuffParent = collision.transform.parent;
                    collision.gameObject.transform.parent = this.transform;
                    collision.gameObject.transform.localPosition = Vector3.zero;
                    IsAdoptedStuff = true;
                    Debug.Log("here with la farma 28");

                }

            }


        }

        //G key down -> take staff
        if (Input.GetKeyDown(KeyPanel.Put))
        {
            if (IsAdoptedStuff == true)
            {
                float height;
                IsAdoptedStuff = false;
                AStone.transform.parent = StuffParent;
                height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                AStone.transform.position = new Vector3(transform.position.x, transform.position.y - height / 4, transform.position.z);
                Debug.Log("mon bian 89: " + AStone.transform.position);

            }

            if (collision.gameObject.tag == ret1)
            {

            }

        }
    }
}
