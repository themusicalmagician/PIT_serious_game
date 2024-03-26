using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnNextQuestion : MonoBehaviour
{
    [SerializeField] private GameObject wrongTip;
    [SerializeField] private GameObject windowTop;
    [SerializeField] private documentSpawner nextQuestion;
    [SerializeField] private AchievementManager level3Achievements;
    [SerializeField] private bool isTestLevel = false;

    [SerializeField] private AudioClip goodJobSound; // Add this variable
    [SerializeField] private AudioClip wrongSound; // Add this variable

    private AudioSource audioSource; // Add this variable

    private void Start()
    {
        wrongTip = GameObject.FindWithTag("WindowTip");
        wrongTip.SetActive(false);

        windowTop = GameObject.FindWithTag("WindowTop");
        windowTop.SetActive(false);

        audioSource = GetComponent<AudioSource>(); // Initialize the audio source
    }

    public void OnClick(GameObject button)
    {
        if (button.CompareTag("Correct"))
        {
            Debug.Log("CORRECT ANSWER");
            Debug.Log(button.name);
            Score.Instance.currentScore++;

            if (Score.Instance.currentScore == Score.Instance.maxScore)
            {
                level3Achievements.EarnAchievement("Level 3 behaald");
                level3Achievements.PlaySound();
                SceneManager.LoadScene("WinScreen");
            }

            StartCoroutine(nextQuestion.spawnNext());

            // Show and animate windowTop
            ShowAndAnimateWindow(windowTop, goodJobSound);
        }
        else
        {
            Debug.Log("WRONG ANSWER");
            Debug.Log(button.name);

            if (isTestLevel)
            {
                ShowAndAnimateWindow(wrongTip, wrongSound);
            }
            else
            {
                ShowAndAnimateWindow(wrongTip, wrongSound);
                Score.Instance.currentScore--;

                if (Score.Instance.currentScore == -15)
                {
                    SceneManager.LoadScene("LoseScreen");
                }
            }
        }
    }

    private void ShowAndAnimateWindow(GameObject window, AudioClip sound)
    {
        window.SetActive(true);
        audioSource.PlayOneShot(sound); // Play the corresponding sound


        StartCoroutine(HideWindow(window));
    }

    private IEnumerator HideWindow(GameObject window)
    {
        yield return new WaitForSeconds(1f); // Delay before starting to fade

        window.SetActive(false);
    }
}
