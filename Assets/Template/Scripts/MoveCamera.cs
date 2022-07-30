using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MoveCamera : NetworkBehaviour
{

    public GameObject camera;
    Vector3 cameraOffset;
    Quaternion cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        cameraOffset = new Vector3(0.0f, 10.0f, -10.0f);
        camera.transform.rotation = Quaternion.Euler(45.0f, 0.0f, 0.0f);
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

    void AdjustCamera()
    {
        camera.transform.position = this.transform.position + cameraOffset;
    }
}
