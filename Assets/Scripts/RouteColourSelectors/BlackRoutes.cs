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

        // Example usage
        if (inventorySystem != null)
        {
            inventorySystem.SubtractAllocatedTrainCars("Player2", 4);
        }
        else
        {
            Debug.LogWarning("InventorySystem not found in the scene.");
        }
    }

    public void SelectRoute()
    {
        // Subtract the number of black train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", blackTrainCardCount);
    }
}
