using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSourceImage : MonoBehaviour
{
    Image aslImage;
    string letter;
    MatchingGameState state;

    public int option;

    // ASL Sprites
    public Sprite[] sprites = new Sprite[26];
    // Start is called before the first frame update
    void Start()
    {
        if (!(aslImage = this.gameObject.GetComponent<Image>())){
            Debug.Log("No image component found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state==null){
            StartCoroutine(StartRoutine());
        }
        else {
            Debug.Log("should change letter: "+ state.shouldChangeLetter);
            if(state.shouldChangeLetter || aslImage.sprite==null){
                Debug.Log("changing option " + option + "sprite with letter " + letter);
                letter = state.options[option];
                aslImage.sprite = sprites[letter[0]-97];
            }
        }
    }

    IEnumerator StartRoutine()
    {
        yield return new WaitForEndOfFrame();

        /*
       while(GameObject.Find("Canvas") == null){
        //state = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<MatchingGameState>();
        yield return null;
       }
       */
      
       state = GameObject.Find("Canvas").GetComponent<MatchingGameState>();
       Debug.Log("state:" + state);
    }
}
