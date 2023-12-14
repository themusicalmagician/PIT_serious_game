using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DisableScript : MonoBehaviour
{
    [SerializeField] private QuestionLink questionLink;

    // Start is called before the first frame update
    void Start()
    {
        questionLink = gameObject.GetComponent<QuestionLink>();
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Level 1")
        {
            questionLink.enabled = false;
        }
        else if(sceneName == "Level 2")
        {
            questionLink.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
