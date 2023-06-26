using UnityEngine;

public class TrainCarManager : MonoBehaviour
{
    public GameObject player1Cars;
    public GameObject player2Cars;
    public GameObject winScreen;

    public bool isPlayer1Active = true;

    public int player1LongestRouteLength = 0;
    public int player2LongestRouteLength = 0;

    public int player1CarCount = 0;
    public int player2CarCount = 0;

    public int numberOfTrainCars = 10;
    public Vector3 spawnPosition;
    public float maxDeviation = 0.5f;

    private GameObject trainCarsGroup; // Main group containing all train cars

    private void Start()
    {
        ActivatePlayerCars(player1Cars);
        DeactivatePlayerCars(player2Cars);
        winScreen.SetActive(false);

        trainCarsGroup = new GameObject("TrainCarsGroup"); // Create the main group

        // Instantiate and scatter the train cars
        for (int i = 0; i < numberOfTrainCars; i++)
        {
            Vector3 randomDeviation = new Vector3(Random.Range(-maxDeviation, maxDeviation), Random.Range(-maxDeviation, maxDeviation), 0f);
            Vector3 spawnPosition = this.spawnPosition + randomDeviation;

            GameObject trainCar = Instantiate(GetActivePlayerCars(), spawnPosition, Quaternion.identity);
            trainCar.transform.SetParent(trainCarsGroup.transform);
        }
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
            SubtractTrainCars(player1Cars, CalculateRequiredTrainCars(player1Cars));
        }
        else
        {
            SubtractTrainCars(player2Cars, CalculateRequiredTrainCars(player2Cars));
        }

        CheckWinCondition();
    }

    public void SubtractTrainCars(GameObject group, int requiredTrainCars)
    {
        if (group == player1Cars)
        {
            player1CarCount -= requiredTrainCars;
        }
        else if (group == player2Cars)
        {
            player2CarCount -= requiredTrainCars;
        }
        else if (group == trainCarsGroup)
        {
            int remainingTrainCars = GetRemainingTrainCars(group);
            if (remainingTrainCars >= requiredTrainCars)
            {
                for (int i = 0; i < requiredTrainCars; i++)
                {
                    GameObject trainCar = group.transform.GetChild(i).gameObject;
                    trainCar.SetActive(false);
                }
            }
        }
    }

    private void CheckWinCondition()
    {
        int player1Points = GetRemainingTrainCars(player1Cars);
        int player2Points = GetRemainingTrainCars(player2Cars);

        if (player1Points <= 2 || player2Points <= 2)
        {
            if (player1Points < player2Points)
            {
                ShowWinScreen(2); // Player 2 wins
            }
            else if (player1Points > player2Points)
            {
                ShowWinScreen(1); // Player 1 wins
            }
            else
            {
                // Points are equal, check for longest route
                int player1RouteLength = CalculateLongestRouteLength(player1Cars);
                int player2RouteLength = CalculateLongestRouteLength(player2Cars);

                if (player1RouteLength > player2RouteLength)
                {
                    ShowWinScreen(1); // Player 1 wins with longest route
                }
                else if (player2RouteLength > player1RouteLength)
                {
                    ShowWinScreen(2); // Player 2 wins with longest route
                }
                else
                {
                    ShowWinScreen(0); // It's a draw
                }
            }
        }
    }

    public int GetRemainingTrainCars(GameObject group)
    {
        int remainingTrainCars = 0;

        if (group == player1Cars)
        {
            remainingTrainCars = player1CarCount;
        }
        else if (group == player2Cars)
        {
            remainingTrainCars = player2CarCount;
        }
        else if (group == trainCarsGroup)
        {
            for (int i = 0; i < group.transform.childCount; i++)
            {
                if (group.transform.GetChild(i).gameObject.activeSelf)
                {
                    remainingTrainCars++;
                }
            }
        }

        return remainingTrainCars;
    }

    private int CalculateRequiredTrainCars(GameObject group)
    {
        int routeLength = GetRemainingTrainCars(group);

        if (routeLength <= 2)
        {
            return 1;
        }
        else if (routeLength <= 4)
        {
            return 2;
        }
        else if (routeLength <= 6)
        {
            return 3;
        }
        else if (routeLength <= 8)
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }

    public int CalculateLongestRouteLength(GameObject group)
    {
        int longestRouteLength = 0;
        int currentRouteLength = 0;

        for (int i = 0; i < group.transform.childCount; i++)
        {
            if (i == 0 || group.transform.GetChild(i).GetSiblingIndex() == group.transform.GetChild(i - 1).GetSiblingIndex() + 1)
            {
                currentRouteLength++;
            }
            else
            {
                if (currentRouteLength > longestRouteLength)
                {
                    longestRouteLength = currentRouteLength;
                }
                currentRouteLength = 1;
            }
        }

        if (currentRouteLength > longestRouteLength)
        {
            longestRouteLength = currentRouteLength;
        }

        return longestRouteLength;
    }

    private void ShowWinScreen(int winner)
    {
        winScreen.SetActive(true);

        if (winner == 0)
        {
            Debug.Log("It's a draw! Determining winner based on longest continuous route.");
        }
        else
        {
            Debug.Log("Player " + winner + " wins!");
        }
    }

    private void ActivatePlayerCars(GameObject group)
    {
        group.SetActive(true);
    }

    private void DeactivatePlayerCars(GameObject group)
    {
        group.SetActive(false);
    }

    private GameObject GetActivePlayerCars()
    {
        if (isPlayer1Active)
        {
            return player1Cars;
        }
        else
        {
            return player2Cars;
        }
    }
}
