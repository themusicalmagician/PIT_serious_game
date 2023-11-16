using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setButtonTag : MonoBehaviour
{
    [SerializeField] private Text answerText;
    [SerializeField] private Sprite correctSprite;
    [SerializeField] private List<Sprite> wrongSprites = new List<Sprite>();

    // Update is called once per frame
    void Update()
    {
        if(answerText != null)
        {
            buttonTagged();
        }
    }

    void buttonTagged()
    {
        if(answerText.text == "CORRECT")
        {
            gameObject.tag = "Correct";
        }
        else 
        {
            gameObject.tag = "Wrong";
        }

        if (gameObject.CompareTag("Correct"))
        {
            gameObject.GetComponent<Button>().image.sprite = correctSprite;
            answerText.text = "";
        }
        else
        {
            List<int> wrongSpriteIndex = new List<int>();
            for (int i = 0; i < wrongSprites.Count; i++)
            {
                wrongSpriteIndex.Add(i);
            }
        }
    }
}
