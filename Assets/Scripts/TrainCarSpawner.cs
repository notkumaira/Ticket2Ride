using UnityEngine;
using UnityEngine.UI;

public class TrainCarSpawner : MonoBehaviour
{
    public GameObject blueTrainCarPrefab;
    public GameObject redTrainCarPrefab;
    public GameObject greenTrainCarPrefab;
    public GameObject yellowTrainCarPrefab;
    public GameObject trainCarSpawnPoint;
    public int numberOfCars = 45;
    public Text player1ColorText;
    public Text player2ColorText;

    private string player1ChosenColor;
    private bool hasPlayer1ChosenColor = false;

    private string player2ChosenColor;
    private bool hasPlayer2ChosenColor = false;

    private GameObject chosenTrainCarPrefab;

    public void SetPlayer1ChosenColor(string color)
    {
        player1ChosenColor = color;
        hasPlayer1ChosenColor = true;
        SetChosenTrainCarPrefab(color);
    }

    public void SetPlayer2ChosenColor(string color)
    {
        player2ChosenColor = color;
        hasPlayer2ChosenColor = true;
        SetChosenTrainCarPrefab(color);
    }

    private void Start()
    {
        trainCarSpawnPoint = GameObject.Find("TrainCarSpawnPoint");
    }

    private void Update()
    {
        if (hasPlayer1ChosenColor)
        {
            SpawnTrainCars(player1ChosenColor);
            hasPlayer1ChosenColor = false;
        }

        if (hasPlayer2ChosenColor)
        {
            SpawnTrainCars(player2ChosenColor);
            hasPlayer2ChosenColor = false;
        }
    }

    private void SpawnTrainCars(string chosenColor)
    {
        // Spawn new train cars
        for (int i = 0; i < numberOfCars; i++)
        {
            GameObject trainCar = Instantiate(chosenTrainCarPrefab, trainCarSpawnPoint.transform.position + new Vector3(i * 1.5f, 0f, 0f), Quaternion.identity);
            trainCar.GetComponent<SpriteRenderer>().color = GetColorFromName(chosenColor);
            trainCar.tag = "TrainCar";
        }
    }

    private Color GetColorFromName(string colorName)
    {
        Color color = Color.white;

        switch (colorName)
        {
            case "Red":
                color = Color.red;
                break;
            case "Yellow":
                color = Color.yellow;
                break;
            case "Green":
                color = Color.green;
                break;
            case "Blue":
                color = Color.blue;
                break;
        }

        return color;
    }

    private void SetChosenTrainCarPrefab(string color)
    {
        switch (color)
        {
            case "Red":
                chosenTrainCarPrefab = redTrainCarPrefab;
                break;
            case "Yellow":
                chosenTrainCarPrefab = yellowTrainCarPrefab;
                break;
            case "Green":
                chosenTrainCarPrefab = greenTrainCarPrefab;
                break;
            case "Blue":
                chosenTrainCarPrefab = blueTrainCarPrefab;
                break;
        }
    }
}
