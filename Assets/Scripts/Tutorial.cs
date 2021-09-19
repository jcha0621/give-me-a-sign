using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text letterText;
    public string letter = "S";
    public GameObject sign; // need to add changing the ASL image as well

    // Start is called before the first frame update
    void Start()
    {
        letterText.text = letter;
    }
}
