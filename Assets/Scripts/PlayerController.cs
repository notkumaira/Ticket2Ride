using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isPlayer1Turn = true; // Set the initial turn to player 1
    private bool hasPerformedAction = false; // Flag to track if the player has performed an action

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!hasPerformedAction)
            {
                // Perform the action based on the current turn
                if (isPlayer1Turn)
                {
                    // Player 1's turn actions
                    GetDestinationTickets();
                    ClaimTrainCards();
                    ClaimRoute();
                }
                else
                {
                    // Player 2's turn actions
                    GetDestinationTickets();
                    ClaimTrainCards();
                    ClaimRoute();
                }

                hasPerformedAction = true; // Set the flag to indicate that an action has been performed
            }
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            hasPerformedAction = false; // Reset the flag when the "T" key is released
        }
    }

    private void GetDestinationTickets()
    {
        // Add logic for getting destination tickets
        Debug.Log("Player " + (isPlayer1Turn ? "1" : "2") + " got destination tickets.");
    }

    private void ClaimTrainCards()
    {
        // Add logic for claiming train cards
        Debug.Log("Player " + (isPlayer1Turn ? "1" : "2") + " claimed train cards.");
    }

    private void ClaimRoute()
    {
        // Add logic for claiming a route
        Debug.Log("Player " + (isPlayer1Turn ? "1" : "2") + " claimed a route.");
    }

    private void SwitchTurn()
    {
        isPlayer1Turn = !isPlayer1Turn; // Switch the turn between player 1 and player 2
    }
}
