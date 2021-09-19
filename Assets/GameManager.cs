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

    public string currentSet = "";
    public char currentLetter = ' ';
    public string currentLetters = "";


    // ASL Sprites
    public Sprite[] sprites = new Sprite[26];

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

        

        if (score <= -20)
        {
            gameOver = true;
        }
    }


    public void LoadLesson(string letters)
    {
        letters = letters.ToUpper();
        currentSet = letters;
        currentLetters = letters.Substring(0, 1);
        currentLetter = letters.ToCharArray()[0];
        SceneManager.LoadScene("Tutorial");
    }

    public void ProgressLetter()
    {

        if (currentLetters.Length < currentSet.Length)
        {
            currentLetters = currentSet.Substring(0, currentLetters.Length + 1);
            currentLetter = currentLetters.ToCharArray()[currentLetters.Length - 1];
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            SceneManager.LoadScene("Congrats");
        }
    }

    public Sprite GetSprite(string letter)
    {
        letter = letter.ToLower();
        char letterc = letter.ToCharArray()[0];
        Debug.Log(letterc);
        return sprites[letterc- 97];
    }
}
