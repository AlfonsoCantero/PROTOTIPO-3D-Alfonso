using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver() //Metodo que sirve para mostrar el panel de game over
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()  //Metodo que activa al pulsar el boton
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

