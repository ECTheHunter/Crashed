using UnityEngine;

public class MainMEnuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadScene(string scene)
    {
        if (scene != "")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
        else
        {
            Debug.LogError("Scene name is empty. Cannot load scene.");
        }
    }
}
