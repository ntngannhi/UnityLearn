using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds_2 : MonoBehaviour
{
    private GameManager_2 gameManager;

    private int bottomRange = -5;
    private int upRange = 25;
    private int xRange = 25;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager_2>();
    }

    void Update()
    {
        if (transform.position.z < bottomRange)
        {
            gameManager.DecreaseLives(1);
            Destroy(gameObject);
        }
        //food ne
        else if (transform.position.z > upRange)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -xRange)
        {
            gameManager.DecreaseLives(1);
            Destroy(gameObject);
        }
        else if (transform.position.x > xRange)
        {
            gameManager.DecreaseLives(1);
            Destroy(gameObject);
        }
    }
}
