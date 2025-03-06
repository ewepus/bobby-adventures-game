using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogicScript : MonoBehaviour
{
    public GameObject scoreResetNotificationText;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ResetProgress()
    {
        PlayerPrefs.SetInt("highestScore", 0);
        scoreResetNotificationText.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
