//using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is attached to both of the PickUp prefabs. This does 2 things:

1. Makes the pickup objects rotate so they can easily be seen

2. Makes the pickup object turn red if there exists a player within a certain radius, which can be set in the radius field below. 

*/

namespace Mirror{

    public class PickUp : MonoBehaviour
    {
        
        GameObject[] players; //list of players
        float radius = 1.5f; //any items within this radius from a player will be red

        // Update is called once per frame
        void Update()
        {
            Rotate();
            UpdateColor();
        }

        //rotates the item
        void Rotate()
        {
            transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
        }
        
        /*
        This function updates the color of the item based on whether or not there is a player nearby. 
        If there is, the item should turn red. Otherwise, it should be its original color.
        */
        void UpdateColor()
        {
            //checks to see if there is a player within the radius.
            if(PlayerNearby())
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color32(255,0,0,255);
            }
            
            //If there are no players nearby, the item should be its original color depending on which type of item.
            else if(this.gameObject.tag == "PickUp")
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color32(255,200,0,255); //items of the "PickUp" prefab should have this rgba value.
            }
            else 
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color32(255,255,0,255); //items of the "PickUp2" prefab should have this rgba value.
                
            }
            
        }

        //this function returns true if at least one of the players is within radius distance away from the gameobject 
        bool PlayerNearby()
        {
            //get list of all players
            players = GameObject.FindGameObjectsWithTag("Player");

            //for each player, find its distance between the player and the gameobject. If player is close enough, this function should return true.
            foreach(GameObject player in players)
            {
                if(Vector3.Distance(player.transform.position, this.gameObject.transform.position) <= radius)
                {
                    return true;
                }
            }
            return false; // No players were found within the radius from the item.
        }


        
    }

}

