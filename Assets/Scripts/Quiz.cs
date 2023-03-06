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

    void Start() 
    {
        DisplayQuestion();
    }

    void GetNextQuestion()
    {
        SetButtonState(true); // ensure buttons are enabled
        DisplayQuestion();
    }

    void DisplayQuestion()
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

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // get answer button component
            Button button = answerButtons[i].GetComponent<Button>();
            // set this to whatever state we've passed in
            button.interactable = state;
        }
    }

    public void OnAnswerSelected(int index) 
    {
        Image correctButtonImage;
        Image incorrectButtonImage;

        // this is question because we created this variable above
        // if selected button matches the right answer
        if (index == question.GetCorrectAnswerIndex())
        {
            // change question to a new message
            questionText.text = "Correct!";
            // get Image component for this specific button
            correctButtonImage = answerButtons[index].GetComponent<Image>();            
            // change it's sprite from default to correct (stored in this Script in IDE)
            correctButtonImage.sprite = correctAnswerButtonSprite;            
        }
        else
        {
            // get correct answer index
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            // replace question with correct answer
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            // display apology message
            questionText.text = "Sorry, the correct answer was\n " + correctAnswer;
            // get image of correct answer button
            correctButtonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();            
            // change sprite of correct answer button
            correctButtonImage.sprite = correctAnswerButtonSprite;
            // change colour of incorrect button clicked
            incorrectButtonImage = answerButtons[index].GetComponent<Image>();
            incorrectButtonImage.color = new Color32(255, 74, 74, 255);
            // get button
            // Button buttonInteractable = answerButtons[correctAnswerIndex].GetComponent<Button>();
            // buttonInteractable.interactable = false;         
        }
        SetButtonState(false); // prevent buttons from being clicked

    }

}
