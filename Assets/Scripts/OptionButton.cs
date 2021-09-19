using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    static Color correctColor = new Color(0.2156863f, 0.682353f, 0.5254902f);
    static Color incorrectColor = new Color(0.8773585f, 0.2681737f, 0.2681737f);

    MatchingGameState state;
    UpdateSourceImage aslImage; 
    MatchingGamePoints score;
    Button btn;
    ColorBlock cb;
     
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        cb = btn.colors;
        btn.onClick.AddListener(validateAnswer);
    }

    // Update is called once per frame
    void Update()
    {
        if (state==null){
            StartCoroutine(StartRoutine());
        }
        /*
        else { 
            // Validates answer
            if(state.getCurrentLetter() == aslImage.getLetter()){
                cb.selectedColor = correctColor;
                state.setCorrectBool(true);
            }
            else{
                cb.selectedColor = incorrectColor;
                state.setCorrectBool(false);
            }
            btn.colors = cb;
        }
        */
    }

    IEnumerator StartRoutine()
    {
        yield return new WaitForEndOfFrame();
      
       state = GameObject.Find("Canvas").GetComponent<MatchingGameState>();
       score = GameObject.Find("Score").GetComponent<MatchingGamePoints>();

       aslImage = this.GetComponentInChildren<UpdateSourceImage>();
    }

    void validateAnswer(){
        if(state.getCurrentLetter() == aslImage.getLetter()){
            cb.selectedColor = correctColor;
            score.updateScore(true);
        }
        else{
            cb.selectedColor = incorrectColor;
            score.updateScore(false);
        }
        btn.colors = cb;
        state.matchingScore = score.score;

    }
}
