using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxCheck : MonoBehaviour
{
    [SerializeField] private int boxNumber;
    [SerializeField] private Score score;
    [SerializeField] private documentSpawner loadNextSprite;
    [SerializeField] private AchievementManager level1Achievements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(boxNumber.ToString()))
        {
            Score.Instance.currentScore++;
            Destroy(collision.gameObject);
            if (Score.Instance.currentScore == Score.Instance.maxScore)
            {
                level1Achievements.EarnAchievement("Level 1 behaald");
                level1Achievements.PlaySound();
                StartCoroutine(LoadWinScreen());
            }
            StartCoroutine(loadNextSprite.spawnNext());
        }
    }

    public IEnumerator LoadWinScreen()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("WinScreen");
    }
}
