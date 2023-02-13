using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject buttons;

    //If player dies it deactivates pause menu otherwise by pressing escape it allows you to pause game
    void Update()
    {
        if (Player.health <= 0)
        {
            pauseMenu.SetActive(false);
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    DontDestroySettings.SettingInactive();
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        //if (!DontDestroySettings.instance.isActiveAndEnabled) buttons.SetActive(true);
    }
    //Functions that allow you to pause and unpause the game. Also buttons used in pause menu
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
    public void SettingsMenu()
    {
        buttons.SetActive(false);
        DontDestroySettings.SettingActive();
    }
    public void BackToPauseMenu()
    {
        //buttons.SetActive(true);
        DontDestroySettings.SettingInactive();
    }
}
