using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameControlling : MonoBehaviour
{

    public static GameControlling instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;

    private int score = 0;
    private bool gameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }

    public void UpdateScore(int newScore)
    {
        score = newScore;
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
