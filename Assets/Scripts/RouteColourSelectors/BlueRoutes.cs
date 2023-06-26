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
    }
}
