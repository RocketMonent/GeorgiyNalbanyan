using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Target> targetList;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject gameOverPanel;
    public GameObject titelPanel;

    private int score;
    private int health = 3;
    private float spawnRate = 2f;

    public bool isGameActive;

    public void  StartGame(int difficulty)
    {
        spawnRate = spawnRate / difficulty;
        titelPanel.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateHealth(0);
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targetList.Count);
            Instantiate(targetList[index]);
        }
    }


    public void UpdateScore(int scoreToAdd)
    {
        score = score + scoreToAdd;

        if (score <= 0)
        {
            score = 0;
        }

        scoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int healthToSubtract)
    {
        health = health - healthToSubtract;

        if (health <= 0)
        {
            health = 0;
            GameOver();
        }

        healthText.text = "Health: " + health;
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
