using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingGameState : MonoBehaviour
{
    string currentLetter;
    //All the possible actions 
    List<string> lettersInLevel;
    char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    Text letterText;

    //Letters that the player has currently had tutorials for
    List<string> lettersLearned;


    public int questionCount = 1;

    public string[] options = new string[4];

    public bool shouldChangeLetter;

    public int matchingScore;

    public int resetImages = -1;

    // Publicly exposed variable that determines which letters are in the level.
    // Connect with levels by customly setting for each level scene.
    public int level;

    //Script that controls point system in matching game.
    // public MatchingGamePoints points;

    //Gamemanager
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        lettersLearned = new List<string>();
        lettersInLevel = new List<string>();
        gameManager = GameManager.Instance;
        Debug.Log(gameManager.currentSet);
        char[] chars = gameManager.currentSet.ToCharArray();

        foreach(char c in chars)
        {
            lettersInLevel.Add(c.ToString().ToLower());
        }

        chars = gameManager.currentLetters.ToCharArray();

        foreach (char c in chars)
        {
            lettersLearned.Add(c.ToString().ToLower());
        }

        //switch(level)
        //{
        //    case 1:
        //        lettersInLevel = new List<string> { "a", "b", "c","d","e" };
        //        break;
        //     case 2:
        //        lettersInLevel = new List<string> { "f", "g", "h","i","j" };
        //        break;
        //     case 3:
        //        lettersInLevel = new List<string> { "k", "l", "m","n","o" };
        //        break;
        //     case 4:
        //        lettersInLevel = new List<string> { "p", "q", "r","s","t" };
        //        break;
        //     case 5:
        //        lettersInLevel = new List<string> { "u", "v", "w","x","y","z" };
        //        break;                
        //}



    }

    // Update is called once per frame
    void Update()
    {
        if(letterText == null){
            StartCoroutine(StartRoutine());
        }
        else{
            if(shouldChangeLetter)
                changeLetter();
        }

        if(questionCount > 5)
        {
            gameManager.score = matchingScore;
            gameManager.ProgressLetter();
        }
    }

    void changeLetter()
    {
       Debug.Log("changing letter");
       currentLetter = lettersLearned[UnityEngine.Random.Range(0, lettersLearned.Count)].ToString();
       letterText.text = currentLetter.ToUpper();
       changeOptions();    
       shouldChangeLetter = false;   
    }

    void changeOptions()
    {
        // Populate answer choice options
       int currentLetterIndex = UnityEngine.Random.Range(0,4);
        List<int> randomVals = new List<int>();
       options[currentLetterIndex] = currentLetter;
       for(int i=0; i<options.Length; i++){
            if (i != currentLetterIndex)
            {
                int j = UnityEngine.Random.Range(0, 26);
                while (randomVals.Contains(j) | currentLetter.ToLower().Equals(alphabet[j].ToString().ToLower()))
                {
                    
                    
                    j = UnityEngine.Random.Range(0, 26);
                }
                randomVals.Add(j);
                options[i] = alphabet[j].ToString();
            }
       }
    }
    public string getCurrentLetter() { return currentLetter; }

    IEnumerator StartRoutine()
    {
        yield return new WaitForEndOfFrame();
        letterText = GameObject.Find("Letter").GetComponent<Text>();
        Debug.Log(letterText.text);
    }

    public void resetState(){
        questionCount +=1;
        Debug.Log("resetting state");
        shouldChangeLetter = true;
        resetImages = 0;
    }
}
