using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowLongToBeatTheGame : MonoBehaviour
{
    private Text textForTime;

    void Start()
    {
        textForTime = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textForTime.text = "It took you  " + Timer.timeOfWin + "  to beat the game";
    }
}
