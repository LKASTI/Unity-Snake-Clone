using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOn;
    public bool gameOver;
    private GameObject gameGeneration;
    private GameObject gameOverUI;

    void Start()
    {
        gameOverUI = GameObject.Find("GameOverUI");
            GameObject.Find("GameOverUI").SetActive(false);
        gameGeneration = GameObject.Find("GameGeneration");
            GameObject.Find("GameGeneration").SetActive(false);
        gameOn = false;
        gameOver = false;
    }

    void Update()
    {
        if(gameOver)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void startGame()
    {
        gameOn = true;
        GameObject.Find("MenuUI").SetActive(false);
        gameGeneration.SetActive(true);
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
