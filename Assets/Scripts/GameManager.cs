using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public Button playButton;
    public Button restartButton;


    public int score;
    public bool isGameOver = true;
    public bool isWin = true;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        //restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(score == 10)
        {
            Win();
        }   
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void Win()
    {
        isGameOver = true;
        isWin = true;
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        isGameOver = true;
        restartButton.gameObject.SetActive(true);
        if(!isWin)
            gameOverText.gameObject.SetActive(true);    
    }
    public void StartGame()
    {        
        isGameOver = false;
        isWin = false;
        score = 0;
        playButton.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
