using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /* public GameObject player;
     public int followDistance;
     private List<Vector3> storedPositions;
     public string num;
     public string splayer;
     public GameObject signObject;

     void Awake()
     {
         storedPositions = new List<Vector3>();
     }*/



    /* private void OnTriggerStay2D(Collider2D collision)
     {
         int sign = collision.gameObject.GetComponent<NumberOnSign>().NumAtSign();
         int asnum = Convert.ToInt32(num);
         if (asnum == sign)
         {
                 Destroy(gameObject);
         }
         }


     }

     private void OnTriggerStay2D(Collider2D collision)
     {
         if (collision.gameObject.tag == splayer)
         {
             storedPositions = new List<Vector3>();
         }
     }

     void Update()
     {
         if (storedPositions.Count == 0)
         {
             storedPositions.Add(player.transform.position);
             return;
         }
         else if (storedPositions[storedPositions.Count - 1] != player.transform.position)
         {
             storedPositions.Add(player.transform.position);
         }

         if (storedPositions.Count > followDistance)
         {
             transform.position = storedPositions[0];
             storedPositions.RemoveAt(0);

         }
     }*/

    public GameObject player;
    public int followDistance;
    private List<Vector3> storedPositions;



    void Awake()
    {
        storedPositions = new List<Vector3>();
 
    }

    void Start()
    {

    }

    void Update()
    {
        if (storedPositions.Count == 0)
        {
            storedPositions.Add(player.transform.position);
 
            return;
        }
        else if (storedPositions[storedPositions.Count - 1] != player.transform.position)
        {
            storedPositions.Add(player.transform.position);

        }

        if (storedPositions.Count > followDistance)
        {
            transform.position = storedPositions[0];
            storedPositions.RemoveAt(0);
    }


}}

