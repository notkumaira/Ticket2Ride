using UnityEngine;

public class RouteSelection : MonoBehaviour
{
    public bool isRouteClaimed = false;

    private TrainCarManager trainCarManager;

    private void Start()
    {
        trainCarManager = FindObjectOfType<TrainCarManager>();
        if (trainCarManager == null)
        {
            Debug.LogError("TrainCarManager script not found in the scene!");
        }
    }

    public void RouteClaimed()
    {
        if (!isRouteClaimed)
        {
            if (trainCarManager.isPlayer1Active)
            {
                trainCarManager.SubtractTrainCars(trainCarManager.player1Cars, 1);
            }
            else
            {
                trainCarManager.SubtractTrainCars(trainCarManager.player2Cars, 1);
            }

            CheckWinCondition();

            isRouteClaimed = true;
        }
    }

    private void CheckWinCondition()
    {
        if (trainCarManager.GetRemainingTrainCars(trainCarManager.player1Cars) <= 2 || trainCarManager.GetRemainingTrainCars(trainCarManager.player2Cars) <= 2)
        {
            trainCarManager.ShowWinScreen();
        }
    }
}
