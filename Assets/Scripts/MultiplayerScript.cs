using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerScript : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject inventory1Prefab; // Prefab of the inventory UI for Player1
    public GameObject inventory2Prefab; // Prefab of the inventory UI for Player2

    private string scene0 = "Scene0";
    private string scene1 = "Scene1";
    private int currentPlayer = 1;

    private RenderTexture renderTexture;
    private GameObject inventory1; // Reference to the instantiated inventory UI for Player1
    private GameObject inventory2; // Reference to the instantiated inventory UI for Player2

    private void Start()
    {
        // Load both scenes
        LoadScene(scene0);
        LoadScene(scene1);

        // Set Scene0 as the active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene0));

        // Instantiate the inventory UI for Player1
        inventory1 = Instantiate(inventory1Prefab);
        inventory1.SetActive(true);

        // Instantiate the inventory UI for Player2
        inventory2 = Instantiate(inventory2Prefab);
        inventory2.SetActive(false);
    }

    private void Update()
    {
        // Switch between scenes using the "T" key
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchScene();
        }
    }

    private void SwitchScene()
    {
        if (currentPlayer == 1)
        {
            // Disable the inventory UI for Player1
            inventory1.SetActive(false);
            LoadScene(scene1);
            currentPlayer = 2;

            // Enable the inventory UI for Player2
            inventory2.SetActive(true);
        }
        else
        {
            // Disable the inventory UI for Player2
            inventory2.SetActive(false);
            LoadScene(scene0);
            currentPlayer = 1;

            // Enable the inventory UI for Player1
            inventory1.SetActive(true);
        }
    }

    private void LoadScene(string sceneName)
    {
        Scene desiredScene = SceneManager.GetSceneByName(sceneName);

        if (!desiredScene.isLoaded)
        {
            // Scene doesn't exist, load it
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else if (desiredScene != SceneManager.GetActiveScene())
        {
            // Scene exists, make it active
            SceneManager.SetActiveScene(desiredScene);
        }
    }

    private void LateUpdate()
    {
        if (currentPlayer == 1)
        {
            mainCamera.targetTexture = null;
        }
        else
        {
            if (renderTexture == null)
            {
                renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
            }
            mainCamera.targetTexture = renderTexture;
            Graphics.Blit(renderTexture, null as RenderTexture); // Display the camera view on the screen
        }
    }
}
