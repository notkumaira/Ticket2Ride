using UnityEngine;

public class OrangeRoutes : MonoBehaviour
{
    private int orangeTrainCardCount = 0; // Number of orange train cards

    private void Start()
    {
        // Count the number of orange train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("OrangeTrainCard"))
            {
                orangeTrainCardCount++;
            }
        }
    }

    public void SelectRoute()
    {
        // Subtract the number of orange train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", orangeTrainCardCount);
    }
}
