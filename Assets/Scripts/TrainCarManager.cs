using UnityEngine;

public class TrainCarManager : MonoBehaviour
{
    public Transform trainCarParent;
    public GameObject[] trainCarPrefabs;

    private GameObject currentTrainCar;
    private int currentIndex = 0;

    private void Start()
    {
        InstantiateTrainCar();
    }

    private void InstantiateTrainCar()
    {
        if (currentIndex >= trainCarPrefabs.Length)
        {
            Debug.Log("All train cars have been used.");
            return;
        }

        if (currentTrainCar != null)
        {
            currentTrainCar.SetActive(false);
        }

        currentTrainCar = Instantiate(trainCarPrefabs[currentIndex], trainCarParent);
        currentTrainCar.transform.localPosition = Vector3.zero;
        currentTrainCar.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            currentTrainCar.SetActive(false);
            currentIndex = (currentIndex + 1) % trainCarPrefabs.Length;
            InstantiateTrainCar();
        }
    }
}
