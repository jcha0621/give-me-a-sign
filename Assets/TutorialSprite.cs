using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSprite : MonoBehaviour
{

    SpriteRenderer aslImage;
    GameManager gameManager;
    // ASL Sprites
    public Sprite[] sprites = new Sprite[26];
    // Start is called before the first frame update
    void Start()
    {
        if (!(aslImage = this.gameObject.GetComponent<SpriteRenderer>()))
        {
            Debug.Log("No image component found");
        }
        gameManager = GameManager.Instance;
        char letter = gameManager.currentLetter;
        Debug.Log(letter);
        aslImage.sprite = gameManager.GetSprite(letter.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
