using UnityEngine;

public class SecondPlayerCars : MonoBehaviour
{
    public GameObject blueTrainCarPrefab;
    public GameObject redTrainCarPrefab;
    public GameObject greenTrainCarPrefab;
    public GameObject yellowTrainCarPrefab;

    public Transform trainCarParent;

    private int blueTrainCarsCount = 45;
    private int redTrainCarsCount = 45;
    private int greenTrainCarsCount = 45;
    private int yellowTrainCarsCount = 45;

    private bool isTrainCarsVisible = false;

    private void Start()
    {
        InitializeTrainCars();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleTrainCarsVisibility();
        }
    }

    private void InitializeTrainCars()
    {
        for (int i = 0; i < blueTrainCarsCount; i++)
        {
            InstantiateTrainCar(blueTrainCarPrefab);
        }

        for (int i = 0; i < redTrainCarsCount; i++)
        {
            InstantiateTrainCar(redTrainCarPrefab);
        }

        for (int i = 0; i < greenTrainCarsCount; i++)
        {
            InstantiateTrainCar(greenTrainCarPrefab);
        }

        for (int i = 0; i < yellowTrainCarsCount; i++)
        {
            InstantiateTrainCar(yellowTrainCarPrefab);
        }

        SetTrainCarsVisibility(false);
    }

    private void InstantiateTrainCar(GameObject trainCarPrefab)
    {
        Vector3 spawnPosition = new Vector3(0.01187754f, -3.41642f, 0f);
        GameObject trainCar = Instantiate(trainCarPrefab, spawnPosition, Quaternion.identity, trainCarParent);
    }

    public void ClaimTrainCars(string trainCarColor, int count)
    {
        switch (trainCarColor)
        {
            case "Blue":
                blueTrainCarsCount -= count;
                break;
            case "Red":
                redTrainCarsCount -= count;
                break;
            case "Green":
                greenTrainCarsCount -= count;
                break;
            case "Yellow":
                yellowTrainCarsCount -= count;
                break;
        }

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (blueTrainCarsCount <= 2 || redTrainCarsCount <= 2 || greenTrainCarsCount <= 2 || yellowTrainCarsCount <= 2)
        {
            // Display the win screen
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        // Implement your logic to display the win screen here
    }

    private void ToggleTrainCarsVisibility()
    {
        isTrainCarsVisible = !isTrainCarsVisible;
        SetTrainCarsVisibility(isTrainCarsVisible);
    }

    private void SetTrainCarsVisibility(bool isVisible)
    {
        foreach (Transform trainCar in trainCarParent)
        {
            trainCar.gameObject.SetActive(isVisible);
        }
    }
}
