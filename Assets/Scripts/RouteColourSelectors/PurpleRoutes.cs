using UnityEngine;

public class PurpleRoutes : MonoBehaviour
{
    private InventorySystem inventorySystem; // Reference to the InventorySystem component

    private void Start()
    {
        // Get the InventorySystem component from the scene
        inventorySystem = FindObjectOfType<InventorySystem>();

        if (inventorySystem == null)
        {
            Debug.LogWarning("InventorySystem component not found in the scene.");
        }
    }

    private void SomeMethod()
    {
        if (inventorySystem != null)
        {
            // Call the SubtractAllocatedTrainCars method from the InventorySystem component
            inventorySystem.SubtractAllocatedTrainCars("Player1", 2);
        }
    }
}
