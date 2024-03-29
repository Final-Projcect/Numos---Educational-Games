﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoloower : MonoBehaviour
{
    [Tooltip("The speed by which the object moves towards the target, in meters (=grid units) per second")]
    [SerializeField] float speed = 3f;

    [Tooltip("The target position in world coordinates")]
    public Transform target;

    [SerializeField] Vector2 TopLeft, BottomRight;

    //
    public GameObject player;
    public int followDistance;
    private List<Vector3> storedPositions;
    public string splayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == splayer)
        {
            storedPositions = new List<Vector3>();
            if ((transform.position.x > TopLeft.x && transform.position.x < BottomRight.x) && (transform.position.y < TopLeft.y && transform.position.y > BottomRight.y))
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }

}
