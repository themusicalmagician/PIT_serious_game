using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestionLink : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] List<GameObject> buttonObjects;
    GameObject spawnpoint;
    List <int> randomized = new List<int>();
    private int rand;

    void OnEnable()
    {
        GameObject spawnpointHolder;
        spawnPoints.Clear();
        spawnpointHolder = GameObject.Find("ButtonSpawns");

        foreach (Transform child in spawnpointHolder.transform)
        {
            spawnPoints.Add(child.gameObject);
        }

        int maxLoops = 0;
        randomized.Clear();

        foreach (var button in buttons)
        {
            do
            {
                maxLoops++;
                rand = Random.Range(0, buttons.Count);
            }
            while (randomized.Contains(rand) && maxLoops < 100);
            randomized.Add(rand);
            spawnpoint = spawnPoints[rand].gameObject;
            buttonObjects.Add(Instantiate(button, spawnpoint.transform));
        }
    }

    void OnDisable()
    {
        foreach (GameObject button in buttonObjects)
        {
            Destroy(button);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
