using UnityEngine;

public class YellowRoutes : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private int yellowTrainCardCount = 0; // Number of yellow train cards

    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Start()
    {
        // Count the number of yellow train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("YellowTrainCard"))
            {
                yellowTrainCardCount++;
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
        // Subtract the number of yellow train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", yellowTrainCardCount);
    }
}
