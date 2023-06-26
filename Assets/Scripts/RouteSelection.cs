using UnityEngine;

public class RouteSelection : MonoBehaviour
{
    public bool isPlayer1Active = true;
    public GameObject player1Cars;
    public GameObject player2Cars;
    public TrainCarManager trainCarManager;

    public void RouteClaimed()
    {
        if (isPlayer1Active)
        {
            trainCarManager.SubtractTrainCars(player1Cars, CalculateRequiredTrainCars(player1Cars));
        }
        else
        {
            trainCarManager.SubtractTrainCars(player2Cars, CalculateRequiredTrainCars(player2Cars));
        }

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        int player1Points = trainCarManager.GetRemainingTrainCars(player1Cars);
        int player2Points = trainCarManager.GetRemainingTrainCars(player2Cars);

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
                int player1RouteLength = GetLongestRouteLength(player1Cars);
                int player2RouteLength = GetLongestRouteLength(player2Cars);

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

    private int CalculateRequiredTrainCars(GameObject playerCars)
    {
        int routeLength = playerCars.transform.childCount;

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

    private int GetLongestRouteLength(GameObject playerCars)
    {
        int longestRouteLength = 0;
        int currentRouteLength = 0;

        for (int i = 0; i < playerCars.transform.childCount; i++)
        {
            if (i == 0 || playerCars.transform.GetChild(i).GetSiblingIndex() == playerCars.transform.GetChild(i - 1).GetSiblingIndex() + 1)
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
        // Display the win screen based on the winner value
        if (winner == 0)
        {
            Debug.Log("It's a draw! Determining winner based on longest continuous route.");
        }
        else
        {
            Debug.Log("Player " + winner + " wins!");
        }
    }
}
