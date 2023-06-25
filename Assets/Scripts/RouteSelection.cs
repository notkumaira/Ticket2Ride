using UnityEngine;

public class RouteSelection : MonoBehaviour
{
    private int player1RemainingTrainCars;
    private int player2RemainingTrainCars;

    private TrainCarManager trainCarManager;

    private void Start()
    {
        player1RemainingTrainCars = 45;
        player2RemainingTrainCars = 45;

        trainCarManager = FindObjectOfType<TrainCarManager>();
        if (trainCarManager == null)
        {
            Debug.LogError("TrainCarManager script not found in the scene!");
        }
    }

    public void RouteClaimed()
    {
        if (trainCarManager.isPlayer1Active)
        {
            player1RemainingTrainCars -= 2;
            if (player1RemainingTrainCars <= 2)
            {
                // Player 2 wins
                ShowWinScreen(2);
            }
        }
        else
        {
            player2RemainingTrainCars -= 2;
            if (player2RemainingTrainCars <= 2)
            {
                // Player 1 wins
                ShowWinScreen(1);
            }
        }
    }

    private void ShowWinScreen(int player)
    {
        // Implement your win screen logic here
        Debug.Log("Player " + player + " wins!");
    }
}
