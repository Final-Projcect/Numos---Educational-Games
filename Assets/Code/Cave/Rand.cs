using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rand : MonoBehaviour
{
    public TextMeshProUGUI[] textdisplay;


    //check if need random
    bool randomize;

    //list of all numbers
    public List<int> availableNumbers = new List<int>();
    public int size = 0;

    public GameObject[] StonePackage;

    //show progress to player
    public TextMeshProUGUI textdisplayshow;

    public AudioSource Seccess;
    public AudioSource happy;

    //player option hard on level
    bool hard = true;

    void Start()
    {
        happy = GetComponent<AudioSource>();

        textdisplayshow.text = "אוי לא, נראה שנתקענו במערה!!" + "\n" + " אך אל חשש ואל דאגה, כל שעליך לעשות זה פשוט לגרור את האבנים החוסמות למיקום המתאים על פי הסימן שלהם";
        //Vector3 smallpos;
        if (availableNumbers.Count == 0)
        {
            for (int i = 0; i < size; i++)
            {
                randomizer(i);
            }
        }
        else
        {
            for (int i = 0; i < availableNumbers.Count; i++)
            {
                randomizer(i);
            }
        }


    }

    public void randomizer(int index)
    {
        int num = 0;
        int max = 30;
        int min = -30;

        num = UnityEngine.Random.Range(min, max);
        if (availableNumbers.Contains(num))
        {
            randomizer(index);
        }
        else
        {
            availableNumbers.Add(num);
            textdisplay[index].text = num.ToString();
        }
    }
}
