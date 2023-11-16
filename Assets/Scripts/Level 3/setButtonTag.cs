using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setButtonTag : MonoBehaviour
{
    [SerializeField] private Text answerText;

    // Update is called once per frame
    void Update()
    {
        if(answerText != null)
        {
            buttonTagged();
        }
    }

    public void buttonTagged()
    {
        if(answerText.text == "CORRECT")
        {
            gameObject.tag = "Correct";
        }
        else 
        {
            gameObject.tag = "Wrong";
        }
    }
}
