using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    private int score;
    private TextMeshProUGUI scoreText;

    private int lives;
    private TextMeshProUGUI livesText;

    private GameObject gameOverText;

    private void Start()
    {
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        UpdateScore(0);

        lives = 3;
        livesText = GameObject.Find("LivesText").GetComponent<TextMeshProUGUI>();

        gameOverText = GameObject.Find("GameOver");
        gameOverText.SetActive(false);
    }

    public void UpdateScore(int amountToAdd)
    {
        score += amountToAdd;
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateLives(int amountToAdd)
    {
        lives += amountToAdd;
        livesText.text = "LIVES REMAINING: " + lives;

        if (lives <= 0) GameOver();
    }

    private void GameOver()
    {
        gameOverText.SetActive(true);
        if (GameObject.Find("Spawner").GetComponent<Spawner>() == null) GameObject.Find("Spawner").GetComponent<BadSpawner>().CancelInvoke();
        else GameObject.Find("Spawner").GetComponent<Spawner>().CancelInvoke();
    }
}
