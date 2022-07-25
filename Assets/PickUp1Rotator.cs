//using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mirror{

public class PickUp1Rotator : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }


    //[ServerCallback]
    /*void OnCollisionEnter2D(Collision2D col)
    {


    }*/
}

}

