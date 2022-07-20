using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHAndler : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;
    public MovmentATLanderyShocks messager;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.direction * this.speed *Time.deltaTime;
    }

   
}
