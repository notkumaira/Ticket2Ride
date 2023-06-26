using UnityEngine;

public class TrainCarManager : MonoBehaviour
{
    public GameObject player1Cars;
    public GameObject player2Cars;
    public GameObject winScreen;

    public bool isPlayer1Active = true;

    private int player1RemainingTrainCars;
    private int player2RemainingTrainCars;

    private void Start()
    {
        player1RemainingTrainCars = player1Cars.transform.childCount;
        player2RemainingTrainCars = player2Cars.transform.childCount;

        ActivatePlayerCars(player1Cars);
        DeactivatePlayerCars(player2Cars);
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isPlayer1Active)
            {
                DeactivatePlayerCars(player1Cars);
                ActivatePlayerCars(player2Cars);
            }
            else
            {
                DeactivatePlayerCars(player2Cars);
                ActivatePlayerCars(player1Cars);
            }

            isPlayer1Active = !isPlayer1Active;
        }
    }

    public void RouteClaimed(int routeLength)
    {
        if (isPlayer1Active)
        {
            SubtractTrainCars(player1Cars, routeLength);
        }
        else
        {
            SubtractTrainCars(player2Cars, routeLength);
        }

        CheckWinCondition();
    }

    public void SubtractTrainCars(GameObject group, int count)
    {
        int remainingTrainCars = group.transform.childCount;
        int carsToDestroy = Mathf.Min(count, remainingTrainCars);

        for (int i = 0; i < carsToDestroy; i++)
        {
            Transform lastTrainCar = group.transform.GetChild(remainingTrainCars - 1 - i);
            Destroy(lastTrainCar.gameObject);
        }

        // Update the remaining train cars count
        if (group == player1Cars)
        {
            player1RemainingTrainCars -= carsToDestroy;
        }
        else if (group == player2Cars)
        {
            player2RemainingTrainCars -= carsToDestroy;
        }
    }


    private void CheckWinCondition()
    {
        if (player1RemainingTrainCars <= 2 || player2RemainingTrainCars <= 2)
        {
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    private void ActivatePlayerCars(GameObject group)
    {
        group.SetActive(true);
    }

    private void DeactivatePlayerCars(GameObject group)
    {
        group.SetActive(false);
    }
}
