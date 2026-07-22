using UnityEngine;
using UnityEngine.SceneManagement; // Needed for reloading scene
using UnityEngine.UI; // Needed if you want to access Button programmatically

public class WinScreenController : MonoBehaviour
{
    public GameObject youWinUI;  // Assign the whole win UI panel
    public Button replayButton;  // Assign the Replay button in inspector

    private void Start()
    {
        // Ensure win UI is off at start
        if (youWinUI != null)
            youWinUI.SetActive(false);

        // Hook up replay button click
        if (replayButton != null)
            replayButton.onClick.AddListener(OnReplayButtonClicked);
    }

    public void ShowWinScreen()
    {
        if (youWinUI != null)
            youWinUI.SetActive(true);

        // Stop game time to "end" the game
        Time.timeScale = 0f;
    }

    private void OnReplayButtonClicked()
    {
        // Resume time before reload
        Time.timeScale = 1f;

        // Reload the current active scene to restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}