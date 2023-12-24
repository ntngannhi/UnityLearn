using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision_2 : MonoBehaviour
{
    private GameManager_2 gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager_2>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.DecreaseLives(1);
        }
        else
        { 
            gameObject.GetComponent<AnimalHunger_2>().FeedAnimal(1);
        }
    }
}
