using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour
{
    public Text scoreText;
    public int score = 984;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
}
