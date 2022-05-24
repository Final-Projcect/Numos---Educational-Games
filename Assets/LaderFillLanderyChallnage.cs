using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LaderFillLanderyChallnage : MonoBehaviour
{
    public Image LeaderBarImage;
    private float LeaderBarAmount = 3f;
    private float currentFilling;
    private float calcalateFiling;
    public MovmentAtLanderyChallange CurrentFill;
    //Component CurrentFill;

    int fill;
    // Start is called before the first frame update
    void Start()
    {
        fill = CurrentFill.Fill;
        currentFilling = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fill = CurrentFill.Fill;
        calcalateFiling = fill / LeaderBarAmount;
        Debug.Log(calcalateFiling);
        //lifebar.fillAmount = Mathf.MoveTowards(lifebar.fillAmount, calcalutelife, Time.deltaTime);
        LeaderBarImage.fillAmount = Mathf.MoveTowards(LeaderBarImage.fillAmount, calcalateFiling, Time.deltaTime);

        if (currentFilling == 1)
        {
            if (Input.GetKeyDown(KeyCode.L))
                //get lader
                currentFilling = 0;

        }
    }
}
