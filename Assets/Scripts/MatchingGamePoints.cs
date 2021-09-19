using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingGamePoints : MonoBehaviour
{
    MatchingGameState state;
    Text displayScore;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state==null){
            StartCoroutine(StartRoutine());
        }
        /*
        else {
            Debug.Log("beginning check logic");
            if(state.getIsCorrect()){
                Debug.Log("correct");
                score+=200;
                
                //reset state
                state.resetState();
            }
            else{
                Debug.Log("incorrect");
                score = score-100<0 ? 0 : score-100;
            }
            displayScore.text = score.ToString();
        }
        */
    }

    
    IEnumerator StartRoutine()
    {
        yield return new WaitForEndOfFrame();
      
       state = GameObject.Find("Canvas").GetComponent<MatchingGameState>();
       displayScore = this.GetComponent<UnityEngine.UI.Text>();

    }

    public void updateScore(bool correct)
    {
        if(correct){
            Debug.Log("correct");
            score+=200;
                
            //reset state
            state.resetState();
        }
        else
        {
            Debug.Log("incorrect");
            score = score-100<0 ? 0 : score-100;
        }
        displayScore.text = score.ToString();
    }
}
