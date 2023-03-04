using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // allows us to access text stuff

// this is all quite complex as uses both Scriptable Objects AND the weirdness of 
// the TextMeshPro addon, so yeah, you might need to return to this tutorial

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    // this variable type is of our script
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons; 


    private void Start() 
    {
        // display question
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            // go to the first answerButton element, look for any TextMeshPro children
            // there's only one (the button text) so this is store in buttonText variable
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            //display answer
            buttonText.text = question.GetAnswer(i);
        }            

        
    }

}
