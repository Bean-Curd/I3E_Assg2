using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ASG2_StartPage : MonoBehaviour
{
    /// <summary>
    /// To start normal mode when clicked
    /// </summary>
    public void ClickNormal()
    {
        GameManager.gameManager.NormalMode(true); //Implement normal mode variables
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Moves to the next scene
    }

    /// <summary>
    /// To start hard mode when clicked
    /// </summary>
    public void ClickHard()
    {
        GameManager.gameManager.HardMode(true); //Implement hard mode variables
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Moves to the next scene
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// To exit when the player says yes
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; //So it works in play mode for testing
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
