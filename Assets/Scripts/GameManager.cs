using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highscoreText;
    public TextMeshProUGUI instructionsText;

    private void Awake()
    {
       highscoreText.text = "Highscore: " + GetHighScore().ToString();
    }

    void Start()
    {
        scoreText.enabled = false;
        instructionsText.enabled = true;
    }

    public void StartGame()
    {
        gameStarted = true;
        scoreText.enabled = true;
        instructionsText.enabled = false;
        FindObjectOfType<Road>().StartBuilding();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Highscore: " + score.ToString();
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
