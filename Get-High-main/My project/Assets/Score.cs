using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (player.position.z + 43).ToString("0");
        if (gameManager.gameHasEnded == true)
        {
            scoreText.text = "Game Over";
        }
        if (gameManager.levelCompleted == true)
        {
            scoreText.text = "GET HIGHHHHHH";
        }
    }
}
