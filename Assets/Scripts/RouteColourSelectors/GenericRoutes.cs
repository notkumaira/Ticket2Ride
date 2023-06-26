using UnityEngine;

public class GenericRoutes : MonoBehaviour
{
    public string trainCardColorTag; // Tag of the train card color to count
    private InventorySystem inventorySystem;
    private int trainCardCount = 0; // Number of train cards of the specified color

    private void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Start()
    {
        // Count the number of train cards of the specified color as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag(trainCardColorTag))
            {
                trainCardCount++;
            }
        }

    }
}
