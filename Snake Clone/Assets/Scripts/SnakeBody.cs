using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private GameObject lead; //the obj that is in front of this obj
    private Vector3 leadPosOld;
    private Vector3 leadRotOld;
    private Vector3 leadPosCurrent;
    private Vector3 leadRotCurrent;

    private int appleCounter;
    private SpawnManager spawnManager;
    
    
    
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        appleCounter = spawnManager.applesEaten;

        if(appleCounter == 0)
        {
            lead = GameObject.Find("SnakeHead");
            leadPosOld = lead.transform.position;
            leadRotOld = lead.transform.eulerAngles;
        }
        else
        {
            lead = GameObject.Find("SnakeBody_" + (appleCounter)); //store initial pos and rot of body in front
            leadPosOld = lead.transform.position;
            leadRotOld = lead.transform.eulerAngles;
        }
        

    }

    void Update()
    {

        handleBodyMovement();
    }

    private void handleBodyMovement()
    {
        leadPosCurrent = lead.transform.position; //always be tracking the current position of obj in front
        leadRotCurrent = lead.transform.eulerAngles; //always be tracking the current rotation of obj in front

        if(leadPosOld != leadPosCurrent) //if obj in front moves
        {
            gameObject.transform.position = leadPosOld; //set this body position to old position of body in front
            gameObject.transform.eulerAngles = leadRotOld; //set this body position to old rotation of body in front


            leadPosOld = leadPosCurrent;
            leadRotOld = leadRotCurrent;
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
