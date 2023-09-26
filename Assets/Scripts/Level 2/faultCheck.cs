using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class faultCheck : MonoBehaviour
{
    [SerializeField] private int boxNumber;
    [SerializeField] private Score score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(boxNumber.ToString()))
        {
            Score.currentScore++;
            Destroy(collision.gameObject);
            if (Score.currentScore == Score.maxScore)
            {
                SceneManager.LoadScene("WinScreen");
            }

        }
        else
        {
            Score.currentScore--;
            Destroy(collision.gameObject);
        }
    }
}
