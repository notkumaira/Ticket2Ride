using UnityEngine;

public class BlackRoutes : MonoBehaviour
{
    private int blackTrainCardCount = 0; // Number of black train cards

    private void Start()
    {
        // Count the number of black train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("BlackTrainCard"))
            {
                blackTrainCardCount++;
            }
        }
    }

    public void SelectRoute()
    {
        // Subtract the number of black train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", blackTrainCardCount);
    }
}
