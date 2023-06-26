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
            int requiredTrainCars = CalculateRequiredTrainCars(trainCarManager.player1Cars);
            trainCarManager.SubtractTrainCars(trainCarManager.player1Cars, requiredTrainCars);
            int remainingTrainCars = trainCarManager.GetRemainingTrainCars(trainCarManager.player1Cars);
            if (remainingTrainCars <= 2)
            {
                // Player 2 wins
                ShowWinScreen(2);
            }
        }
        else
        {
            int requiredTrainCars = CalculateRequiredTrainCars(trainCarManager.player2Cars);
            trainCarManager.SubtractTrainCars(trainCarManager.player2Cars, requiredTrainCars);
            int remainingTrainCars = trainCarManager.GetRemainingTrainCars(trainCarManager.player2Cars);
            if (remainingTrainCars <= 2)
            {
                // Player 1 wins
                ShowWinScreen(1);
            }
        }
    }

    private int CalculateRequiredTrainCars(GameObject group)
    {
        int childCount = group.transform.childCount;
        int requiredTrainCars = childCount + 1; // Include the parent object
        return requiredTrainCars;
    }

    private void ShowWinScreen(int player)
    {
        // Implement your win screen logic here
        Debug.Log("Player " + player + " wins!");
    }
}
