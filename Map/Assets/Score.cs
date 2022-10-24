using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text LevelCompleteText;
    public GetHighGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        LevelCompleteText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (gameManager.levelCompleted == true)
        {
            LevelCompleteText.text = "GET HIGHHHHHH";
            Debug.Log("text");
        }
    }
}
