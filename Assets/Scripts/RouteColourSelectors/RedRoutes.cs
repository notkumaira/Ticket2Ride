using UnityEngine;

public class RedRoutes : MonoBehaviour
{
    private int redTrainCardCount = 0; // Number of red train cards

    private void Start()
    {
        // Count the number of red train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("RedTrainCard"))
            {
                redTrainCardCount++;
            }
        }
    }

    public void SelectRoute()
    {
        // Subtract the number of red train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", redTrainCardCount);
    }
}
