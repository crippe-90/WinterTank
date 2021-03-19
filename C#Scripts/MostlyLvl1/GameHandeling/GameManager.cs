using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public Text messageText;
    public Image background;
    public Steering lvlSteering;
    public Transform enemies;

    private string gameOverString = "GAME OVER!" + Environment.NewLine + "R.I.P";
    private Color gameOverScreenColor = new Color(82, 0, 0, 20);
    private float restartDelay = 3f;

    private int enemyCounter;
    private string lvlCompletedText = "Well done!";


    private void Start()
    {
        enemyCounter = enemies.childCount;
    }

    public void GameOver()
    {
        EndAllMovement();
        messageText.color = Color.black;
        messageText.text = gameOverString;
        background.color = gameOverScreenColor;
        Invoke("ReloadScene", restartDelay);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void StopPlayGame()
    {
        Application.Quit();
    }
    public void LevelCompleted()
    {
            if (enemyCounter == 0)
            {

                 EndAllMovement();

                //FindObjectOfType<WinterTankSteering>().StopAllCoroutines();
                messageText.color = Color.blue;
                messageText.text = lvlCompletedText;
                Invoke("LoadNextScene", 2f);
            }
            else
            {
                //make a class to inherrit from for every level
                messageText.color = Color.white;
                if (enemyCounter == 1)
                {
                    messageText.text = "You still have " + enemyCounter.ToString() + " enemy left to kill.";
                }
                else
                {
                    messageText.text = "You still have " + enemyCounter.ToString() + " enemies left to kill.";
                }

                Invoke("ClearText", 3f);
            }
        
    }
    private void ClearText()
    {
        messageText.text = "";
    }
    public void DecEnemyCounter()
    {
        enemyCounter--;
    }
    private void EndAllMovement()
    {
        lvlSteering.StopMoving();
    }
}
