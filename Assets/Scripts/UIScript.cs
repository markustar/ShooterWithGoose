using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    private void Start() {
        Time.timeScale = 1f;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop playing the game in the Unity Editor
        #else
            Application.Quit(); // Quit the application in a built executable
        #endif
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LowPolyFPS_Lite_Demo");
    }
}
