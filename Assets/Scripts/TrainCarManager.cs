using UnityEngine;

public class TrainCarManager : MonoBehaviour
{
    public GameObject player1Cars;
    public GameObject player2Cars;
    public GameObject winScreen;

    public bool isPlayer1Active = true;

    private void Start()
    {
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

    public void RouteClaimed()
    {
        if (isPlayer1Active)
        {
            SubtractTrainCars(player1Cars, 1);
        }
        else
        {
            SubtractTrainCars(player2Cars, 1);
        }

        CheckWinCondition();
    }

    public void SubtractTrainCars(GameObject group, int count)
    {
        int remainingTrainCars = group.transform.childCount;
        if (remainingTrainCars >= count)
        {
            for (int i = 0; i < count; i++)
            {
                Transform lastTrainCar = group.transform.GetChild(remainingTrainCars - 1);
                Destroy(lastTrainCar.gameObject);
                remainingTrainCars--;
            }
        }
    }

    private void CheckWinCondition()
    {
        if (player1Cars.transform.childCount <= 2 || player2Cars.transform.childCount <= 2)
        {
            ShowWinScreen();
        }
    }

    public void ShowWinScreen()
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

    public int GetRemainingTrainCars(GameObject group)
    {
        return group.transform.childCount;
    }
}
