using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // allows us to access text stuff
using UnityEngine.UI;

// this is all quite complex as uses both Scriptable Objects AND the weirdness of 
// the TextMeshPro addon, so yeah, you might need to return to this tutorial

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;    
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerButtonSprite;
    [SerializeField] Sprite correctAnswerButtonSprite;

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

    public void OnAnswerSelected(int index) 
    {
        Image buttonImage;

        // this is question because we created this variable above
        // if selected button matches the right answer
        if (index == question.GetCorrectAnswerIndex())
        {
            // change question to a new message
            questionText.text = "Correct!";
            // get Image component for this specific button
            buttonImage = answerButtons[index].GetComponent<Image>();
            // change it's sprite from default to correct (stored in this Script in IDE)
            buttonImage.sprite = correctAnswerButtonSprite;
        }
        else
        {
            // get correct answer index
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            // replace question with correct answer
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was\n " + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();            
            buttonImage.sprite = correctAnswerButtonSprite;
            
        }

    }

}
