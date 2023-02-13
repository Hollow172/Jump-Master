using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainCanvasUI;
    //Buttons for main menu
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void HighscoresButton()
    {
        SceneManager.LoadScene("ScoreboardScene");
    }
    public void SettingsButton()
    {
        mainCanvasUI.SetActive(false);
        DontDestroySettings.SettingActive();
    }
}
