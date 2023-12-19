using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward_2 : MonoBehaviour
{
    private int speed = 6;
    
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }
}
