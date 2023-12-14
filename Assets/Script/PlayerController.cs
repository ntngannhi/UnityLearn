using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20;
    private float turnSpeed = 45;
    public float horizontalInput, forwardInput;
    public string inputId;
    public KeyCode switchKey;
    public Camera mainCamera;
    public Camera hoodCamera;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"+inputId);
        forwardInput = Input.GetAxis("Vertical"+inputId);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotate instead of slide
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
