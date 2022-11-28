using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    //This is the animation for the chest to open
    public Animator chestAnim; 

	void Awake ()
    {
        //Tell the engine what animation we want to use
        chestAnim = GetComponent<Animator>();
	}

    //If the player runs into the treasure chest, then it will open! 
    public void nCollisionEnter(Collision collision)
    {
        
    }

}
