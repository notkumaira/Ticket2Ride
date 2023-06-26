using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject player1Hand;
    public GameObject player2Hand;

    private bool isPlayer1Turn = true;

    private void Start()
    {
        // Start with player 1's turn, hide player 2's hand
        player2Hand.SetActive(false);
    }

    private void Update()
    {
        // Check for "T" key press to switch turns
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Toggle turn
            isPlayer1Turn = !isPlayer1Turn;

            // Hide the previous player's hand
            if (isPlayer1Turn)
            {
                player2Hand.SetActive(false);
                player1Hand.SetActive(true);
            }
            else
            {
                player1Hand.SetActive(false);
                player2Hand.SetActive(true);
            }
        }
    }

}