using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public GameObject GameOver;
    public bool isDead { get; private set; }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player.GetComponent<CharacterModel>().Health < 0.1f || player.GetComponent<CharacterModel>().Oksijen < 0.1f || player.GetComponent<CharacterModel>().Susuzluk < 0.1f || player.GetComponent<CharacterModel>().Aclik < 0.1f)
        {
            isDead = true;
            Debug.Log("�lecek");
            gameOver();
            Debug.Log("�ld�");
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
        SceneManager.LoadScene("Space_Forest");
        Time.timeScale = 1f;

    }


}
