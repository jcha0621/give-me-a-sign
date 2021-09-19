using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour
{
    public Text scoreText;
    public int score = 984;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        scoreText.text = gameManager.score.ToString();
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
}
