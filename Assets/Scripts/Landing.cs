using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            SceneManager.LoadScene("Levels");
        }
        
    }
}
