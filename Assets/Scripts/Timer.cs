using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This script is attached to the 'TIMER' in Level 1, 'MainUI'
public class Timer : MonoBehaviour
{
    //Here we are telling the engine what we need

    //CODE BELOW HERE
    private Text timerTxt; //The text displaying the timer
    public Canvas gameOver;//The game over UI when you win!

    private void Start()
    {
        //We tell the engine what we text we want to update
        timerTxt = GameObject.Find("Timer").GetComponent<Text>();

    }

    void Update()
    {
        //CODE BELOW HERE

    }
}
