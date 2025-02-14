using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Image healthText;
    public GameObject gameOverPanel; // Referencia al Panel de Game Over

    void Start()
    {
        currentHealth = maxHealth;
        //UpdateHealthUI();
        gameOverPanel.SetActive(false); // Asegura que el panel esté oculto al inicio
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            ShowGameOver();
        }
    }

    void UpdateHealthUI()
    {
        //healthText.text = "Salud: " + currentHealth;
    }

    void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Muestra el panel de Game Over
        Time.timeScale = 0; // Pausa el juego
    }
}

