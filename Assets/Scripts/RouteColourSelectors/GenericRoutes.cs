using UnityEngine;

public class GenericRoutes : MonoBehaviour
{
    public string trainCardColor; // Color of the train cards associated with this route

    private int trainCardCount = 0; // Number of train cards of the specified color

    private void Start()
    {
      
    }

    public void SelectRoute()
    {
        // Subtract the number of train cards of the specified color from the player's inventory
        InventorySystem.instance.SubtractAllocatedTrainCars("Player1", trainCardCount);
    }
}
