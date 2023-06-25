using UnityEngine;

public class OrangeRoutes : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private int orangeTrainCardCount = 0; // Number of orange train cards

    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Start()
    {
        // Count the number of orange train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("OrangeTrainCard"))
            {
                orangeTrainCardCount++;
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
        // Subtract the number of orange train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", orangeTrainCardCount);
    }
}
