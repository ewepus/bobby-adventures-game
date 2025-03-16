using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotMiddleLogic : MonoBehaviour
{
    public LogicScript logicScript;
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logicScript.AddScore(1);
        }
    }
}
