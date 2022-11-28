using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer1 : MonoBehaviour
    //This script is attached to the 'TIMER' in Level 1, 'MainUI'
{
    //Here we are telling the engine what we need
    public float timer; //A timer 
    private Text timerTxt; //The text displaying the timer
    public GameObject gameOver;//The game over UI when you win!

    private void Start()
    {
        //We tell the engine what we text we want to update
        timerTxt = GameObject.Find("Timer").GetComponent<Text>();

    }

    void Update()
    {
        //The time we start off with, will start counting down now
        timer -= Time.deltaTime;

        //If the timer reaches 0, we want the following...
        if(timer < 1)
        {
            // The timer should now be zero and the text should say 'Times Up!'
            timer = 0;
            gameOver.SetActive(true);
        }
        //else, if its not zero yet, we should continue to update the text on the time!
        else
            {
            timerTxt.text = Mathf.RoundToInt(timer) + " sec";
            }
        
    }
}
