using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    [SerializeField] private Text scoreText;

    public int currentScore;
    public int maxScore = 15;

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentScore + " / " + maxScore;
    }
}
