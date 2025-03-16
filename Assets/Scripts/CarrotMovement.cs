using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deleteZone = -10;
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x <= deleteZone)
        {
            Debug.Log("Obstacle destroyed");
            GameObject.Destroy(gameObject);
        }
    }
}
