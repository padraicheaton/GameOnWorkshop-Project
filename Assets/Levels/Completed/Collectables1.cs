using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectables1 : MonoBehaviour
//This script is attached to the PLAYER!

{
    //We need to do a few things to the objects here!

    public Camera gameoverCamera;
    public GameObject player;
    private GameObject Coin; //The coins we are collecting
    private GameObject chestBox;//The chestUI that tells you its opened!
    private GameObject Lives;
    private Animator[] playerLives;

    private Text coinTxt; //The UI for the no. of coins
    private Text chestTxt; //The UI for when you collected enough coins
    public Canvas chestUI;//The chestUI that tells you its opened!
    public Canvas youLoseUI;//The game over UI when you lose!
    public Canvas youWinUI; //Win screen

    private int coinsCollected = 0; //A counter for how much we collected so far!
    public int totalCoins;
    public int lives = 3;

    public bool enemyHit;
    public bool invincisibility;
    float timer = 3;
    void Start()
    {
        //Here we are telling the engine what objects we want
        Coin = GameObject.Find("Coin");
        coinTxt = GameObject.Find("XCoins").GetComponent<Text>();
        chestTxt = GameObject.Find("Chesttxt").GetComponent<Text>();

        //Turn ALL other UI OFF!
        chestUI.enabled = false;
        youLoseUI.enabled = false;
        youWinUI.enabled = false;

        chestBox = GameObject.FindWithTag("Chest");
        chestBox.GetComponent<Animator>().enabled = false;
        Lives = GameObject.Find("Lives");
        playerLives = Lives.GetComponentsInChildren<Animator>();

        gameoverCamera.enabled = false;
        //gameoverCamera.GetComponent<Camera>().enabled = false;
    }

    //If this script is attached to the player, this means everytime the player hits something...
    private void OnTriggerEnter(Collider other)
    {
        //...with the tag collectable, we want it to do the following...
        if (other.tag == "Collectable")
        {
            //Play a sound
            coinTxt.GetComponent<AudioSource>().Play();
            //Delete the object we ran into
            Destroy(other.gameObject);
            //Add to the counter 
            coinsCollected++;
            //Update the UI of how many coins we have now
            coinTxt.text = "" + coinsCollected;
        }

        if (other.tag == "Chest")
        {
            //Turn on the You Win!
            youWinUI.enabled = true;
            chestUI.gameObject.SetActive(false);
            player.SetActive(false);
            gameoverCamera.enabled = true;
        }

        //If we have collected enough coins, then ....
        if (coinsCollected == totalCoins)
        {
            //Turn on the UI and animation to open the chest!
            chestUI.enabled = true;
            chestBox.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.collider.tag == "Enemy" )
            {
                Debug.Log("Player collided with enemy");
                //Take away a life if an enemy runs into you!
                foreach (Animator animation in playerLives)
                {
                    if (!enemyHit && !invincisibility) //If nothing is hit or on
                    {
                        lives--;
                        Debug.Log(lives);
                        playerLives[lives].enabled = true;
                        Debug.Log("Take away a life!");
                        enemyHit = true;
                        invincisibility = true;
                    }
                }
            }
    }

    private void delayLife()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 3;
            invincisibility = false;
            enemyHit = false;
        }
    }

    public void Update()
    {
        if (invincisibility)
        {
            delayLife();
            Debug.Log(timer);
        }
        if (lives == 0)
        {
            youLoseUI.enabled = true;
            player.SetActive(false);
            gameoverCamera.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
