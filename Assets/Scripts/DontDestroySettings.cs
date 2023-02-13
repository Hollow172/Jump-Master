using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroySettings : MonoBehaviour
{
    public static GameObject settingsMenu;
    public static DontDestroySettings instance;
    [SerializeField] GameObject mainMenuUI;
    Scene currentScene;
    string sceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        settingsMenu = gameObject;
        settingsMenu.SetActive(false);
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name.ToString();
        Debug.Log(sceneName);
    }

    public static void SettingActive()
    {
        settingsMenu.SetActive(true);
    }

    public static void SettingInactive()
    {
        settingsMenu.SetActive(false);
    }

    public void BackButton()
    {
        UImenuActive.SetActiveMenu();
        gameObject.SetActive(false);

    }

}
