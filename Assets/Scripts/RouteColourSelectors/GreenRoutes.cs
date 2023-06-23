using UnityEngine;

public class GreenRoutes : MonoBehaviour
{
    private int greenTrainCardCount = 0; // Number of green train cards

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

    public void SelectRoute()
    {
        // Subtract the number of green train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", greenTrainCardCount);
    }
}

