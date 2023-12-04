using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private Text answerText;
    [SerializeField] private Score score;
    [SerializeField] private documentSpawner nextQuestion;

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
        if (isCorrect && gameObject.CompareTag("Correct"))
        {
            Debug.Log("CORRECT ANSWER");
            Score.Instance.currentScore++;

            if (Score.Instance.currentScore == Score.Instance.maxScore)
            {
                SceneManager.LoadScene("WinScreen");
            }

            StartCoroutine(nextQuestion.spawnNext());
        }
        else
        {
            Debug.Log("WRONG ANSWER");
            Score.Instance.currentScore--;

            if(Score.Instance.currentScore == -15)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }

    }
}
