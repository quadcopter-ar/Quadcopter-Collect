using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/*
This script ensures that the camera's position and rotation is consistent with that of the player. This script is attached to the player prefab.
*/

public class MoveCamera : NetworkBehaviour
{

    public GameObject camera;
    Vector3 cameraOffset;
    Quaternion cameraRotation;
    Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("XRRig"); //XRRig is the camera for Oculus devices.
        cameraOffset = new Vector3(0.0f, 0.0f, 0.0f); //This can be nodified if it is desired for the camera to be a certain distance/direction away from the player
        camera.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); //The camera rotation starts off not rotated in any direction, consistent with the player
        AdjustCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
        {
            AdjustCamera();
        }
        
    }

    //This function makes the camera's position and rotation consistent with those of the player. 
    void AdjustCamera()
    {
        camera.transform.position = this.transform.position + cameraOffset;
        camera.transform.rotation = this.transform.rotation;
    }

}
