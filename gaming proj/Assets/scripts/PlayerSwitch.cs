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
        // Start with Player 1 active and Player 2 inactive for shooting
        player1Move.canShoot = true;
        player2Move.canShoot = false;
    }

    void Update()
    {
        // Switch players when either RightShift or LeftShift key is pressed
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        // Toggle active player
        player1Active = !player1Active;

        // Enable shooting for the active player and disable for the other
        player1Move.canShoot = player1Active;
        player2Move.canShoot = !player1Active;
    }
}