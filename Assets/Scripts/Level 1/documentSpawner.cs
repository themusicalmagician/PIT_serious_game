using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class documentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] documents;
    [SerializeField] private bool canSpawn = true;

    [SerializeField] private int MaxSpawn;
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int z;

    [SerializeField] private GameObject currentDocument;

    Vector3 spawnpos;

    void Start()
    {
        spawnpos.x = x;
        spawnpos.y = y;
        spawnpos.z = z;
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(1);

        while (canSpawn && MaxSpawn >= 1)
        {
            yield return wait;
            int rand = Random.Range(0, documents.Length);
            GameObject documentToSpawn = documents[rand];

            spawnpos.z += 1f;


            currentDocument = Instantiate(documentToSpawn, spawnpos, Quaternion.identity);
            MaxSpawn--;
        }
    }


    public IEnumerator spawnNext()
    {
        yield return new WaitForSeconds(1);
        Destroy(currentDocument);
        MaxSpawn = 1;
        int rand = Random.Range(0, documents.Length);
        GameObject documentToSpawn = documents[rand];

        spawnpos.z += 1f;


        currentDocument = Instantiate(documentToSpawn, spawnpos, Quaternion.identity);
        Debug.Log("next Spawned");
    }
}
