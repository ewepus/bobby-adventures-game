using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource menuSong;
    public AudioSource buttonSound1;
    public AudioSource buttonSound2;
    public AudioSource gameOverSound;
    public AudioSource highestScoreSound;
    public AudioSource collisionSound;
    public AudioSource jumpSound;
    void Start()
    {
        // “еперь, провер€ем существование экземпл€ра
        if (instance == null)
        { // Ёкземпл€р менеджера был найден
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance == this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }
}