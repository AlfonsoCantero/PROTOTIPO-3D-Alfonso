using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameOver;
    [SerializeField]
    private EnemyController enemyManager;

    public void GameOver()   //Metodo del game over
    {
        panelGameOver.SetActive(true);
        enemyManager.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
        public void LoadSceneLevel()  //metodo para volver a cargar la escena
         {
            SceneManager.LoadScene("Level01");
         }
        




    }



