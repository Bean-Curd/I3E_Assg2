/*
 * Author: Ashley Goh Yu Ting
 * Date: 28/06/2023
 * Description: I3E/STLD Assignment 2 - Cutscene 1 Door Up Movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //For managing scenes

public class Cutscene1DoorUp : MonoBehaviour
{
    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static Cutscene1DoorUp instance;

    private void Awake()
    {
        instance = this;
    }

    void DoorOpened()
    {
        Destroy(gameObject);
        GameManager.gameManager.LoadingScreen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Moves back to spaceship
    }

    public void Cutscene1DoorUpAnimation()
    {
        Debug.Log("Cutscene Door Up Opening");
        GetComponent<Animator>().SetBool("isTextDone", true);
        Audio.instance.door.Play();
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
