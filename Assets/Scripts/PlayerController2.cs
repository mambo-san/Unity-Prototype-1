using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    //Private Variables
    private float speed = 15f;
    private float turnSpeed = 35;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the Player control from Input interface. 
        horizontalInput = Input.GetAxis("Horizontal_2");
        forwardInput = Input.GetAxis("Vertical_2");

        //Translate the user input to Vihecle movements.
        //Multiplying by Time.delta ensures user experience is consitant between all platforms regardless of FPS.
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
