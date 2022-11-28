using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCoin1 : MonoBehaviour
    //This script is attached to the Coin!
{
    //Here we can make it spin how fast we want
    public float SpeedOfSpin = 2;

    //We want to spin whatever this script is attached to, forever in a specific direction
    void Update()
    {
        transform.Rotate(0, SpeedOfSpin, 0 * Time.deltaTime); 
    }
}
