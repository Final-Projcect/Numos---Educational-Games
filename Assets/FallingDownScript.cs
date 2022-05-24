using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDownScript : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            anim.SetBool("FallDown", true);
        }
    }
}
