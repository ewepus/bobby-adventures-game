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
        // ������, ��������� ������������� ����������
        if (instance == null)
        { // ��������� ��������� ��� ������
            instance = this; // ������ ������ �� ��������� �������
        }
        else if (instance == this)
        { // ��������� ������� ��� ���������� �� �����
            Destroy(gameObject); // ������� ������
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }
}