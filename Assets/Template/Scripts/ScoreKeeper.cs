using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class ScoreKeeper : NetworkBehaviour
{
    /*[SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;*/
    //[SerializeField]
    //public static TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    [SyncVar]
    public int player1Score;
    [SyncVar]
    public int player2Score;
    /*[SyncList]
    public int[] playerScores;*/
    public static GameObject[] players;

    public TextMeshProUGUI player1ScoreText;



    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        //players = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public static bool GameIsOver()
    {
        int player1Score = GameObject.Find("Player1").GetComponent<Player1Movement>().GetPlayerScore();
        int player2Score = GameObject.Find("Player2").GetComponent<Player2Movement>().GetPlayer2Score();
        if(player1Score + player2Score >= 180)
        {
            return true;
        }

        return false;
    }

    public static void SetGameOverText(TextMeshProUGUI gameOverText)
    {
        //gameOverText.text = "Player 1's Score: " + player1Score.ToString();
        int player1Score = GameObject.Find("Player1").GetComponent<Player1Movement>().GetPlayerScore();

        int player2Score = GameObject.Find("Player2").GetComponent<Player2Movement>().GetPlayer2Score();
        if(player1Score > player2Score)
        {
            gameOverText.text = "Player 1 Wins!";
            //GameObject.Find("GameOver").text = "Player 1 Wins!";
        }
        else if(player1Score < player2Score)
        {
            gameOverText.text = "Player 2 Wins!";
        }
        else
        {
            gameOverText.text = "Tie!";
        }
    }

    public void StartGame()
    {


    }
    
    void SetScoreText()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        string scoreText = "";
        for(int i = 0; i < players.Length; i++)
        {
            scoreText+="Player ";
            scoreText+=(i+1);
            scoreText+=": ";

            int playerScore = players[i].GetComponent<Player1Movement>().GetPlayerScore();
            scoreText+=playerScore;
            scoreText+="\n";
        }

        player1ScoreText.text = scoreText;

        //player1ScoreText.text = "Player 1's Score: " + player1Score.ToString();
        /*if(CheckGameOver.GameIsOver())
        {
            gameOverText.gameObject.SetActive(true);
            CheckGameOver.SetGameOverText(gameOverText);
            
        }*/
    }


/*
    public static void UpdateScore(GameObject player, int pointsAdded)
    {
        if(player == players[0])
        {
            player1Score+=pointsAdded;
        }
        else
        {
            player2Score+=pointsAdded;
        }
            
    }*/


}
