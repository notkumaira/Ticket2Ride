using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UI : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject winScreen;
    public GameObject colorSelect;
    public GameObject Rules;
    public Text winText;

    public Text player1ColorText;
    public Text player2ColorText;

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

    public Button redButton;
    public Button yellowButton;
    public Button greenButton;
    public Button blueButton;
    private List<string> availableColors;
    private string player1Color;
    private string player2Color;

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

        // Initialize the list of available colors
        availableColors = new List<string> { "Red", "Yellow", "Green", "Blue" };

        // Add button click listeners for color selection
        redButton.onClick.AddListener(() => OnColorButtonClicked("Red"));
        yellowButton.onClick.AddListener(() => OnColorButtonClicked("Yellow"));
        greenButton.onClick.AddListener(() => OnColorButtonClicked("Green"));
        blueButton.onClick.AddListener(() => OnColorButtonClicked("Blue"));
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

    private void OnColorButtonClicked(string color)
    {
        if (player1Color == null)
        {
            player1Color = color;
            availableColors.Remove(color);
            player1ColorText.text = color;
            Debug.Log("Player 1 selected: " + player1Color);

            SetColorButtonColor(color, new Color32(0, 0, 0, 200));
        }
        else if (player2Color == null)
        {
            player2Color = color;
            availableColors.Remove(color);
            player2ColorText.text = color;
            Debug.Log("Player 2 selected: " + player2Color);

            colorSelect.SetActive(false);
        }
    }

    private void SetColorButtonColor(string color, Color32 buttonColor)
    {
        switch (color)
        {
            case "Red":
                redButton.image.color = buttonColor;
                break;
            case "Yellow":
                yellowButton.image.color = buttonColor;
                break;
            case "Green":
                greenButton.image.color = buttonColor;
                break;
            case "Blue":
                blueButton.image.color = buttonColor;
                break;
        }
    }

    private void DisableColorSelectionPanel()
    {
        redButton.interactable = false;
        yellowButton.interactable = false;
        greenButton.interactable = false;
        blueButton.interactable = false;
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

