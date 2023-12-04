using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxCheck : MonoBehaviour
{
    [SerializeField] private int boxNumber;
    [SerializeField] private Score score;
    [SerializeField] private documentSpawner loadNextSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(boxNumber.ToString()))
        {
            Score.Instance.currentScore++;
            Destroy(collision.gameObject);
            if (Score.Instance.currentScore == Score.Instance.maxScore)
            {
                SceneManager.LoadScene("WinScreen");
            }
            StartCoroutine(loadNextSprite.spawnNext());
        }
    }
}
