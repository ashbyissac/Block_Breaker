using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int finalSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (currentSceneIndex < finalSceneIndex)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
            GameObject.FindObjectOfType<GameSession>().ResetGame();
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
