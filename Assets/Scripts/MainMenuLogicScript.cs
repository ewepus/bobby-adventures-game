using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogicScript : MonoBehaviour
{
    public GameObject scoreResetNotificationText;
    public AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    public void StartGame()
    {
        audioManager.menuSong.Stop();
        audioManager.buttonSound1.Play();
        SceneManager.LoadScene(2);
    }
    public void ResetProgress()
    {
        audioManager.buttonSound2.Play();
        PlayerPrefs.SetInt("highestScore", 0);
        PlayerPrefs.Save();
        scoreResetNotificationText.SetActive(true);
    }
}
