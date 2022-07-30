using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoring : NetworkBehaviour
{
    
    [SyncVar]
    private int playerScore;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI gameOverText;
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer){
            //movementVector = new Vector3(0.0f, 0.0f, 0.0f);
            //rb = GetComponent<Rigidbody>();
            playerScore = 0;
            SetScoreText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            /*if(Input.GetKeyDown(KeyCode.W))
            {
                movementVector = new Vector3(0.0f, 0.0f, 100.0f);
                rb.AddForce(movementVector);
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                movementVector = new Vector3(-100.0f, 0.0f, 0.0f);
                rb.AddForce(movementVector);
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                movementVector = new Vector3(0.0f, 0.0f, -100.0f);
                rb.AddForce(movementVector);
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                movementVector = new Vector3(100.0f, 0.0f, 0.0f);
                rb.AddForce(movementVector);
            }*/
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            SetPlayerScore(playerScore + 2);
            SetScoreText(); 
        }

        if(other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            SetPlayerScore(playerScore + 3);
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

            int score = players[i].GetComponent<PlayerScoring>().GetPlayerScore();
            scoreText+=score;
            scoreText+="\n";
        }

        TextMeshProUGUI textDisplay = GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>();
        textDisplay.text = scoreText;

        
    }

    
}
