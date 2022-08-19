//using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mirror{

public class PickUp1Rotator : MonoBehaviour
{
    
    GameObject[] players;
    float radius = 15.0f;

    // Update is called once per frame
    void Update()
    {
        Rotate();
        UpdateColor();
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }
    

    void UpdateColor()
    {
        //this.gameObject.GetComponent<Renderer>().material.color = new Color(255,200,0);
        if(PlayerNearby())
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color32(255,0,0,255);
        }
        
        else if(this.gameObject.tag == "PickUp")
        {
            
            this.gameObject.GetComponent<Renderer>().material.color = new Color32(255,200,0,255);
            
        }
        else 
        {
            
            this.gameObject.GetComponent<Renderer>().material.color = new Color32(255,255,0,255);
            
        }
        
    }

    bool PlayerNearby()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            if(Vector3.Distance(player.transform.position, this.gameObject.transform.position) <= radius)
            {
                return true;
            }
        }
        return false;
    }


    //[ServerCallback]
    /*void OnCollisionEnter2D(Collision2D col)
    {


    }*/
}

}

