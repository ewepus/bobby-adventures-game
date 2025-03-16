using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonLogic : MonoBehaviour
{
    public LogicScript logicScript;
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            logicScript.RestartGame();
        }
    }
}
