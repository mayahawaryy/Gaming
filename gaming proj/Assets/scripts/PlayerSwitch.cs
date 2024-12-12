using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public Move player1Move; // Reference to Player 1's move script
    public Move player2Move; // Reference to Player 2's move script
    private bool player1Active = true; // Track which player is active

    void Start()
    {
        // Start with Player 1 active and Player 2 inactive
        player1Move.enabled = true;
        player2Move.enabled = false;
    }

    void Update()
    {
        // Switch players when the RightShift key is pressed
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        // Toggle active player
        player1Active = !player1Active;

        // Enable the active player's move script and disable the other
        player1Move.enabled = player1Active;
        player2Move.enabled = !player1Active;

        // Update shooting ability based on active player
        //if (player1Active) 
        //{
            //player1Move.canShoot = true; 
          ///  player2Move.canShoot = false;
        //}
        //else 
       // {
         //   player1Move.canShoot = false;
         //   player2Move.canShoot = true;
       // }
    }
}