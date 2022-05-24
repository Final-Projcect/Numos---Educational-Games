using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SolutionValidator : MonoBehaviour
{
    [SerializeField] RandomFormula formula;
    [SerializeField] TMP_InputField uiInputField;
    [SerializeField] ModuloSolver solver;
    [SerializeField] AudioSource Fail;
    [SerializeField] AudioSource Seccess;


    public GameObject PlaySoundConsiderTheAnswer;
    
    
    GameObject close;



    //talking
    //public TextMeshProUGUI textdisplay;


    public void ValidateAnswer()
    {
        // Checks if the solution is true.
        // 1. Retrieve the text the user inputted into the the uiInputfield.
        // 2. Validate input (non empty, not too lengthy).
        // 3. Compute formula's solution with <TODO>
        // 4. Assert that user input equals the formula's solution.
        

        string userInput = uiInputField.text;

        if (IsValidInput(userInput, 5))
        {
            int solution = solver.Solve(formula);

            if (solution == Convert.ToInt32(userInput))
                OnCorrectAnswer();
            else OnWrongAnswer();
        }
    }

    private bool IsValidInput(string input, int maxLength)
    {
        // 1. does not exceed length or empty
        // 2. is contain only numberals

        bool isEmpty = input.Length == 0;
        bool isLengthy = input.Length > maxLength;
        bool isOnlyNumerals = IsOnlyNumerals(input);

        return (!isEmpty && !isLengthy && isOnlyNumerals);
    }   

    private bool IsOnlyNumerals(string input)
    {
        // The input must contain only numberals
        Regex onlyNumeralsRegex = new Regex(@"\d*",
             RegexOptions.Compiled | RegexOptions.IgnoreCase);

        bool isOnlyNumberals = onlyNumeralsRegex.IsMatch(input);

        return isOnlyNumberals;
    }

    private void OnCorrectAnswer()
    {
        //AudioSource[] audios = GetComponents<AudioSource>();
        //audios[0].Play();
        //happy = GetComponent<AudioSource>();
        //happy.Play();
        //GetComponent<RandomFormula>().currect.Play();
        Debug.Log("CORRECT ANSWER!");
        GameObject soundobject = Instantiate(PlaySoundConsiderTheAnswer);
        soundobject.GetComponent<playmod>().PlaySound(true);
        //GetComponent<PlaySoundConsiderTheAnswer>().PlaySound(true);
        //Seccess.Play();
        SingleToon.getInstance().curmoney.gain(100);
        SingleToon.getInstance().curscore.raise(300);
        SingleToon.getInstance().curmummycaght.get(1);
        //Seccess.Stop();


        //textdisplay.text = "כל הכבוד! הצלחת לפתור את חידת המומיה, והפלא ופלא תראה מה נמצא לידה!" + "\n" + "שק של מאה מטבעות שהצטרפו הישר לבר המטבעות שלך שנמצא משמאל למסך ליד הסימון מטבע" + "\n" + "300 נקודות שנמצאות מתחת לבר המטבעות, לצד סימון הכוכב" + "\n" + "מומיה אחת לאוסף המומיות שלך - ניתן לראות את כמות המומיות שיש לך מתחת לתמונת הפרופיל שלך משמאל למסך למעלה. תמיד תוכל להביא תמומיות לצינוק ולקבל עוד נקודות.";

        GetComponent<CloseQuest>().Close(true);


        // 1. Player gains money.
        // 2. Player gains score points.
        // 3. Close quest.
    }

    private void OnWrongAnswer()
    {
        //AudioSource[] audios = GetComponents<AudioSource>();
        //audios[1].Play();
        Debug.Log("WRONG ANSWER!");
        //GetComponent<RandomFormula>().err2.Play();
        //GetComponent<playmod>().PlaySound(false);
        GameObject soundobject = Instantiate(PlaySoundConsiderTheAnswer);
        soundobject.GetComponent<playmod>().PlaySound(false);
        //Fail.Play();
        SingleToon.getInstance().curlife.damage(15);
        //Fail.Stop();
        GetComponent<CloseQuest>().Close(false);
        // 1. Player lose health points.
        // 2. Close quest.
    }

    
   
}
