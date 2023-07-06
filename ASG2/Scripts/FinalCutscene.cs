/*
 * Author: Ashley Goh Yu Ting
 * Date: 02/07/2023
 * Description: I3E/STLD Assignment 2 - Final Cutscene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //For managing scenes

public class FinalCutscene : MonoBehaviour
{
    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static FinalCutscene instance;

    private void Awake()
    {
        instance = this;
    }

    void TheEnd()
    {
        GameManager.gameManager.LoadingScreen();
        SceneManager.LoadScene(0); //Moves to start menu
    }

    // Start is called before the first frame update
    void Start()
    {
        Audio.instance.launch.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
