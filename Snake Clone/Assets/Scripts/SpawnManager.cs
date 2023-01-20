using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject applePrefab;
    public int minPos = 1;
    public int maxPos = 9;
    private int maxApplesOut = 1;
    public int applesOut = 0;
    public int applesEaten = 0;
    private GameObject snakeHeadObject;
    public GameObject appleObject;
    private Vector3 appleObjectPos;
    private GameManager gameManager;
    private int lengthOfSnake;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gameManager.gameOn && !(gameManager.gameOver))
        {
            snakeHeadObject = GameObject.Find("SnakeHead");
        }
        
        
        
    }
    void Update()
    {
        if(gameManager.gameOn && !(gameManager.gameOver))
        {
            spawnApple();
            eatApple();
            //Debug.Log(applesOut);
        }








        
    }

    private void spawnApple()
    {


        if(applesOut < maxApplesOut)
        {
            bool spawnApple = true;
            Vector3 snakeHeadPos = GameObject.Find("SnakeHead").transform.position; //store position of head, first body, and tail
            Vector3 snakeBody1Pos = GameObject.Find("SnakeBody_1").transform.position;
            Vector3 snakeTailPos = GameObject.Find("SnakeTail").transform.position;

            float randYpos = Random.Range(minPos, maxPos + 1);
            float randXpos = Random.Range(minPos, maxPos + 1);
            appleObjectPos = new Vector3(randXpos, randYpos, applePrefab.transform.position.z); //randomly generate a postion for apple in grid domain and range

            lengthOfSnake = 3 + applesEaten; //store length of snake which is initial 3 parts plus how many apples have been eaten

            Vector3 [] snakePartPositions = new Vector3[lengthOfSnake]; //create array and store intial three parts
                snakePartPositions[0] = snakeHeadPos;
                snakePartPositions[1] = snakeBody1Pos;
                snakePartPositions[lengthOfSnake-1] = snakeTailPos; //snake tail is at end of array because it's always at end of snake


            for(int i = 2; i < (lengthOfSnake-1); i++) //loop to store parts of snake
            {
                snakePartPositions[i] = GameObject.Find("SnakeBody_"+(i)).transform.position; 
            }
            for(int i = 0; i < lengthOfSnake; i++) //if the apple's randomly generated position equals position of any of the parts then cannot spawn apple 
            {                                      
                if(snakePartPositions[i] == appleObjectPos)
                {
                    Debug.Log("good");
                    spawnApple = false;
                }   
            }
            if(spawnApple) //if the boolean spawnApple didnt get changed to false then the apple is clear to spawn on the randomly assigned position
            {
                appleObject = Instantiate(applePrefab, appleObjectPos, applePrefab.transform.rotation);
                applesOut ++;
            }
        }      
    }

    private void eatApple()
    {
        if(appleObject != null && snakeHeadObject.gameObject.transform.position == appleObject.gameObject.transform.position)
        {
            
            Destroy(appleObject.gameObject);
            applesEaten++;
            applesOut--;
        }
    }

    
}
