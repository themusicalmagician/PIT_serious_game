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
    [SerializeField] private bool level4 = false;

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
                if (level4) // Check if level 4 bool is true
                {
                    level3Achievements.EarnAchievement("Level 4 behaald"); // Call EarnAchievement for level 4
                    level3Achievements.PlaySound(); // Play sound for level 4 achievement
                }
                else
                {
                    level3Achievements.EarnAchievement("Level 3 behaald"); // Call EarnAchievement for level 3
                    level3Achievements.PlaySound(); // Play sound for level 3 achievement
                }
                StartCoroutine(LoadWinScreenAfterDelay());
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

                if (Score.Instance.currentScore == -Score.Instance.maxScore) // Trigger at negative of maxScore
                {
                    SceneManager.LoadScene("LoseScreen");
                }
            }
        }
    }

    private IEnumerator LoadWinScreenAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene("WinScreen");
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
