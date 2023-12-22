using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds_2 : MonoBehaviour
{

    private int bottomRange = -5;
    private int upRange = 25;
    private int xRange = 25;
    void Update()
    {
        if (transform.position.z < bottomRange)
        {
           
            Destroy(gameObject);
        }
        //food ne
        else if (transform.position.z > upRange)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -xRange)
        {
            
            Destroy(gameObject);
        }
        else if (transform.position.x > xRange)
        {
            
            Destroy(gameObject);
        }
    }
}
