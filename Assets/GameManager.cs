using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool gameOver = false;
    // public CatchingSign catchingSign;
    public float waitTime = 0.5f;
    public float waitTimeCounter = 0f;
    public float score = 0f;

    public string currentLetters = "";
    public string currentLetter = "";

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            SceneManager.LoadScene("Tutorial");
        } else {
            waitTimeCounter += Time.deltaTime;
            if (waitTimeCounter >= waitTime)
            {
                waitTimeCounter = 0f;
                // CatchingSign projectile = Instantiate(catchingSign);
            }
        }

        if (score >= 200)
        {
            SceneManager.LoadScene("Tutorial");
        }

        if (score <= -20)
        {
            gameOver = true;
        }
    }


    public void LoadLesson(string letters)
    {
        currentLetters = letters;
        currentLetter = letters.Substring(0, 1);
        SceneManager.LoadScene("Tutorial");
    }
}
