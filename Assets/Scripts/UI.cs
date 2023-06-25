using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UI : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject winScreen;
    public GameObject Rules;
    public Text winText;

    public Button startButton;
    public Button exitButton;
    public Button quitButton;
    public Button resumeButton;
    public Button winExitButton;
    public Button NextButton;

    private bool isGamePaused = false;
    private bool isGameStarted = false;
    private bool isGameWon = false;
    private string winningPlayer;

    private bool isSpaceBarPressed = false; // New variable to track space bar input

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
        quitButton.onClick.AddListener(QuitGame);
        resumeButton.onClick.AddListener(ResumeGame);
        winExitButton.onClick.AddListener(ExitGame);
        NextButton.onClick.AddListener(HideRules);

        HidePauseMenu();
        HideWinScreen();

        ShowStartMenu();
    }

    private void StartGame()
    {
        isGameStarted = true;
        HideStartMenu();
        // Start the game logic
    }

    private void ExitGame()
    {
        // Clean up and exit the application
        Application.Quit();
    }

    private void QuitGame()
    {
        PauseGame();
        ShowPauseMenu();
    }

    private void ResumeGame()
    {
        HidePauseMenu();
        ResumeGameLogic();
    }

    private void PauseGame()
    {
        isGamePaused = true;
        // Pause the game logic
    }

    private void ResumeGameLogic()
    {
        isGamePaused = false;
        // Resume the game logic
    }

    private void ShowStartMenu()
    {
        startMenu.SetActive(true);
    }

    private void HideStartMenu()
    {
        startMenu.SetActive(false);
    }

    private void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    private void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
        Text winText = winScreen.GetComponentInChildren<Text>();
        winText.text = winningPlayer + " Wins";
    }

    private void HideWinScreen()
    {
        winScreen.SetActive(false);
    }

    private void HideRules()
    {
        Rules.SetActive(false);
    }

    private void Update()
    {
        if (isGameStarted && !isGamePaused)
        {
            // Update game logic
            if (isGameWon)
            {
                PauseGame();
                ShowWinScreen();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpaceBarPressed = true;
        }

        if (isSpaceBarPressed)
        {
            PauseGame();
            ShowPauseMenu();
            isSpaceBarPressed = false;
        }
    }
}
