using UnityEngine;

public class BlueRoutes : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private int blueTrainCardCount = 0; // Number of blue train cards

    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Start()
    {
        // Count the number of blue train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("BlueTrainCard"))
            {
                blueTrainCardCount++;
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
        // Subtract the number of blue train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", blueTrainCardCount);
    }
}
