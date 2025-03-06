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
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
        if (!bobbyIsAlive)
        {
            Debug.Log("Nothing ever happens");
        }
        else
        {
            verticalVelocity = rigidbody2D.velocity.y;

            if (verticalVelocity > 0) animator.SetBool("isJumping", true);
            else if (verticalVelocity <= 0) animator.SetBool("isJumping", false);

            if (bobbyIsAlive && Input.anyKeyDown) rigidbody2D.velocity = Vector2.up * jumpStrength;

            if (transform.position.y > 3.25 || transform.position.y < -3.25)
            {
                logicScript.GameOver();
                bobbyIsAlive = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        bobbyIsAlive = false;
    }
}
//Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
