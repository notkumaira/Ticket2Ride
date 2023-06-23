using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    private void Update()
    {
        // Check for the pause input, e.g., the Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
        isPaused = true;
        // Show pause menu or perform any other necessary actions
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting the time scale back to 1
        isPaused = false;
        // Hide pause menu or perform any other necessary actions
    }
}
