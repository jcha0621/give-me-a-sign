using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingGameState : MonoBehaviour
{
    string currentLetter;
    List<string> lettersInLevel;
    char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    bool shouldChangeLetter;
    Text letterText; 

    public string[] options = new string[4];

    // Publicly exposed variable that determines which letters are in the level.
    // Connect with levels by customly setting for each level scene.
    public int level;

    //Script that controls point system in matching game.
    // public MatchingGamePoints points;

    // Start is called before the first frame update
    void Start()
    {
        letterText = gameObject.transform.Find("Letter").gameObject.GetComponent<Text>();
        
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
        changeLetter();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldChangeLetter)
            changeLetter();
        
    }

    public bool getShouldChangeLetter(){ return shouldChangeLetter;}

    void changeLetter(){
       currentLetter = lettersInLevel[UnityEngine.Random.Range(0,lettersInLevel.Count)].ToString();
       letterText.text = currentLetter.ToUpper();
       changeOptions();
       
    }

    void changeOptions(){
        // Populate answer choice options
       int currentLetterIndex = UnityEngine.Random.Range(0,4);
       options[currentLetterIndex] = currentLetter;
       for(int i=0; i<options.Length; i++){
           if(i!=currentLetterIndex)
            options[i] = alphabet[UnityEngine.Random.Range(0,26)].ToString();
       }
    }
}
