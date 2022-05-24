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

    void Start()
    {
        all = 0;
        textonbag.text = all.ToString();


        right.Add("cyan");
        right.Add("gold");
        right.Add("gold");
        right.Add("wine");
        right.Add("wine");
        right.Add("wine");
        right.Add("gold");
        right.Add("gold");
    }

    public int marge()
    {
        oldnumcyan = numcyan;
        numcyan = CyanPotion.GetComponent<HowManyDropsAlredy>().dropsinbag();

        oldnumgold = numgold;
        numgold = GoldPotion.GetComponent<HowManyDropsAlredy>().dropsinbag();

        oldnumwine = oldnumwine;
        numwine = WinePotine.GetComponent<HowManyDropsAlredy>().dropsinbag();
        all = numcyan + numgold + numwine;

        return all;

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

        if (oldnumwine != oldnumwine)
        {
            colors.Add("wine");
        }
        all = marge();
        
        textonbag.text = all.ToString();
    }

    public bool checkcolors()
    {
        if (colors.SequenceEqual(right) == true)
        {
            return true;
        }

        else
            return false;

    }
}
