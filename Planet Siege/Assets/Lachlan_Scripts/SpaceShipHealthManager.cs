using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the health of the SpaceShip, updates UI, handles damage, and game over logic.
/// Attach this to the SpaceShip GameObject.
/// </summary>
public class SpaceShipHealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button restartButton;

    [Header("Damage Feedback")]
    [SerializeField] private ParticleSystem damageFeedbackEffect;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            restartButton.onClick.AddListener(RestartGame);
        }

        if (damageFeedbackEffect != null && !damageFeedbackEffect.isPlaying)
            damageFeedbackEffect.Play();

        Debug.Log($"{gameObject.name} initialized with {currentHealth} health.");
    }

    /// <summary>
    /// Reduces health when called, updates UI, and checks for game over.
    /// </summary>
    public void TakeDamage(int amount)
    {
        Debug.Log($"{gameObject.name} took {amount} damage.");

        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Increases health (used for health pickup).
    /// </summary>
    public void Heal(int amount)
    {
        Debug.Log($"{gameObject.name} healed by {amount}.");

        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        UpdateHealthUI();
    }

    /// <summary>
    /// Updates the UI text and damage feedback effect based on current health.
    /// </summary>
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"SpaceShip Health: {currentHealth}/{maxHealth}";
        }

        UpdateDamageEffect();

        Debug.Log($"{gameObject.name} health updated: {currentHealth}/{maxHealth}");
    }

    /// <summary>
    /// Updates the particle system to reflect SpaceShip’s current health.
    /// </summary>
    private void UpdateDamageEffect()
    {
        if (damageFeedbackEffect != null)
        {
            float healthPercent = (float)currentHealth / maxHealth;
            float damageIntensity = 1f - healthPercent;

            var emission = damageFeedbackEffect.emission;
            emission.rateOverTime = Mathf.Lerp(0f, 100f, damageIntensity); // Adjust max value to your liking

            var main = damageFeedbackEffect.main;
            main.startSize = Mathf.Lerp(0.1f, 1f, damageIntensity);
            main.startColor = Color.Lerp(Color.yellow, Color.red, damageIntensity);
        }
    }

    /// <summary>
    /// Called when SpaceShip reaches 0 health.
    /// </summary>
    private void GameOver()
    {
        Debug.Log($"Game Over: {gameObject.name} has been destroyed!");

        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        if (restartButton != null)
            restartButton.gameObject.SetActive(true);

        Time.timeScale = 0f; // Pause the game
    }

    /// <summary>
    /// Restarts the current scene.
    /// </summary>
    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Returns current health (optional external use).
    /// </summary>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}