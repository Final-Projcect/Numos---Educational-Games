using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeQuestLevel : MonoBehaviour
{
    //for use text in screen
    public TextMeshProUGUI textdisplay;
    //textdisplay[index].text = num.ToString();

    //Brench Objects
    public GameObject[] BrenchPackage;

    //BrenchPosition
    public List<Vector3> BricksOriginPosition = new List<Vector3>();

    //check if Brench refl
    public GameObject CheckRef;

    //currectlevel
    public int level = 0;
    public int basis = 0;
    public bool done = false; //check if the mission acomplish
    public int count;
    public int count2;

    //showmassage ,explain things to the player while he plays
    public TextMeshProUGUI textdisplayshow;

    private AudioSource happy;


    // Start is called before the first frame update
    void Start()
    {
        happy = GetComponent<AudioSource>();
        textdisplayshow.text = "שלום, עליכם לאסוף ענפים זהים, ככל שיש לכם כמות זוגית גבוהה יותר של ענפים זהים ככה הגודל של הסולם שלכם יהיה גבוהה, יייתכן שהענפים השונים יהיו מפוזרים באזורים שונים,אל תחששו לעלות ולרדת לאורך העץ.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
