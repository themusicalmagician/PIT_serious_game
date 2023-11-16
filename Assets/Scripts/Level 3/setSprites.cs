using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSprites : MonoBehaviour
{
    [SerializeField] private List<string> text = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void btnLoop()
    {
        foreach(Transform child in transform)
        {
            text.Add(child.GetChild(0).GetComponent<Text>().text);
        }
    }
}
