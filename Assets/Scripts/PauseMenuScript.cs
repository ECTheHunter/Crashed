using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuIU;

    [SerializeField] private GameOverUI gameOver;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver.isDead)
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenuIU.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }
    public void Resume()
    {
        pauseMenuIU.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f; // Reset time scale before quitting
    }


}
