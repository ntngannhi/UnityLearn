using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class AnimalData
{
    public string animalPrefabName;
    public Vector3 position;
    public Quaternion rotation;
}

public class SpawnManager_2 : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private List<AnimalData> animalDataList = new List<AnimalData>();

    
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
        SpawnAnimal(180, Random.Range(-xRange, xRange), upperRange);
    }

    void SpawnLeftRandomAnimal()
    {
        SpawnAnimal(90, -xMax, Random.Range(zDown, zUpper));
    }

    void SpawnRightRandomAnimal()
    {
        SpawnAnimal(-90, xMax, Random.Range(zDown, zUpper));
    }
    void SpawnAnimal(float yRotation, float xPosition, float zPosition)
    {
        int index = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(xPosition, 0, zPosition);
        Quaternion spawnRotation = Quaternion.Euler(0, yRotation, 0);

        Instantiate(animalPrefabs[index], spawnPosition, spawnRotation);
        // Lưu thông tin vào danh sách
        AnimalData animalData = new AnimalData
        {
            animalPrefabName = animalPrefabs[index].name,
            position = spawnPosition,
            rotation = spawnRotation
        };
        animalDataList.Add(animalData);

        // Lưu danh sách vào file JSON
        SaveAnimalDataToJson();
    }

    void SaveAnimalDataToJson()
    {
        string jsonPath = Application.dataPath + "/animalData.json";
        string jsonData = JsonUtility.ToJson(animalDataList, true);
        File.WriteAllText(jsonPath, jsonData);
    }
}