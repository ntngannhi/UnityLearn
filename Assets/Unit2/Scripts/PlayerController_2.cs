using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2 : MonoBehaviour
{
    private int speed = 5;
    private float horizontalInput;
    private float verticalInput;
    private float bottomRange = -1.75f;
    private float upRange = 16.5f;
    private float xRange = 11f;
    public GameObject food;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal2");
        verticalInput = Input.GetAxis("Vertical2");
        transform.Translate(Vector3.right*Time.deltaTime*speed*horizontalInput);
        transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);
        
        //keep the player in bounds
        if (transform.position.z < bottomRange)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,bottomRange);
        }
        if (transform.position.z > upRange)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,upRange);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }
        //space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 0.5f),food.transform.rotation);
        }
    }
}
