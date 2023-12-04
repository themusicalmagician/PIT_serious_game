using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnNextQuestion : MonoBehaviour
{

    [SerializeField] private documentSpawner nextQuestion;

    public void OnClick(GameObject button)
    {
        if (button.CompareTag("Correct"))
        {
            Debug.Log("CORRECT ANSWER");
            Debug.Log(button.name);
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
            Debug.Log(button.name);
            Score.Instance.currentScore--;

            if (Score.Instance.currentScore == -15)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }

    }
}
