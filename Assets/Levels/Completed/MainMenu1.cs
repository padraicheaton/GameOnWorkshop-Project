using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
    //This script is attached to the CAMERA in the Main Menu
{
    //Here, we need to tell the engine what buttons we want to edit!
    private Button startButton;
    private Button quitButton;

    //We are telling the engine which button we want to be the start and quit button.
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Main Menu")
        {
            startButton = GameObject.Find("Start Game Button").GetComponent<Button>();
            quitButton = GameObject.Find("Quit Game Button").GetComponent<Button>();
        }
    }

    //If you click the Start Button, it goes to Level 1!
    public void startTheGame()
    {
        SceneManager.LoadScene("Level1");
    }

    //If you click quit, it closes the game! This ONLY works once you built the game outside of Unity.
    public void quitTheGame()
    {
        Application.Quit();
    }

    public void gameToMainmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
