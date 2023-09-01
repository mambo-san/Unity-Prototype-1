using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 defaultoffset = new Vector3(0, 3.5f, 0);
    private Vector3 reverseOffset = new Vector3(0, 3.5f, -1.5f);
    private Vector3 centerOffset = new Vector3(0, 3.5f, 0);

    private bool rightCamera;
    private bool leftCamera;
    public bool reverseCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void LateUpdate()
    {
        Transform playerTransform = player.transform;
        //Get user inputs
        rightCamera = Input.GetKey(KeyCode.E);
        leftCamera = Input.GetKey(KeyCode.Q);
        reverseCamera = Input.GetKey(KeyCode.R);
        

        //Right, Left, Rerverse camera, else center
        if (rightCamera)
        {
            transform.SetPositionAndRotation(playerTransform.position + centerOffset, Quaternion.LookRotation(playerTransform.right));
        }
        else if (leftCamera)
        {
            transform.SetPositionAndRotation(playerTransform.position + centerOffset, Quaternion.LookRotation(playerTransform.right * -1));
        }
        else if (reverseCamera)
        {
            transform.SetPositionAndRotation(playerTransform.position + reverseOffset, Quaternion.LookRotation(playerTransform.forward * -1));
        }
        else
        {
            transform.SetPositionAndRotation(playerTransform.position + defaultoffset, Quaternion.LookRotation(playerTransform.forward));
        }
    }
}
