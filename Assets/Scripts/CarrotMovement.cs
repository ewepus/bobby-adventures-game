using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deleteZone = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if(transform.position.x <= deleteZone)
        {
            Debug.Log("Obstacle destroyed");
            GameObject.Destroy(gameObject);
        }
    }
}
