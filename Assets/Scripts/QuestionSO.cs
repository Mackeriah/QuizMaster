using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is all quite complex as uses both Scriptable Objects AND the weirdness of 
// the TextMeshPro addon, so yeah, you might need to return to this tutorial    

// this literally gives us the ability to right click in the IDE folder and
// select Create - Quiz Question, which in turn will create a new script
// with the name 'New Question'.
// the 'New Question' script contains the serialized fields and getterMethods
[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]

public class QuestionSO : ScriptableObject
{
    // this sets the size of the question area in the IDE.
    [TextArea(2,6)]

    // this is serialised so we can enter the question in the IDE
    [SerializeField] string question = "Enter new question text here";
    // question array serialised so we can maintain quetions in IDE
    [SerializeField] string[] answers = new string[4]; // create an empty array with 4 elements (0-3)
    [SerializeField] int correctAnswerIndex; // correct answer index stored here
    
    // getter method to return question text even though variable is private
    public string GetQuestion()
    {
        return question;
    }

    // getter method to return question answer even though private
    public string GetAnswer(int index)
    {
        return answers[index];
    }

    // getter method to return answer array index even though private
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

}
