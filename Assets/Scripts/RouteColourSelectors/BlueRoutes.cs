using UnityEngine;

public class BlueRoutes : MonoBehaviour
{
    private void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        Player player1 = gameManager.player1.GetComponent<Player>();
        Player player2 = gameManager.player2.GetComponent<Player>();

        // Access player1's train cards
        foreach (string trainCard in player1.GetTrainCards())
        {
            Debug.Log("Player 1 Train Card: " + trainCard);
        }

        // Access player1's destination tickets
        foreach (string ticket in player1.GetDestinationTickets())
        {
            Debug.Log("Player 1 Destination Ticket: " + ticket);
        }

        // Access player2's train cards
        foreach (string trainCard in player2.GetTrainCards())
        {
            Debug.Log("Player 2 Train Card: " + trainCard);
        }

        // Access player2's destination tickets
        foreach (string ticket in player2.GetDestinationTickets())
        {
            Debug.Log("Player 2 Destination Ticket: " + ticket);
        }
    }
}
