using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private GameObject currentPlayer; // Reference to the current player object

    // Function to assign the player to the manager
    public void AssignPlayer(GameObject player)
    {
        currentPlayer = player;

        // Start the game after assigning the player
        StartGame();
    }

    // Function to start the game
    public void StartGame()
    {
        // Call the appropriate function to switch scenes based on the player index
        if (currentPlayer.name == "Player1")
        {
            SwitchSceneForPlayer1();
        }
        else if (currentPlayer.name == "Player2")
        {
            SwitchSceneForPlayer2();
        }
    }

    // Example function to switch active scene for player 1
    private void SwitchSceneForPlayer1()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("PlayerScene0"));
    }

    // Example function to switch active scene for player 2
    private void SwitchSceneForPlayer2()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("PlayerScene1"));
    }

    private void Update()
    {
        // Check for the "T" key press to switch scenes
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchPlayerScenes();
        }
    }

    // Function to switch the active scene for the current player
    private void SwitchPlayerScenes()
    {
        if (currentPlayer != null)
        {
            if (currentPlayer.name == "Player1")
            {
                SwitchSceneForPlayer2();
            }
            else if (currentPlayer.name == "Player2")
            {
                SwitchSceneForPlayer1();
            }
        }
    }
}
