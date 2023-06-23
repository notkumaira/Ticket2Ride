using UnityEngine;

public class WhiteRoutes : MonoBehaviour
{
    private int whiteTrainCardCount = 0; // Number of white train cards

    private void Start()
    {
        // Count the number of white train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("WhiteTrainCard"))
            {
                whiteTrainCardCount++;
            }
        }
    }

    public void SelectRoute()
    {
        // Subtract the number of white train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", whiteTrainCardCount);
    }
}
