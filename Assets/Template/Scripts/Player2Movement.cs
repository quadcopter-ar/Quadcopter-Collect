using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using TMPro;

public class Player2Movement : MonoBehaviour
{
    Vector3 movementVector;
    private Rigidbody rb;
    private int player2Score;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = new Vector3(0.0f, 0.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
        player2Score = 0;
        SetCountText();
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
          Debug.Log("Bang I");
          movementVector = new Vector3(0.0f, 0.0f, 100.0f);
          rb.AddForce(movementVector);
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
          Debug.Log("Bang J");
          movementVector = new Vector3(-100.0f, 0.0f, 0.0f);
          rb.AddForce(movementVector);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
          Debug.Log("Bang K");
          movementVector = new Vector3(0.0f, 0.0f, -100.0f);
          rb.AddForce(movementVector);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
          Debug.Log("Bang L");
          movementVector = new Vector3(100.0f, 0.0f, 0.0f);
          rb.AddForce(movementVector);

        }

        
    }

    public int GetPlayer2Score()
    {
        return player2Score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            player2Score = player2Score + 2;
            SetCountText();
        }

        if(other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            player2Score = player2Score + 3;
            SetCountText();
        }
        
    }


    void SetCountText()
    {
        player2ScoreText.text = "Player 2's Score: " + player2Score.ToString();
        if(CheckGameOver.GameIsOver())
        {
            gameOverText.gameObject.SetActive(true);
            CheckGameOver.SetGameOverText(gameOverText);
            
        }
    }

    
}









/*
public class Player2Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
          Debug.Log("Bang I");
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
          Debug.Log("Bang J");
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
          Debug.Log("Bang K");
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
          Debug.Log("Bang L");
        }
    }
}
*/