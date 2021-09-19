using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    private GameManager gameManager;
    public Text letterText;
    public string letter = "S";
    public GameObject sign; // need to add changing the ASL image as well

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        letterText.text = gameManager.currentLetter.ToUpper();
    }

    public void TutorialContinue()
    {
        SceneManager.LoadScene("Catching");
    }
}
