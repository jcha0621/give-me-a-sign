using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSourceImage : MonoBehaviour
{
    Button btn;
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
        btn = transform.parent.gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state==null){
            StartCoroutine(StartRoutine());
        }
        else {
            if(state.resetImages == option){
                aslImage.sprite = null;
                state.resetImages = state.resetImages==3 ? -1 : state.resetImages+1;
                // Reset selected color to white.
                ColorBlock cb = btn.colors;
                cb.selectedColor = Color.white;
                btn.colors = cb;
            }
            else if(aslImage.sprite == null || state.shouldChangeLetter){
                letter = state.options[option];
                aslImage.sprite = sprites[letter[0]-97];
                
            }
        }

    }

    public string getLetter(){ return letter; }

    IEnumerator StartRoutine()
    {
       yield return new WaitForEndOfFrame();
       state = GameObject.Find("Canvas").GetComponent<MatchingGameState>();
    }

}
