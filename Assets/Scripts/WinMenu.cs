using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hollow172.Scoreboards;

public class WinMenu : MonoBehaviour
{

    private static string playerNick;
    public static bool didPressApply;
    //Getting componento to showcase time of win
    private void Start()
    {
        didPressApply = false;
    }
    //Reading nickname
    public void ReadStringInput(string playerInput)
    {
        playerNick = playerInput;
    }
    public static string ReadPlayerNick()
    {
        return playerNick;
    }
    public void HighscoresButton()
    {
        SceneManager.LoadScene("ScoreboardScene");
    }

    public void ApplyButton()
    {
        didPressApply = true;
    }
}
