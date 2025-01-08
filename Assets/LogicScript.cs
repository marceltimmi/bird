using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public UnityEvent gameoverEvent;

    public GameManager gameManager; // Referenz zum GameManager

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;  
        scoreText.text = playerScore.ToString();

    }

    public void Awake() {
        if (gameoverEvent == null)
        {
            gameoverEvent = new UnityEvent();
        }
    }

    public void restartGame()
    {
        
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void gameOver()
    {
        gameoverEvent.Invoke();
        gameOverScreen.SetActive(true);
    }
}
