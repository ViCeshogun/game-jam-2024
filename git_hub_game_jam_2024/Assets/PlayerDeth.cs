using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
    // Destroy the object and reset the scene
    private void OnDestroy()
    {
        ResetScene();
    }

    // Function to reset the scene
    private void ResetScene()
    {
        // Get the name of the current scene
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }
}
