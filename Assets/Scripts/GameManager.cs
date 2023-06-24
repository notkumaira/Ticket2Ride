using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public Player player1;
    public Player player2;

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
        // Update inventories based on the active scene
        switch (scene.buildIndex)
        {
            case 0: // Scene 0
                player1.SetDestinationTickets(new List<string> { "TicketA", "TicketB" });
                player1.GetTrainCards().Clear();
                player1.GetTrainCards().Add("TrainCardA");
                player1.GetTrainCards().Add("TrainCardB");

                player2.SetDestinationTickets(new List<string>());
                player2.GetTrainCards().Clear();
                player2.GetTrainCards().Add("TrainCardC");
                player2.GetTrainCards().Add("TrainCardD");
                break;
            case 1: // Scene 1
                player1.SetDestinationTickets(new List<string>());
                player1.GetTrainCards().Clear();
                player1.GetTrainCards().Add("TrainCardE");
                player1.GetTrainCards().Add("TrainCardF");

                player2.SetDestinationTickets(new List<string> { "TicketC" });
                player2.GetTrainCards().Clear();
                player2.GetTrainCards().Add("TrainCardG");
                player2.GetTrainCards().Add("TrainCardH");
                break;
                // Add more cases for additional scenes if needed
        }
    }
}
