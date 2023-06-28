using UnityEngine;

public class TrainCarManager : MonoBehaviour
{
    public GameObject player1Cars;
    public GameObject player2Cars;
    public GameObject winScreen;
    public InventorySystem inventorySystem; // Reference to the InventorySystem script

    public bool isPlayer1Active = true;

    public int player1LongestRouteLength = 0;
    public int player2LongestRouteLength = 0;

    public int player1CarCount = 0;
    public int player2CarCount = 0;

    private int keyPressCounter = 0;
    private bool isFirstKeyPress = true;
    private bool isWaitingForSecondKeyPress = false;
    private bool isFirstTurn = true;

    public void SetPlayerTurn(bool isPlayer1Active)
    {
        this.isPlayer1Active = isPlayer1Active;
    }

    public bool IsPlayer1Active()
    {
        return isPlayer1Active;
    }

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
            keyPressCounter++;

            if (isFirstTurn && keyPressCounter == 3)
            {
                isFirstTurn = false;
                keyPressCounter = 0;
                SwitchPlayerTurn();
            }
            else if (!isFirstTurn && keyPressCounter == 2)
            {
                keyPressCounter = 0;
                SwitchPlayerTurn();
            }
        }
    }

    public void SubtractTrainCars(GameObject group, int requiredTrainCars)
    {
        if (isPlayer1Active)
        {
            player1CarCount -= requiredTrainCars;
        }
        else
        {
            player2CarCount -= requiredTrainCars;
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
        return group.transform.childCount;
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

    private void SwitchPlayerTurn()
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