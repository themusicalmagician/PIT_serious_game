using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void level1()
    {
        SceneManager.LoadScene(1);
    }

    public void level2()
    {
        SceneManager.LoadScene(2);
    }

    public void level3()
    {
        SceneManager.LoadScene(3);
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
