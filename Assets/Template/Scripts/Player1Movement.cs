using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Movement : NetworkBehaviour
{
    Vector3 movementVector;
    private Rigidbody rb;
    private int player1Score;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer){
            movementVector = new Vector3(0.0f, 0.0f, 0.0f);
            rb = GetComponent<Rigidbody>();
            player1Score = 0;
            SetCountText();
            //gameOverText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isLocalPlayer);
        if(isLocalPlayer){
            //Debug.Log("LOCAL");
            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Bang W");
                movementVector = new Vector3(0.0f, 0.0f, 100.0f);
                rb.AddForce(movementVector);
                //transform.position = transform.position + movementVector;
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Bang A");
                movementVector = new Vector3(-100.0f, 0.0f, 0.0f);
                rb.AddForce(movementVector);
                //transform.position = transform.position + movementVector;ss
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Bang S");
                movementVector = new Vector3(0.0f, 0.0f, -100.0f);
                rb.AddForce(movementVector);
                //transform.position = transform.position + movementVector;
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Bang D");
                movementVector = new Vector3(100.0f, 0.0f, 0.0f);
                rb.AddForce(movementVector);
                //transform.position = transform.position + movementVector;
            }
        }


        

        
    }

    public int GetPlayer1Score()
    {
        return player1Score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            player1Score = player1Score + 2;
            SetCountText();
        }

        if(other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            player1Score = player1Score + 3;
            SetCountText();
        }
        
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
