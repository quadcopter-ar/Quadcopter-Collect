using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    Vector3 movementVector;
    Vector3 currentDirection;
    //private Rigidbody rb;
    public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        movementVector = new Vector3(0.0f, 0.0f, 0.0f);
        //rb = GetComponent<Rigidbody>();

        //this.GetComponent<Renderer>().material.color.a = 0.5f;

        Color tempcolor = this.GetComponent<MeshRenderer>().material.color;
        tempcolor.a = 1.0f;
        GetComponent<MeshRenderer>().material.color = tempcolor;
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            if(Input.GetKey(KeyCode.W))
            {
                movementVector = new Vector3(0.0f, 0.0f, 0.1f);

                var rotationX = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).x;
                var rotationY = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).y;
                var rotationZ = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).z;
                movementVector = Quaternion.Euler(rotationX, rotationY, rotationZ) * movementVector;
                
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.A))
            {
                movementVector = new Vector3(-0.1f, 0.0f, 0.0f);

                var rotationX = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).x;
                var rotationY = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).y;
                var rotationZ = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).z;
                movementVector = Quaternion.Euler(rotationX, rotationY, rotationZ) * movementVector;

                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.S))
            {
                movementVector = new Vector3(0.0f, 0.0f, -0.1f);
                
                var rotationX = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).x;
                var rotationY = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).y;
                var rotationZ = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).z;
                movementVector = Quaternion.Euler(rotationX, rotationY, rotationZ) * movementVector;
                
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.D))
            {
                movementVector = new Vector3(0.1f, 0.0f, 0.0f);
                
                var rotationX = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).x;
                var rotationY = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).y;
                var rotationZ = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).z;
                movementVector = Quaternion.Euler(rotationX, rotationY, rotationZ) * movementVector;
                
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.E))
            {
                movementVector = new Vector3(0.0f, 0.1f, 0.0f);
                
                var rotationX = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).x;
                var rotationY = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).y;
                var rotationZ = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).z;
                movementVector = Quaternion.Euler(rotationX, rotationY, rotationZ) * movementVector;
                
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.C))
            {
                movementVector = new Vector3(0.0f, -0.1f, 0.0f);
                
                var rotationX = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).x;
                var rotationY = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).y;
                var rotationZ = UnityEditor.TransformUtils.GetInspectorRotation(camera.transform).z;
                movementVector = Quaternion.Euler(rotationX, rotationY, rotationZ) * movementVector;
                
                this.transform.position = this.transform.position + movementVector;
            }

            CheckBoundaries();
            
        }
    }

    void CheckBoundaries()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -15.0f, 15.0f), Mathf.Clamp(this.transform.position.y, 0.5f, 15.0f), Mathf.Clamp(this.transform.position.z, -15.0f, 15.0f));
    }
}
