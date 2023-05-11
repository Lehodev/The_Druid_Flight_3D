using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControlling : MonoBehaviour
{

    public static GameControlling controller;

    public TextMeshProUGUI pointText;
    public GameObject gameOverObject;
    private bool gameOver = false;

    private int point = 0;

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdatePoint(int newPoint)
    {
        point = newPoint;
        pointText.text = "Point: " + point.ToString();
    }

    public void BirdDied()
    {
        gameOverObject.SetActive(true); 
        gameOver = true;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
