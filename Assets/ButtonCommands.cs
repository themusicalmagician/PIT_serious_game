using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonCommands : MonoBehaviour
{
    public GameObject introObject;
    public JournaalSpawner DocCheck;
   

    void Start()
    {
        DocCheck = GameObject.FindGameObjectWithTag("DocumentCheck").GetComponent<JournaalSpawner>();
    }

    public void DeactivateSelf()
    {
        introObject.gameObject.SetActive(false);
    }

    public void Level5Check()
    {
        //// Assuming you want to check the current document, you can pass it as an argument
        //GameObject currentDocument = DocCheck.GetCurrentDocument(); // Implement a method to get the current document
        //DocCheck.CheckDocument(currentDocument);
    }

}
