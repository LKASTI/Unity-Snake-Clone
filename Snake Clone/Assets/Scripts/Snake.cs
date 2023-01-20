using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private float vert;
    private float horiz;
    private Vector3 direction;
    private Vector3 direction2;
    private float timer;
    private float timerMax;
    private Vector3 facingDown = new Vector3(0,0,180);
    private Vector3 facingUp = new Vector3(0,0,0);
    private Vector3 facingLeft = new Vector3(0,0,90);
    private Vector3 facingRight = new Vector3(0,0,-90);
    public GameObject snakeBodyPrefab;
    private GameObject snakeBody;
    public int tempAppleCounter;
    private SpawnManager spawnManager;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    public Sprite deadHead;
    
    
    void Start()
    { 
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        tempAppleCounter = spawnManager.applesEaten;
        timerMax = 0.2f;
        timer = timerMax;
        direction = new Vector3(0,0,0);
    }

    void Update()
    {   
        if(gameManager.gameOn && !(gameManager.gameOver))
        {
            handleDirectionRotation();
            handleMovement();
            growBody();
            checkOutOfBounds();
        }


        
        

    }

    private void growBody()
    {
        if(spawnManager.applesEaten > tempAppleCounter)
        {
            tempAppleCounter ++;
            
            GameObject leadBody = GameObject.Find("SnakeBody_" + tempAppleCounter);
            snakeBody = Instantiate(snakeBodyPrefab, leadBody.transform.position /*- (direction)*/, leadBody.transform.rotation);
            snakeBody.name = "SnakeBody_" + (tempAppleCounter+1);
            snakeBody.transform.SetParent(GameObject.Find("SnakeWhole").transform);
            
        }
    }

    private void checkOutOfBounds()
    {
        if(gameObject.transform.position.x < spawnManager.minPos || gameObject.transform.position.x > spawnManager.maxPos 
        || gameObject.transform.position.y < spawnManager.minPos || gameObject.transform.position.y > spawnManager.maxPos)
        {
            gameObject.transform.position -= (direction);
            spriteRenderer.sprite = deadHead;
            gameManager.gameOver = true;
        } 
    }
    void OnTriggerEnter2D(Collider2D o) //if snake runs into something it game is over
    {
        if(o.CompareTag("SnakePart"))
        {
            Debug.Log("collision");
            spriteRenderer.sprite = deadHead;
            gameManager.gameOver = true;
        }
    }

    private void handleMovement()
    {
        timer += Time.deltaTime;
        if(timer >= timerMax)
        {
            gameObject.transform.position += (direction);
            timer -= timerMax;
        }
    }
    private void handleDirectionRotation()
    {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && direction != Vector3.down)
         {
             direction = new Vector3(0,1,0);
             transform.eulerAngles = new Vector3(0,0,0);
             
         }
         else if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && direction != Vector3.up) 
         {
             direction = new Vector3(0,-1,0);
             transform.eulerAngles = new Vector3(0,0,180);
         }
         else if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && direction != Vector3.right)
         {
             direction = new Vector3(-1,0,0);
             transform.eulerAngles = new Vector3(0,0,90);
         }
         else if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && direction != Vector3.left)
         {
             direction = new Vector3(1,0,0);
             transform.eulerAngles = new Vector3(0,0,270);
         }
    }


    
}
