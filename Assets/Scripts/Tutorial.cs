using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    private GameManager gameManager;
    public Text letterText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        letterText.text = gameManager.currentLetter.ToString().ToUpper();
    }

    public void TutorialContinue()
    {
        SceneManager.LoadScene("Matching");
    }
}
