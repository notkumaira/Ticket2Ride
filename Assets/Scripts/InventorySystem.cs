using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance; // Singleton instance

    public List<string> player1TrainCards;
    public List<string> player2TrainCards;
    public List<string> player1DestinationTickets;
    public List<string> player2DestinationTickets;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Clear inventories when a new scene is loaded
        player1TrainCards.Clear();
        player2TrainCards.Clear();
        player1DestinationTickets.Clear();
        player2DestinationTickets.Clear();

        // Update inventories based on the active scene
        switch (scene.buildIndex)
        {
            case 0: // Scene 0
                player1TrainCards.Add("TrainCardA");
                player1TrainCards.Add("TrainCardB");
                player1DestinationTickets.Add("TicketA");
                player1DestinationTickets.Add("TicketB");
                break;
            case 1: // Scene 1
                player2TrainCards.Add("TrainCardC");
                player2TrainCards.Add("TrainCardD");
                player2DestinationTickets.Add("TicketC");
                player2DestinationTickets.Add("TicketD");
                break;
                // Add more cases for additional scenes if needed
        }
    }

    public void SubtractAllocatedTrainCars(string playerName, int trainCarCount)
    {
        List<string> trainCards = GetPlayerTrainCards(playerName);
        if (trainCards.Count >= trainCarCount)
        {
            trainCards.RemoveRange(0, trainCarCount);
        }
        else
        {
            Debug.LogWarning("Player doesn't have enough train cars.");
        }
    }

    private List<string> GetPlayerTrainCards(string playerName)
    {
        if (playerName == "Player1")
        {
            return player1TrainCards;
        }
        else if (playerName == "Player2")
        {
            return player2TrainCards;
        }

        Debug.LogWarning("Invalid player name.");
        return null;
    }
}