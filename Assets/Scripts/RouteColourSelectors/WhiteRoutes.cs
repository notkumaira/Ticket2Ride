using UnityEngine;

public class WhiteRoutes : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private int whiteTrainCardCount = 0; // Number of white train cards

    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Start()
    {
        // Count the number of white train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("WhiteTrainCard"))
            {
                whiteTrainCardCount++;
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
        // Subtract the number of white train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", whiteTrainCardCount);
    }
}
