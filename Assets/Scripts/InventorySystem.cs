using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject player1Hand;
    public GameObject player2Hand;

    private bool isPlayer1Turn = true;

    private void Start()
    {
        // Start with player 1's turn, hide player 2's hand
        player1Hand.SetActive(true);
        player2Hand.SetActive(false);
        isPlayer1Turn = true;  // Set isPlayer1Turn to true initially
    }


    private void Update()
    {
        // Check for "T" key press to switch turns
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Toggle turn
            isPlayer1Turn = !isPlayer1Turn;

            // Toggle visibility of player hands
            if (isPlayer1Turn)
            {
                player1Hand.SetActive(true);
                player2Hand.SetActive(false);
            }
            else
            {
                player1Hand.SetActive(false);
                player2Hand.SetActive(true);
            }
        }
    }
}
