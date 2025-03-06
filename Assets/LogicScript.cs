using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public Text highestScoreText;
    public GameObject gameOverScreen;
    public int highestScore;
    [SerializeField] private Animator animator;
    private void Start()
    {
        highestScore = PlayerPrefs.GetInt("highestScore", 0);
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }

    [ContextMenu("Increase score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isDead", true);

        gameOverScreen.SetActive(true);

        highestScore = PlayerPrefs.GetInt("highestScore", 0);

        if (playerScore > highestScore)
        {
            highestScore = playerScore;
            PlayerPrefs.SetInt("highestScore", playerScore);
            PlayerPrefs.Save();
            highestScoreText.text = "Highest Score: " + highestScore.ToString();
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
