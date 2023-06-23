using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab; // Prefab for the player object
    public Camera playerCameraPrefab; // Prefab for the player camera

    private GameObject player1; // Reference to player 1 object
    private GameObject player2; // Reference to player 2 object

    private PlayerManager playerManager; // Reference to the PlayerManager script

    private void Start()
    {
        // Instantiate the PlayerManager object
        GameObject playerManagerObj = new GameObject("PlayerManager");
        playerManager = playerManagerObj.AddComponent<PlayerManager>();

        // Create player 1 and assign player scene 0
        CreatePlayer(0, "PlayerScene0", playerManagerObj);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("PlayerScene0"));

        // Create player 2 and assign player scene 1
        CreatePlayer(1, "PlayerScene1", playerManagerObj);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("PlayerScene1"));

        // Start the game
        playerManager.StartGame();
    }

    private void CreatePlayer(int playerIndex, string sceneName, GameObject playerManagerObj)
    {
        // Create a new scene for the player
        Scene playerScene = SceneManager.CreateScene(sceneName);

        // Instantiate the player object into the scene
        GameObject player = Instantiate(playerPrefab);
        SceneManager.MoveGameObjectToScene(player, playerScene);

        // Instantiate the player camera prefab into the scene
        Camera playerCamera = Instantiate(playerCameraPrefab);
        SceneManager.MoveGameObjectToScene(playerCamera.gameObject, playerScene);

        // Set the player's viewport rect for split-screen
        playerCamera.rect = playerIndex == 0 ? new Rect(0f, 0f, 0.5f, 1f) : new Rect(0.5f, 0f, 0.5f, 1f);

        // Set player references
        if (playerIndex == 0)
        {
            player1 = player;
        }
        else if (playerIndex == 1)
        {
            player2 = player;
        }

        // Assign the player to the PlayerManager
        playerManager.AssignPlayer(player);
    }
}
