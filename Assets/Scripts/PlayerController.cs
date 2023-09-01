using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    private float speed;
    private float rpm;
    [SerializeField] private float horsePower = 1000;
    private float turnSpeed = 35;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] private GameObject centerOfMass;
    public TextMeshProUGUI speedometerText;
    public TextMeshProUGUI rpmText;
    private List<WheelCollider> wheelColliders;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
        wheelColliders = gameObject.GetComponentsInChildren<WheelCollider>().ToList();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get the Player control from Input interface. 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            speedometerText.text = "Speed: " + speed + "km/h";

            rpm = (speed % 30) * 50;
            rpmText.text = "RPM: " + rpm;
        }

    }

    bool IsOnGround()
    {
        int wheelCount = 0;
        foreach (WheelCollider wheel in wheelColliders) 
        {
            if (wheel.isGrounded)
            {
                wheelCount++;
            }
        }
        return wheelCount == 4;
    }
}
