using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hollow172.Scoreboards;

public class Timer : MonoBehaviour
{
    private double startTime;
    private Text timerText;
    public static bool isWon;
    private static bool rPen = false;
    private double timePenalty = 0;
    public static string timeOfWin;
    double minScoreboard;
    double secScoreboard;
    static double t;
    
    //Starting conditions
    void Start()
    {
        isWon = false;
        startTime = Time.time;
        timerText = GetComponent<Text>();
    }

    public void Update()
    {
        t = Time.time - startTime + timePenalty;
        if (isWon) {
            return; //If the game is won stop counting time
        } 
        if (rPen) //rest penalty
        {
           timePenalty = 300;
        }
        
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        timeOfWin = minutes + " : " + seconds;

        timerText.text = timeOfWin; //Displaying time 
    }
    //Setters
    public static void isWonFun()
    {
        isWon = true;
    }
    public static void restPenalty()
    {
        rPen = true;
    }
    public static double timeForScoreboard()
    {
        return t;
    }

}
