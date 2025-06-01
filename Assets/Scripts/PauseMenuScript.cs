using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuIU;
<<<<<<< HEAD
<<<<<<< HEAD
    public bool IsPaused
    {
        get;set;
    }
=======

    [SerializeField] private GameOverUI gameOver;
>>>>>>> testMurat
=======
>>>>>>> parent of d4a8da0 (.)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        IsPaused = true;
        pauseMenuIU.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }
    public void Resume()
    {
        IsPaused = false;
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
