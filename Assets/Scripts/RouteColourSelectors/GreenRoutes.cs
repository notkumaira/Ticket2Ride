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

    }
}
