using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    private GameObject leadBody;
    private SpawnManager spawnManager;
    private int appleCounter;
    private Vector3 leadPosOld;
    private Vector3 leadRotOld;
    private Vector3 leadPosCurrent;
    private Vector3 leadRotCurrent;
    private Snake snake;

    void Start()
    {
        snake = GameObject.Find("SnakeHead").GetComponent<Snake>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        leadBody = GameObject.Find("SnakeBody_1");
        leadPosOld = leadBody.transform.position;
        leadRotOld = leadBody.transform.eulerAngles;
    }

    void Update()
    {
        /*appleCounter = spawnManager.applesEaten;*/

        leadBody = GameObject.Find("SnakeBody_" + (snake.tempAppleCounter +1));
        
        handleTailMovement(); 


    }

    private void handleTailMovement()
    {
        leadPosCurrent = leadBody.transform.position; //always be tracking the current position of body in front of the tail
        leadRotCurrent = leadBody.transform.eulerAngles; //always be tracking the current rotation of body in front of the tail

        if(leadPosOld != leadPosCurrent) //if body in front of tail moves
        {
            gameObject.transform.position = leadPosOld; //set this body position to old position of body in front
            gameObject.transform.eulerAngles = leadRotCurrent; //set this body position to current rotation of body in front


            leadPosOld = leadPosCurrent;
            //leadRotOld = leadRotCurrent;
        }
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if(o.gameObject.CompareTag("apple"))
        {
            //Debug.Log("!"); //troubleshooting
            // Destroy(spawnManager.appleObject.gameObject);
            // spawnManager.applesOut --;
            
        }
    }
}
