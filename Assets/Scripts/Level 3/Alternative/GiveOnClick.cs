using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GiveOnClick : MonoBehaviour
{
    [SerializeField] private SpawnNextQuestion spawnNextQuestion;
    [SerializeField] private Button button;

    // Start is called before the first frame update
    void Start()
    {
        spawnNextQuestion = GameObject.Find("ButtonSpawns").GetComponent<SpawnNextQuestion>();
        button.onClick.AddListener(() => { callOnClick(); });
    }

    private void callOnClick()
    {
        spawnNextQuestion.OnClick(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
