using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameControlling : MonoBehaviour
{

    public static GameControlling controller;

    public TextMeshProUGUI pointText;
    public GameObject gameOverText;

    private int point = 0;
    private bool gameOver = false;

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

    void Update()
    {

    }

    public void UpdatePoint(int newPoint)
    {
        point = newPoint;
        pointText.text = "Point: " + point.ToString();
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
