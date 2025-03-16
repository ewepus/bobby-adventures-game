using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float jumpStrength;
    public LogicScript logicScript;
    public bool bobbyIsAlive = true;
    public float verticalVelocity;
    [SerializeField] private Animator animator;
    public AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
        if (!bobbyIsAlive) { }
        else
        {
            verticalVelocity = rigidbody2D.linearVelocity.y;

            if (verticalVelocity > 0) animator.SetBool("isJumping", true);
            else if (verticalVelocity <= 0) animator.SetBool("isJumping", false);

            if (bobbyIsAlive && Input.anyKeyDown)
            {
                audioManager.jumpSound.Play();
                rigidbody2D.linearVelocity = Vector2.up * jumpStrength;
            }

            if (transform.position.y > 3.25 || transform.position.y < -3.25)
            {
                logicScript.GameOver();
                if(!logicScript.isNewHighScore) audioManager.gameOverSound.Play();
                bobbyIsAlive = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bobbyIsAlive)
        {
            logicScript.GameOver();
            audioManager.collisionSound.Play();
            bobbyIsAlive = false;
        }
    }
}
