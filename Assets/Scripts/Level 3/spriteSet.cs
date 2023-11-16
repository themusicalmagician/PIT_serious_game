using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteSet : MonoBehaviour
{
    //private Text answerText;
    [SerializeField] private Sprite correctSprite;
    [SerializeField] private List<Sprite> wrongSprites = new List<Sprite>();

    private void Start()
    {
        StartCoroutine(waitforInput());
    }

    IEnumerator waitforInput()
    {
        yield return new WaitForSeconds(2);
        SettingSprites();
    }

    public void SettingSprites()
    {
        foreach(Transform child in transform)
        {
            child.GetComponentInChildren<Text>().text = "";
            if (gameObject.CompareTag("Correct"))
            {
                child.GetComponent<Button>().image.sprite = correctSprite;
            }
            else
            {
                List<int> wrongSpriteIndex = new List<int>();
                for (int i = 0; i < wrongSprites.Count; i++)
                {
                    wrongSpriteIndex.Add(i);
                }
                int randomSpriteIndex = Random.Range(0, wrongSpriteIndex.Count);
                child.GetComponent<Button>().image.sprite = wrongSprites[wrongSpriteIndex[randomSpriteIndex]];
                wrongSpriteIndex.RemoveAt(randomSpriteIndex);

            }
        }
    }
}
