using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenu : MonoBehaviour
{
    [SerializeField] private AchievementManager introAchievement;

    public IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }

    public void menuIntro()
    {
        introAchievement.EarnAchievement("Welkom bij Bike Totaal");
        introAchievement.PlaySound();
        StartCoroutine(LoadMainMenu());
    }

    public void level1Intro()
    {
        SceneManager.LoadScene(3);
    }

    public void level1()
    {
        SceneManager.LoadScene(2);
    }

    public void level2Intro()
    {
        SceneManager.LoadScene(5);
    }

    public void level2()
    {
        SceneManager.LoadScene(4);
    }

    public void level3Intro()
    {
        SceneManager.LoadScene(7);
    }

    public void level3()
    {
        SceneManager.LoadScene(6);
    }

    public void AchievementMenu()
    {
        SceneManager.LoadScene(9);
    }

    public void gameQuit()
    {
        Application.Quit();
    }

    public void CloseWindow()
    {
        transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
