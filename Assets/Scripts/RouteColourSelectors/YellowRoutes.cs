using UnityEngine;

public class YellowRoutes : MonoBehaviour
{
    private int yellowTrainCardCount = 0; // Number of yellow train cards

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
    }

    public void SelectRoute()
    {
        // Subtract the number of yellow train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", yellowTrainCardCount);
    }
}
