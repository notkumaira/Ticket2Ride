using UnityEngine;

public class RedRoutes : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private int redTrainCardCount = 0; // Number of red train cards

    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Start()
    {
        // Count the number of red train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("RedTrainCard"))
            {
                redTrainCardCount++;
            }
        }

    }
}
