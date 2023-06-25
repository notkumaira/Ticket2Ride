using UnityEngine;

public class GreenRoutes : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private int greenTrainCardCount = 0; // Number of green train cards

    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Start()
    {
        // Count the number of green train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("GreenTrainCard"))
            {
                greenTrainCardCount++;
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
        // Subtract the number of green train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", greenTrainCardCount);
    }
}
