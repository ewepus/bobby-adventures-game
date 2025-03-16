using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public Text highestScoreText;
    public GameObject gameOverScreen;
    public int highestScore;
    [SerializeField] private Animator animator;
    public AudioManager audioManager;
    public PlayerScript playerScript;
    public bool isNewHighScore = false;
    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        highestScore = PlayerPrefs.GetInt("highestScore", 0);
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }

    [ContextMenu("Increase score")]
    public void AddScore(int scoreToAdd)
    {
        if (playerScript.bobbyIsAlive)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }
    public void RestartGame()
    {
        audioManager.buttonSound2.Play();
        SceneManager.LoadScene(2);
    }
    public void GameOver()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isDead", true);

        gameOverScreen.SetActive(true);

        highestScore = PlayerPrefs.GetInt("highestScore", 0);

        if (playerScore > highestScore)
        {
            audioManager.highestScoreSound.Play();
            isNewHighScore = true;
            highestScore = playerScore;
            PlayerPrefs.SetInt("highestScore", playerScore);
            PlayerPrefs.Save();
            highestScoreText.text = "Highest Score: " + highestScore.ToString();
        }
    }
    public void ReturnToMainMenu()
    {
        audioManager.buttonSound2.Play();
        audioManager.menuSong.Play();
        SceneManager.LoadScene(1);
    }
}
