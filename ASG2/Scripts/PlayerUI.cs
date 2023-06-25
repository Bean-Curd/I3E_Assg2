/*
 * Author: Ashley Goh Yu Ting
 * Date: 24/06/2023
 * Description: I3E/STLD Assignment 2 - Player UI 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //For managing scenes

public class PlayerUI : MonoBehaviour
{
    /// <summary>
    /// Intro1 as game object
    /// </summary>
    public GameObject intro1;
    /// <summary>
    /// Intro2 as game object
    /// </summary>
    public GameObject intro2;
    /// <summary>
    /// Intro3 as game object
    /// </summary>
    public GameObject intro3;

    /// <summary>
    /// Clicks for intro
    /// </summary>
    private int introClicks;
    /// <summary>
    /// Is intro done
    /// </summary>
    private bool introDone;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static PlayerUI instance;

    private void Awake()
    {
        instance = this;
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            DontDestroyOnLoad(gameObject);
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        //Show the intro sequence
        Debug.Log("Intro");
        introClicks = 1;
        introDone = false;
        intro1.SetActive(true); //Show 1st dialogue

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //If left click is pressed, change dialogue
        {
            introClicks += 1;

            if (introClicks > 3)
            {
                intro3.SetActive(false);
                introDone = true;
            }
            else if (introClicks == 3 && introDone != true)
            {
                intro2.SetActive(false);
                intro3.SetActive(true);
            } 
            else if (introClicks == 2 && introDone != true)
            {
                intro1.SetActive(false);
                intro2.SetActive(true);
            }
        }
    }
}
