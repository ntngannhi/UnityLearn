using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_2 : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private int upperRange = 20;
    private int xRange = 23;
    private float startDelay = 1;
    private float spawnInterval = 1.5f;

    // Update is called once per frame
    
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animalPrefabs.Length);
        int xRandom = Random.Range(-xRange, xRange);
        Instantiate(animalPrefabs[index], new Vector3(xRandom, 0, upperRange),
                animalPrefabs[index].transform.rotation);
    }
}
