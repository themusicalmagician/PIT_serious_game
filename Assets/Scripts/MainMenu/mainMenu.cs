using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void menuIntro()
    {
        SceneManager.LoadScene(1);
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
