using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class faultCheck : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager; // Reference to AudioManager
    [SerializeField] private int boxNumber;
    [SerializeField] private Score score;
    [SerializeField] private documentSpawner loadNextSprite;
    [SerializeField] private AchievementManager level2Achievements;
    private bool perfectFail;

    private void Start()
    {
        level2Achievements = GameObject.FindGameObjectWithTag("AchievementManager").GetComponent<AchievementManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(boxNumber.ToString()))
        {
            Score.Instance.currentScore++;
            audioManager.VictorySound();
            Destroy(collision.gameObject);
            if (Score.Instance.currentScore == Score.Instance.maxScore)
            {
                level2Achievements.EarnAchievement("Level 2 behaald");
                level2Achievements.PlaySound();
                StartCoroutine(LoadWinScreen());
                Debug.Log("Start WIn");
                if (perfectFail)
                {
                    level2Achievements.EarnAchievement("Meester van level 2");
                }
            }
            StartCoroutine(loadNextSprite.spawnNext());
        }
        else
        {
            Score.Instance.currentScore--;
            audioManager.WrongSound();
            Destroy(collision.gameObject);
            perfectFail = false;
            StartCoroutine(loadNextSprite.spawnNext());
            if (Score.Instance.currentScore == -15)
            {
                SceneManager.LoadScene("LoseScreen");
            }

        }
    }
    public IEnumerator LoadWinScreen()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("WinScreen");
    }

}
