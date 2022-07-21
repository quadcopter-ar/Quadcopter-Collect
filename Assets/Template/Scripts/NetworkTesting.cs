using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTesting : NetworkBehaviour
{
    void HandleMovement()
    {
        if(isLocalPlayer)
        {
            //Debug.Log("Bang IsLocalPlayer");
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            transform.position = transform.position + movement;
        }
    }

    void Update()
    {
        HandleMovement();
        //Debug.Log("Bang");
        if(isLocalPlayer)
        {
            //Debug.Log("Bang IsLocalPlayer A");
            if(Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("G pressed");
            }
        }
    }
}
