using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Movement : NetworkBehaviour
{
    Vector3 movementVector;
    private Rigidbody rb;
    [SyncVar]
    private int playerScore;

    //[SyncVar]
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI gameOverText;
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer){
            movementVector = new Vector3(0.0f, 0.0f, 0.0f);
            rb = GetComponent<Rigidbody>();
            playerScore = 0;
            SetScoreText();
            //SetCountText();
            //gameOverText.gameObject.SetActive(false);
        }

        //players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isLocalPlayer);
        if(isLocalPlayer){
            //Debug.Log("LOCAL");
            if(Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("Bang W");
                movementVector = new Vector3(0.0f, 0.0f, 100.0f);
                rb.AddForce(movementVector);
                //transform.position = transform.position + movementVector;
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                //Debug.Log("Bang A");
                movementVector = new Vector3(-100.0f, 0.0f, 0.0f);
                rb.AddForce(movementVector);
                //transform.position = transform.position + movementVector;ss
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                //Debug.Log("Bang S");
                movementVector = new Vector3(0.0f, 0.0f, -100.0f);
                rb.AddForce(movementVector);
                //transform.position = transform.position + movementVector;
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                //Debug.Log("Bang D");
                movementVector = new Vector3(100.0f, 0.0f, 0.0f);
                rb.AddForce(movementVector);
                //transform.position = transform.position + movementVector;
            }
            SetScoreText();
        }


        

        
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    [Command]
    public void SetPlayerScore(int newScore)
    {
        playerScore = newScore;
    }

    //[Command]
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            //this.gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
            SetPlayerScore(playerScore + 2);
            //playerScore = playerScore + 2;
            Debug.Log("SCORE! " + playerScore);
            //SetCountText();
            SetScoreText(); 
        }

        if(other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            //this.gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
            SetPlayerScore(playerScore + 3);
            //playerScore = playerScore + 3;
            //SetCountText();
            SetScoreText();
        }
        
    }

    
    public void SetScoreText()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        string scoreText = "";
        for(int i = 0; i < players.Length; i++)
        {
            scoreText+="Player ";
            scoreText+=(i+1);
            scoreText+=": ";

            int score = players[i].GetComponent<Player1Movement>().GetPlayerScore();
            scoreText+=score;
            scoreText+="\n";
        }

        TextMeshProUGUI textDisplay = GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>();
        //player1ScoreText.text = scoreText;
        textDisplay.text = scoreText;

        //player1ScoreText.text = "Player 1's Score: " + player1Score.ToString();
        /*if(CheckGameOver.GameIsOver())
        {
            gameOverText.gameObject.SetActive(true);
            CheckGameOver.SetGameOverText(gameOverText);
            
        }*/
    }

    

    void SetCountText()
    {
        //player1ScoreText.text = "Player 1's Score: " + player1Score.ToString();
        /*if(CheckGameOver.GameIsOver())
        {
            gameOverText.gameObject.SetActive(true);
            CheckGameOver.SetGameOverText(gameOverText);
            
        }*/
    }

    
}
