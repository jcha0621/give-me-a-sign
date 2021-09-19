using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingGameState : MonoBehaviour
{
    string currentLetter;
    List<string> lettersInLevel;
    char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    Text letterText;
    
    public int questionCount = 1;

    public string[] options = new string[4];

    public bool shouldChangeLetter;

    public int matchingScore;

    public int resetImages = -1;

    // Publicly exposed variable that determines which letters are in the level.
    // Connect with levels by customly setting for each level scene.
    public int level;

    //Script that controls point system in matching game.
    public MatchingGamePoints points;

    // Start is called before the first frame update
    void Start()
    {
        switch(level)
        {
            case 1:
                lettersInLevel = new List<string> { "a", "b", "c","d","e" };
                break;
             case 2:
                lettersInLevel = new List<string> { "f", "g", "h","i","j" };
                break;
             case 3:
                lettersInLevel = new List<string> { "k", "l", "m","n","o" };
                break;
             case 4:
                lettersInLevel = new List<string> { "p", "q", "r","s","t" };
                break;
             case 5:
                lettersInLevel = new List<string> { "u", "v", "w","x","y","z" };
                break;                
        }
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
    }

    void changeLetter()
    {
       Debug.Log("changing letter");
       currentLetter = lettersInLevel[UnityEngine.Random.Range(0,lettersInLevel.Count)].ToString();
       letterText.text = currentLetter.ToUpper();
       changeOptions();    
       shouldChangeLetter = false;   
    }

    void changeOptions()
    {
        // Populate answer choice options
       int currentLetterIndex = UnityEngine.Random.Range(0,4);
       options[currentLetterIndex] = currentLetter;
       for(int i=0; i<options.Length; i++){
           if(i!=currentLetterIndex)
            options[i] = alphabet[UnityEngine.Random.Range(0,26)].ToString();
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
