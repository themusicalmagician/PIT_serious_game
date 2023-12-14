using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class faultCheck : MonoBehaviour
{
    [SerializeField] private int boxNumber;
    [SerializeField] private Score score;
    [SerializeField] private documentSpawner loadNextSprite;
    [SerializeField] private AchievementManager level2Achievements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(boxNumber.ToString()))
        {
            Score.Instance.currentScore++;
            Destroy(collision.gameObject);
            if (Score.Instance.currentScore == Score.Instance.maxScore)
            {
                SceneManager.LoadScene("WinScreen");
                level2Achievements.EarnAchievement("Level 2 behaald");
                level2Achievements.PlaySound();
            }
            StartCoroutine(loadNextSprite.spawnNext());
        }
        else
        {
            Score.Instance.currentScore--;
            Destroy(collision.gameObject);
            StartCoroutine(loadNextSprite.spawnNext());
            if (Score.Instance.currentScore == -15)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }
    }
}
