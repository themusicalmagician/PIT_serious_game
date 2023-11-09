using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private Text answerText;

    public void SetAnswerSprite(string newText)
    {
        answerText.text = newText;
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        if (isCorrect)
        {
            Debug.Log("CORRECT ANSWER");
        }
        else
        {
            Debug.Log("WRONG ANSWER");
        }
    }
}
