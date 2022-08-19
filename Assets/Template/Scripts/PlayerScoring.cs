using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
This script is attached to the player. It serves multiple purposes:
1. Keeping track of each player's score in the server (using SyncVar and Command)
2. detecting collisions with items
3. ensuring that the scoreboard displays the most updated score
4. 

*/

public class PlayerScoring : NetworkBehaviour
{
    
    [SyncVar]
    private int playerScore; //keeps track of player score

    GameObject[] players; //list of players

    //this is used to play a sweeping sound to let the player know when they collect an item.
    public AudioSource source;
    [SerializeField] AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer){

            //get audio clip to be player
            source = GetComponent<AudioSource>();
            source.clip = audioClip;
            if(source == null)
            {
                Debug.Log("NULL Audio ");
            }
            Debug.Log("Source: " + source);


            //movementVector = new Vector3(0.0f, 0.0f, 0.0f);
            //rb = GetComponent<Rigidbody>();

            //player's score starts off at 0
            playerScore = 0;
            SetScoreText();
        }
    }
    


    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            
            SetScoreText();
        }
        
        
    }

    //returns player's score
    public int GetPlayerScore()
    {
        return playerScore;
    }

    //updates the players score to the server so that other players can see the most up to date score
    [Command]
    public void SetPlayerScore(int newScore)
    {
        playerScore = newScore;
    }

    //This function is invoked when the player collides with the game object. 
    //The function determines the type of item the player collided into then plays the sweeping sound to let the player know they have collected points. 
    //The item is then disabled so that players can no longer collect it. The appropriate number of points are awarded and the scoreboard is updated.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            //other.gameObject.GetComponent<Renderer>().material.color = new Color(255,0,0);
            source.Play();//play sweeping sound
            other.gameObject.SetActive(false);//disable the item
            SetPlayerScore(playerScore + 2);//award points to player
            SetScoreText();//update scoreboard
        }

        if(other.gameObject.CompareTag("PickUp2"))
        {
            //other.gameObject.GetComponent<Renderer>().material.color = new Color(255,0,0);
            source.Play();//play sweeping sound
            other.gameObject.SetActive(false);//disable the item
            SetPlayerScore(playerScore + 3);//award points to player
            SetScoreText();//update scoreboard
        }
        
    }

    //This function updates the scoreboard with the most up to date score of each player.
    public void SetScoreText()
    {
        players = GameObject.FindGameObjectsWithTag("Player"); //get list of all players

        //form the text/string to be displayed
        //for each player display player number followed by their score
        string scoreText = ""; //
        for(int i = 0; i < players.Length; i++)
        {
            scoreText+="Player ";
            scoreText+=(i+1);
            scoreText+=": ";

            int score = players[i].GetComponent<PlayerScoring>().GetPlayerScore();
            scoreText+=score;
            scoreText+="\n";
        }

        TextMeshProUGUI textDisplay = GameObject.Find("PlayerScore").GetComponent<TextMeshProUGUI>();
        textDisplay.text = scoreText;

        
    }

}
