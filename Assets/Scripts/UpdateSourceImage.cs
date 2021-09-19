using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSourceImage : MonoBehaviour
{
    Image aslImage;
    string letter;

    public MatchingGameState state;
    public int option;
    // Start is called before the first frame update
    void Start()
    {
        if (!(aslImage = this.gameObject.GetComponent<Image>())){
            Debug.Log("No image component found");
            return;
        }
        letter = state.options[option];
        aslImage.sprite = Resources.Load<Sprite>("asl_" + letter.ToLower());
    }

    // Update is called once per frame
    void Update()
    {
        if(state.getShouldChangeLetter()){
            aslImage.sprite = Resources.Load<Sprite>("asl_" + letter.ToLower());
        }
    }
}
