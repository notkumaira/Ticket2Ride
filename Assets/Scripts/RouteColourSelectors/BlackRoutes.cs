using UnityEngine;

public class BlackRoutes : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private int blackTrainCardCount = 0; // Number of black train cards

    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Start()
    {
        // Count the number of black train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("BlackTrainCard"))
            {
                blackTrainCardCount++;
            }
        }
    }
}
