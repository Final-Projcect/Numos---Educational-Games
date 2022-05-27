using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RandomNumbs : MonoBehaviour
{
    //textshow by level
    public TextMeshProUGUI[] FirstKingPackage;
    public TextMeshProUGUI[] Stand1Package;
    public TextMeshProUGUI[] Stand2Package;

    //check if need random
    bool randomize;
    int level = 1 ;

    //list of all numbers
    private List<int> availableNumbersLev1 = new List<int>();
    private List<int> availableNumbersLev2 = new List<int>();
    private List<int> availableNumbersLev3 = new List<int>();
    public int Numsize = 0;

    //show progress to player
    public TextMeshProUGUI textdisplayshow;

    public AudioSource Seccess;
    private AudioSource happy;
    //prime numbers array
    private int[] Primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 47, 53, 59, 71, 83, 89, 101, 107, 113 };
    private int[] basics = {   8, 16, 24, 48, 36 };
    private int[] basicsdiv = { 2,4 };
    

    //player option hard on level
    bool hard = true;

    //change the leaf into a king leaf
    public GameObject newking;
    public GameObject leaf;
    bool newon = false;
    //public TextMeshProUGUI newone;

    //change the places after finish level2
    public GameObject waterground1;
    public GameObject ground1;

    //change the places after finish level3
    public GameObject waterground2;
    public GameObject ground2;

    private TextMeshProUGUI textfind;

    public bool getit = false;
    public bool getit2 = false;
    public bool getit3 = false;


    void Start()
    {
        happy = GetComponent<AudioSource>();

        //textdisplayshow.text = "<u> אפס:</u> אוי לא, נראה שנתקענו במערה!!" + "\n" + "מעניין האם מישהו יוכל לעזור לי לצאת מכאן, כנראה כדאי שבנתיים המשיך ללכת";
        //Vector3 smallpos;

        //level 1 - prime numbers so the biggest divisior is 1
        if (level == 1)
        {
            if (availableNumbersLev1.Count == 0)
            {
                for (int i = 0; i < Numsize-2; i++)
                {
                    randomizer(i,1);
                }
            }
            availableNumbersLev1.Add(1);
            int numindex = availableNumbersLev1.IndexOf(1);
            FirstKingPackage[3].text = availableNumbersLev1[numindex].ToString();
            randomizer(4,1);

            if (getit = true)
            {
                //newone.text =1.ToString();
                Destroy(leaf);
                if (newon == false)
                {
                    //Instantiate(newking);
                    Debug.Log("oy");
                }


                level++;
            }
            

        }

        //level 2 - same divisior as a king - its means that the second number is divides by the first
        if (level == 2)
        {
            int numbers = 0;
            int firstnum = UnityEngine.Random.Range(0, basics.Length);  
            availableNumbersLev2.Add(basics[firstnum]);
            numbers = availableNumbersLev2.IndexOf(basics[firstnum]);
            Stand1Package[0].text = availableNumbersLev2[numbers].ToString();


            int secondnum = UnityEngine.Random.Range(0, basics.Length);
            while (secondnum == firstnum)
            {
                secondnum = UnityEngine.Random.Range(0, basics.Length);
            }
            availableNumbersLev2.Add(basics[secondnum]);
            numbers = availableNumbersLev2.IndexOf(basics[secondnum]);
            Stand1Package[1].text = availableNumbersLev2[numbers].ToString();

            int thirdnum = 0;
            /* int thirdnum = UnityEngine.Random.Range(0, basicsdiv.Length);*/
            if (basics[secondnum] < basics[firstnum])
            {
                thirdnum = secondnum;
            }
            else
                 thirdnum = firstnum;
            //availableNumbersLev2.Add(basicsdiv[thirdnum]);
            availableNumbersLev2.Add(basics[thirdnum]);
            Debug.Log("third num is:" + basics[thirdnum]);
            Debug.Log("firstnum is: " + basics[firstnum]);
            Debug.Log("second num is:" + basics[secondnum]); 
            //numbers = availableNumbersLev2.IndexOf(basicsdiv[thirdnum]);
            numbers = availableNumbersLev2.IndexOf(basics[thirdnum]);
            Stand1Package[2].text = availableNumbersLev2[numbers].ToString();

            for (int i = 3; i < Numsize-1; i++)
            {
                randomizer(i,2);
            }

            level++;

        }

        //level 3 - divisor of gcd
        if (level == 3)
        {
            int firstgcd = UnityEngine.Random.Range(2, 50);
            int secondgcd = UnityEngine.Random.Range(2, 50);
            while (firstgcd == secondgcd)
            {
                secondgcd = UnityEngine.Random.Range(2, 50);
            }

            int gcnum = GCD(firstgcd, secondgcd);
            while (gcnum == 1)
            {
                secondgcd = UnityEngine.Random.Range(2, 50);
                gcnum = GCD(firstgcd, secondgcd);
            }

            availableNumbersLev3.Add(firstgcd);
            int numindexs = availableNumbersLev3.IndexOf(firstgcd);
            Stand2Package[0].text = availableNumbersLev3[numindexs].ToString();

            availableNumbersLev3.Add(secondgcd);
            numindexs = availableNumbersLev3.IndexOf(secondgcd);
            Stand2Package[1].text = availableNumbersLev3[numindexs].ToString();

            availableNumbersLev3.Add(gcnum);
            numindexs = availableNumbersLev3.IndexOf(gcnum);
            Stand2Package[2].text = availableNumbersLev3[numindexs].ToString();

            randomizer(3, 3);
            randomizer(4, 3);

        }


        }

    public void randomizer(int index, int level)
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        int max = 50;
        int max2 = 50;
        int max3 = 50;
        int minlevel1 = 2;
        int minlevel2 = 2;
        int minlevel3 = 2;


        num = UnityEngine.Random.Range(minlevel1, Primes.Length);
        num2 = UnityEngine.Random.Range(minlevel2, max2);
        num3 = UnityEngine.Random.Range(minlevel3, max3);
        if (level == 1)
        {
            if (availableNumbersLev1.Contains(Primes[num]))
            {
                randomizer(index, 1);
            }

            
            else
            {
                if (availableNumbersLev1.Contains(Primes[num])==false)
                {
                    availableNumbersLev2.Add(Primes[num]);
                    FirstKingPackage[index].text = Primes[num].ToString();
                }

                else
                    randomizer(index, 1);

            }
            
        }

        if (level == 2)
        {
            if (availableNumbersLev2.Contains(num2))
            {
                randomizer(index, 2);
            }
            else
            {
                availableNumbersLev2.Add(num2);
                Stand1Package[index].text = num2.ToString();
            }
        }

        if (level == 3)
        {
            if (availableNumbersLev3.Contains(num3))
            {
                randomizer(index, 3);
            }
            else
            {
                availableNumbersLev3.Add(num3);
                Stand2Package[index].text = num3.ToString();
            }
        }

    }

    public int GCD(int[] numbers)
    {
        return numbers.Aggregate(GCD);
    }

    public int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }

    public int NumAtSign(GameObject head)
    {
        int NumberOfSign;
        textfind = this.GetComponentInChildren<TextMeshProUGUI>();
        NumberOfSign = Convert.ToInt32(textfind.text);
        Debug.Log("i am a: " + NumberOfSign);
        return NumberOfSign;


    }



}
