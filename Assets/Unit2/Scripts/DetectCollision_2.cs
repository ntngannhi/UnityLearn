using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision_2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GameOver");
        }
        else
        { 
           
           Destroy(gameObject);
           Destroy(other.gameObject); 
        }
    }
}
