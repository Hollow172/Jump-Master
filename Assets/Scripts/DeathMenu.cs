using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenu;

    //If player reaches 0 health deathmenu is set active and time is stopped
    private void Update()
    {
        if(Player.health <= 0)
        {
            Time.timeScale = 0f;
            deathMenu.SetActive(true);
        }
    }
    //Buttons for death menu
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButton()
    {
        Player.health = 3; //Health is set here back to 3 so the time in menu is properly set to 1 and not 0
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
