using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class documentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] documents;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private bool canSpawn = true;
    Vector3 spawnpos;

    void Start()
    {
        spawnpos.x = 0f;
        spawnpos.y = 3f;
        spawnpos.z = 2f;
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, documents.Length);
            GameObject documentToSpawn = documents[rand];

            spawnpos.z += 1f;


            Instantiate(documentToSpawn, spawnpos, Quaternion.identity);
        }
    }
}
