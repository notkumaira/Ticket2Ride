using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCarManager : MonoBehaviour
{
    public GameObject trainCarPrefab;
    public GameObject player1TrainCarGroup;
    public GameObject player2TrainCarGroup;

    private bool isPlayer1Active = true;

    private void Start()
    {
        InstantiateTrainCars(player1TrainCarGroup);
        InstantiateTrainCars(player2TrainCarGroup);
        ActivateTrainCars(player1TrainCarGroup);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isPlayer1Active)
            {
                DeactivateTrainCars(player1TrainCarGroup);
                ActivateTrainCars(player2TrainCarGroup);
            }
            else
            {
                DeactivateTrainCars(player2TrainCarGroup);
                ActivateTrainCars(player1TrainCarGroup);
            }

            isPlayer1Active = !isPlayer1Active;
        }
    }

    private void InstantiateTrainCars(GameObject trainCarGroup)
    {
        for (int i = 0; i < 45; i++)
        {
            GameObject trainCar = Instantiate(trainCarPrefab, Vector3.zero, Quaternion.identity);
            trainCar.transform.SetParent(trainCarGroup.transform);
            trainCar.transform.localPosition = Vector3.zero;
            trainCar.transform.localRotation = Quaternion.identity;
        }
    }

    private void ActivateTrainCars(GameObject trainCarGroup)
    {
        trainCarGroup.SetActive(true);
    }

    private void DeactivateTrainCars(GameObject trainCarGroup)
    {
        trainCarGroup.SetActive(false);
    }
}
