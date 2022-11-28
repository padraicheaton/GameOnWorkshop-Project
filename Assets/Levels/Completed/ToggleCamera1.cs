using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCamera1 : MonoBehaviour
    //This script is attached to the new camera added to the Player!
{
    // We need to do things to a few objects here!
    private Camera activateCamera; //Our extra camera
    private Text toggleT; //The Flashing text on our screen
    private CanvasGroup miniscreenTxt; //The animation we need to turn off 
    public bool Tpressed = false; //How we check if its been turned on

    void Start()
    {
        activateCamera = GameObject.Find("Camera").GetComponent<Camera>();
        toggleT = GameObject.Find("ToggleT").GetComponent<Text>();
        miniscreenTxt = GameObject.Find("Mini Screen").GetComponent<CanvasGroup>();
        activateCamera.enabled = false;
    }

    void Update()
    {
        while (Tpressed)
        {
            miniscreenTxt.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            miniscreenTxt.alpha = 0.0f;
            miniscreenTxt.GetComponent<Animator>().enabled = false;
            activateCamera.enabled = true;

        }
    }
}

