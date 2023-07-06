/*
 * Author: Ashley Goh Yu Ting
 * Date: 02/07/2023
 * Description: I3E/STLD Assignment 2 - Cutscene 2 Rocks
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //For managing scenes

public class Cutscene2Rocks : MonoBehaviour
{
    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static Cutscene2Rocks instance;

    private void Awake()
    {
        instance = this;
    }

    void RocksGone()
    {
        Destroy(gameObject);
        GameManager.gameManager.LoadingScreen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Moves back to outside area
    }

    public void Cutscene2RocksSinking()
    {
        Debug.Log("Cutscene Rocks Sinking");
        GetComponent<Animator>().SetBool("isTextDone", true);
        Audio.instance.bomb.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
