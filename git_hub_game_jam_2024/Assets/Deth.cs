using UnityEngine;
using UnityEngine.SceneManagement;

public class Deth: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ResetScene();
        }
        
    }

    private void ResetScene()
    {
        // Get the name of the current scene
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }
}
