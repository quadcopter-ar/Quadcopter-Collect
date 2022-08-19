using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using Mirror;

/*
This script is attached to the player prefab. This script is responsible for receiving input from Oculus devices in order to move and/or rotate the player. 
This script was provided in the template. I added some code to this script to ensure the camera is consistent with the player with position and rotation. 

*/


public class BasicMovement : NetworkBehaviour
{
    float deadZoneAmount = 0.5f;
    public float speed = 10;

    public bool debugMode = false;
    private XRNode leftControllerNode = XRNode.LeftHand;
    private List<UnityEngine.XR.InputDevice> leftInputDevices = new List<UnityEngine.XR.InputDevice>();
    private UnityEngine.XR.InputDevice leftController;

    
    private XRNode rightControllerNode = XRNode.RightHand;
    private List<UnityEngine.XR.InputDevice> rightInputDevices = new List<UnityEngine.XR.InputDevice>();
    private UnityEngine.XR.InputDevice rightController;

    private Gamepad gamepad;

    
    public GameObject cameraXRRig; //this is the camera for Oculus devices
    Vector3 cameraOffset;


    void Start() {


        cameraXRRig = GameObject.Find("XRRig");
        cameraOffset = new Vector3(0.0f, 0.0f, 0.0f); //This can be nodified if it is desired for the camera to be a certain distance/direction away from the player



        //Lets get all the devices we can find.
        if(!debugMode){
          GetDevices();
        }else{
          gamepad = Gamepad.current;
          if(gamepad == null){
            Debug.LogError("No gamepad connected");
            return;
          }
        }
    }

    void Update() {
        if(!isLocalPlayer)
        {
          return;
        }
        if(!debugMode){
            if (leftController == null) {
                GetControllerDevices(leftControllerNode, ref leftController, ref leftInputDevices);
            }

            if (rightController == null) {
                GetControllerDevices(rightControllerNode, ref rightController, ref rightInputDevices);
            }

            CheckForChanges();
            AdjustCamera();
        }else{
          Vector2 leftStick = gamepad.leftStick.ReadValue();
          Vector2 rightStick = gamepad.rightStick.ReadValue();
          Debug.Log(leftStick);
          Debug.Log(rightStick);
          if(leftStick != Vector2.zero){
            if(leftStick.x < -deadZoneAmount){
              MoveRight(leftStick.x);
            }else if(leftStick.x > deadZoneAmount){
              MoveLeft(leftStick.x);
            }

            if (leftStick.y < -deadZoneAmount) {
                // touching bottom side, move backwards
                MoveForward(leftStick.y);
            } else if (leftStick.y > deadZoneAmount) {
                // touching top side, move forward
                MoveBackward(leftStick.y);
            }
          }


          if(rightStick != Vector2.zero){
            if(rightStick.x < -deadZoneAmount){
              RotateLeft(rightStick.x);
            }else if(rightStick.x > deadZoneAmount){
              RotateRight(rightStick.x);
            }

            if (rightStick.y < -deadZoneAmount) {
              MoveUp(rightStick.y);
            } else if (rightStick.y > deadZoneAmount) {
                // touching top side, move forward
                MoveDown(rightStick.y);
            }
          }

        }
    }

    //Here we need to add code to work
    void CheckForChanges() {
        Vector2 leftTouchCoords;
        Vector2 rightTouchCoords;
        bool triggerVal;
        //Debug.Log("Bang");
        if (leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out leftTouchCoords) && leftTouchCoords != Vector2.zero)
        {
            Debug.Log("RightController");
            if(leftTouchCoords.x < -deadZoneAmount){
              MoveLeft(leftTouchCoords.x);
            }else if(leftTouchCoords.x > deadZoneAmount){
              MoveRight(leftTouchCoords.x);
            }

            if (leftTouchCoords.y < -deadZoneAmount) {
                MoveBackward(leftTouchCoords.y);
            } else if (leftTouchCoords.y > deadZoneAmount) {
                MoveForward(leftTouchCoords.y);
            }
        }

        if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out rightTouchCoords) && rightTouchCoords != Vector2.zero)
        {
            Debug.Log("LeftController");
            if(rightTouchCoords.x < -deadZoneAmount){
              RotateLeft(rightTouchCoords.x);
            }else if(rightTouchCoords.x > deadZoneAmount){
              RotateRight(rightTouchCoords.x);
            }

            if (rightTouchCoords.y < -deadZoneAmount) {
              MoveDown(rightTouchCoords.y);
            } else if (rightTouchCoords.y > deadZoneAmount) {
              MoveUp(rightTouchCoords.y);
            }
        }

    }

    void MoveForward(float input){
      MoveObject(Vector3.forward * input * Time.deltaTime * speed);
    }
    void MoveBackward(float input){
      MoveObject(Vector3.back * input * Time.deltaTime * -speed);
    }

    void MoveLeft(float input){
      MoveObject(Vector3.left* input * Time.deltaTime * -speed);
    }

    void MoveRight(float input){
      MoveObject(Vector3.right * input * Time.deltaTime * speed);
    }

    void MoveUp(float input){
      MoveObject(Vector3.up * input * Time.deltaTime * speed);
    }

    void MoveDown(float input){
      MoveObject(Vector3.down * input * Time.deltaTime * -speed);
    }

    void RotateLeft(float input){
      RotateObject(Vector3.up * input * Time.deltaTime * speed*10);
    }

    void RotateRight(float input){
      transform.Rotate(Vector3.down * input * Time.deltaTime * -speed * 10);
      cameraXRRig.transform.rotation = this.transform.rotation; //sets camera rotation to be same as that of the player.
      
    }
    void MoveObject(Vector3 tranlation){
      transform.Translate(tranlation);
    }

    void RotateObject(Vector3 rotation){
      transform.Rotate(rotation);
      cameraXRRig.transform.rotation = this.transform.rotation; //sets camera rotation to be same as that of the player.
    }

    //sets camera position to be same as that of the player.
    void AdjustCamera()
    {
        cameraXRRig.transform.position = this.transform.position + cameraOffset;
    }

    void GetDevices() {
        //Gets the Right Controller Devices
        GetControllerDevices(leftControllerNode, ref leftController, ref leftInputDevices);

        //Gets the Right Controller Devices
        GetControllerDevices(rightControllerNode, ref rightController, ref rightInputDevices);


        Debug.Log(string.Format("Device name '{0}' with characteristics '{1}'", leftController.name, leftController.characteristics));

        Debug.Log(string.Format("Device name '{0}' with characteristics '{1}'", rightController.name, rightController.characteristics));

    }

    void GetControllerDevices(XRNode controllerNode, ref UnityEngine.XR.InputDevice controller,ref List<UnityEngine.XR.InputDevice> inputDevices) {
        Debug.Log("Get devices is called");
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(controllerNode, inputDevices);

        if (inputDevices.Count == 1){
            controller = inputDevices[0];
            Debug.Log(string.Format("Device name '{0}' with characteristics '{1}'", controller.name, controller.characteristics));
        }

        if (inputDevices.Count > 1) {
            Debug.LogAssertion("More than one device found with the same input characteristics");
        }
    }

}
