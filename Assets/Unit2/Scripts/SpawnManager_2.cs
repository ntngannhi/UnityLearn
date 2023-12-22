using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_2 : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private int upperRange = 20;
    private int xRange = 22;
    private int xMax = 25;
    private int zUpper = 15;
    private int zDown = 1;
    private float startDelay = 1;
    private float spawnInterval = 1.5f;
    
    // Update is called once per frame
    
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, 3);
        InvokeRepeating("SpawnLeftRandomAnimal", startDelay, 4);
        InvokeRepeating("SpawnRightRandomAnimal", startDelay, 5.5f);
    }

    void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animalPrefabs.Length);
        int xRandom = Random.Range(-xRange, xRange);
        Instantiate(animalPrefabs[index], new Vector3(xRandom, 0, upperRange),
                animalPrefabs[index].transform.rotation);
    }

    void SpawnLeftRandomAnimal()
    {
        Vector3 rotation = new Vector3(0, 90, 0);
        int index = Random.Range(0, animalPrefabs.Length);
        int zRandom = Random.Range(zDown, zUpper);
        Instantiate(animalPrefabs[index], new Vector3(-xMax, 0, zRandom),
            Quaternion.Euler(rotation));
    }
    void SpawnRightRandomAnimal()
    {
        Vector3 rotation = new Vector3(0, -90, 0);
        int index = Random.Range(0, animalPrefabs.Length);
        int zRandom = Random.Range(zDown, zUpper);
        Instantiate(animalPrefabs[index], new Vector3(xMax, 0, zRandom),
            Quaternion.Euler(rotation));
    }
}
