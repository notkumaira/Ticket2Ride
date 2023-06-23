using UnityEngine;

public class BlueRoutes : MonoBehaviour
{
    private int blueTrainCardCount = 0; // Number of blue train cards

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

    public void SelectRoute()
    {
        // Subtract the number of blue train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", blueTrainCardCount);
    }
}
