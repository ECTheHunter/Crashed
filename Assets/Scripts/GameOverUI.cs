using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public GameObject GameOver;
    public bool isDead {  get; private set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDead = true;
            Debug.Log("ölecek");
            gameOver();
            Debug.Log("öldü");
        }
    }
    public void gameOver()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }


    public void QuitButton()
    {
        
         Application.Quit();
       
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Test");
        Time.timeScale = 1f;

    }


}
