using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AllDropsInOne : MonoBehaviour
{
    public TextMeshProUGUI textonbag;

    public string potion;
    public GameObject CyanPotion;
    public GameObject GoldPotion;
    public GameObject WinePotine;
    

    private int numcyan = 0;
    private int numgold = 0;
    private int numwine = 0;

    private int oldnumcyan = 0;
    private int oldnumgold = 0;
    private int oldnumwine = 0;

    private int all = 0;

    List<string> colors = new List<string>();
    List<string> right = new List<string>();

    public bool reseted = false;

    void Start()
    {
        all = 0;
        textonbag.text = all.ToString();


        right.Add("cyan");
      //  right.Add("cyan");//
        right.Add("gold");
      //  right.Add("gold");
       // right.Add("gold");//
        right.Add("gold");//
        right.Add("wine");
       // right.Add("wine");//
       // right.Add("wine");
      //  right.Add("wine");
        right.Add("wine");//
        right.Add("wine");//
       // right.Add("gold");
      //  right.Add("gold");
        right.Add("gold");//
        right.Add("gold");//
    }

    public void resetbug()
    {
        Debug.Log("im clean");
            colors.Clear();
            reseted = false;
    }
    public int marge()
    {

      
        oldnumcyan = numcyan;
        numcyan = CyanPotion.GetComponent<HowManyDropsAlredy>().dropsinbag();

        oldnumgold = numgold;
        numgold = GoldPotion.GetComponent<HowManyDropsAlredy>().dropsinbag();

        oldnumwine = numwine;
        numwine = WinePotine.GetComponent<HowManyDropsAlredy>().dropsinbag();
        all = numcyan + numgold + numwine;


        return all;
        //return all;


    }

    // Update is called once per frame
    void Update()
    {
        if (oldnumcyan!=numcyan)
        {
            colors.Add("cyan");
        }

        if (oldnumgold != numgold)
        {
            colors.Add("gold");
        }

        if (oldnumwine != numwine)
        {
            colors.Add("wine");
        }
        all = marge();
        
        textonbag.text = all.ToString();
        //textonbag.text = (all/2).ToString();
    }

    public bool checkcolors()
    {
        if (colors.SequenceEqual(right) == true)
        {
            string[] colorsOutput = colors.ToArray();
            string[] RightOutput = right.ToArray();
            /*Debug.LogWarning("right the colors output is: " );
            Debug.Log(string.Join("\n", colorsOutput));
            Debug.LogWarning("right the right output is: ");
            Debug.Log(string.Join("\n", RightOutput));*/
            if (reseted == false)
            {
                Debug.Log("right colors is: ");
                foreach (string item in colors)
                {
                    Debug.Log(item);
                }

                Debug.Log("right right is: ");
                foreach (string item in right)
                {
                    Debug.Log(item);
                }
                reseted = true;
            }
           
            return true;
        }

        else
        {
            string colorsOutput = colors.ToArray().ToString();
            string RightOutput = right.ToArray().ToString();
            //Debug.LogWarning("right the colors output is: ");
            // Debug.Log(string.Join("\n", colorsOutput));
            //  Debug.LogWarning("right the right output is: ");
            //  Debug.Log(string.Join("\n", RightOutput));
            if (reseted == false)
            {
                Debug.Log("wrong colors is: ");
                foreach (string item in colors)
                {
                    Debug.Log(item);
                }

                Debug.Log("wrong right is: ");
                foreach (string item in right)
                {
                    Debug.Log(item);
                }
                reseted = true;
            }
            return false;
        }
           

    }
}
