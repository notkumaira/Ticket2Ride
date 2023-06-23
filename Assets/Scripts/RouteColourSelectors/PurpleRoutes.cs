using UnityEngine;

public class PurpleRoutes : MonoBehaviour
{
    private int purpleTrainCardCount = 0; // Number of purple train cards

    private void Start()
    {
        // Count the number of purple train cards as children of this game object
        foreach (Transform child in transform)
        {
            if (child.CompareTag("PurpleTrainCard"))
            {
                purpleTrainCardCount++;
            }
        }
    }

    public void SelectRoute()
    {
        // Subtract the number of purple train cards from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", purpleTrainCardCount);
    }
}
