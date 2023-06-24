using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerScript : MonoBehaviour
{
    public Camera mainCamera;

    private string scene0 = "Scene0";
    private string scene1 = "Scene1";
    private int currentPlayer = 1;

    private RenderTexture renderTexture;

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
            LoadScene(scene1);
            currentPlayer = 2;
        }
        else
        {
            LoadScene(scene0);
            currentPlayer = 1;
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