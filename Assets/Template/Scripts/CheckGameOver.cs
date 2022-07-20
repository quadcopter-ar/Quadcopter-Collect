using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckGameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    //[SerializeField]
    //public static TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool GameIsOver()
    {
        int player1Score = GameObject.Find("Player1").GetComponent<Player1Movement>().GetPlayer1Score();
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
        int player1Score = GameObject.Find("Player1").GetComponent<Player1Movement>().GetPlayer1Score();

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
}
