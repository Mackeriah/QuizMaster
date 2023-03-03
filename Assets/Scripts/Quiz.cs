using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // allows us to access text stuff

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;

    // this variable type is of our script
    [SerializeField] QuestionSO question;    


    private void Start() 
    {
        questionText.text = question.GetQuestion();        
    }

}
