using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public static int scoreAmount;
    private Text scoreText;

    // Getting text on UI and setting it to 0
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }
    // Displaying score
    void Update()
    {
        scoreText.text = "SCORE: " + scoreAmount +"/13";
    }
}
