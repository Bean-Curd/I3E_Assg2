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
    /// Temp game object for dialogue
    /// </summary>
    private GameObject dialogue;

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
    /// When approaching Scott's body
    /// </summary>
    public bool scottInteract = false;
    /// <summary>
    /// Scott dialogue
    /// </summary>
    public GameObject scott1;

    /// <summary>
    /// When approaching locked door
    /// </summary>
    public bool emergencyDoorInteract = false;
    /// <summary>
    /// Text that appears for locked doors during emergency lockdown
    /// </summary>
    public GameObject emergency1;

    /// <summary>
    /// When approaching locked weapons door
    /// </summary>
    public bool weaponDoorInteract = false;
    /// <summary>
    /// Text that appears for locked weapon door
    /// </summary>
    public GameObject weapon1;

    /// <summary>
    /// When approaching Elena's body
    /// </summary>
    public bool elenaInteract = false;
    /// <summary>
    /// Elena dialogue
    /// </summary>
    public GameObject elena1;

    /// <summary>
    /// When approaching Jake's body
    /// </summary>
    public bool jakeInteract = false;
    /// <summary>
    /// Jake dialogue
    /// </summary>
    public GameObject jake1;

    /// <summary>
    /// When collected first-aid kit
    /// </summary>
    public bool firstAidInteract = false;
    /// <summary>
    /// First-aid kit dialogue 1
    /// </summary>
    public GameObject firstAid1;
    /// <summary>
    /// First-aid kit dialogue 2
    /// </summary>
    public GameObject firstAid2;
    /// <summary>
    /// First-aid kit dialogue 3
    /// </summary>
    public GameObject firstAid3;
    /// <summary>
    /// First-aid kit dialogue 4
    /// </summary>
    public GameObject firstAid4;
    /// <summary>
    /// Clicks for first aid
    /// </summary>
    private int firstAidClicks;
    /// <summary>
    /// First-aid kit symbol
    /// </summary>
    public GameObject firstAidKit;
    /// <summary>
    /// First-aid kit symbol overlay
    /// </summary>
    public GameObject firstAidKitOverlay;

    /// <summary>
    /// When collected Captain's card
    /// </summary>
    public bool captainInteract = false;
    /// <summary>
    /// Captain's card dialogue 1
    /// </summary>
    public GameObject captain1;
    /// <summary>
    /// Captain's card dialogue 2
    /// </summary>
    public GameObject captain2;
    /// <summary>
    /// Captain's card dialogue 3
    /// </summary>
    public GameObject captain3;
    /// <summary>
    /// Clicks for Captain's card 
    /// </summary>
    private int captainClicks;
    /// <summary>
    /// Captain's card kit symbol
    /// </summary>
    public GameObject captainCard;

    /// <summary>
    /// When approaching Healing Station
    /// </summary>
    public bool healingInteract = false;
    /// <summary>
    /// If Hp max
    /// </summary>
    public GameObject healingNo;
    /// <summary>
    /// If Hp less then max
    /// </summary>
    public GameObject healingYes;

    /// <summary>
    /// When approaching main monitor
    /// </summary>
    public bool monitorInteract = false;
    /// <summary>
    /// When you don't have the captain's card
    /// </summary>
    public GameObject monitorNo;
    /// <summary>
    /// When you have the captain's card
    /// </summary>
    public GameObject monitorYes;

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
        firstAidClicks = 1;
        captainClicks = 1;
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

            if (scottInteract) //If done approaching scott's body
            {
                scott1.SetActive(false);
            }
            
            if (emergencyDoorInteract) //If approaching locked doors
            {
                emergency1.SetActive(false);
            }
            
            if (weaponDoorInteract) //If approaching locked weapon door
            {
                weapon1.SetActive(false);
            }
            
            if (elenaInteract) //If done approaching elena's body
            {
                elena1.SetActive(false);
            }
            
            if (firstAidInteract) //If picked up first-aid kit
            {
                firstAid1.SetActive(false);
                firstAidClicks += 1;

                if (firstAidClicks > 4)
                {
                    firstAid4.SetActive(false);
                }
                else if (firstAidClicks == 4)
                {
                    firstAid3.SetActive(false);
                    firstAid4.SetActive(true);
                }
                else if (firstAidClicks == 3)
                {
                    firstAid2.SetActive(false);
                    firstAid3.SetActive(true);
                }
                else if (firstAidClicks == 2)
                {
                    firstAid2.SetActive(true);
                }
            }
            
            if (healingInteract) //If near healing station
            {
                if (ASG2_HealthBar.instance.currentHealth >= 10000) //If max HP
                {
                    healingNo.SetActive(false);
                    healingYes.SetActive(false);

                }
            }
            
            if (jakeInteract) //If done approaching jake's body
            {
                jake1.SetActive(false);
            }
            
            if (captainInteract) //If picked up Captain's card
            {
                captain1.SetActive(false);
                captainClicks += 1;

                if (captainClicks > 3)
                {
                    captain3.SetActive(false);
                }
                else if (captainClicks == 3)
                {
                    captain2.SetActive(false);
                    captain3.SetActive(true);
                }
                else if (captainClicks == 2)
                {
                    captain2.SetActive(true);
                }
            }
            
             if (monitorInteract) //If done approaching main monitor
            {
                if (GameManager.gameManager.captainCard && GameManager.gameManager.firstCutscene != true) //If have the captain's card and have not seen the 1st cutscene before, trigger emergency lockdown cutscene
                {
                    monitorYes.SetActive(false);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Moves to the next scene
                    GameManager.gameManager.firstCutscene = true;
                    monitorInteract = false;
                }
                else
                {
                    monitorNo.SetActive(false);
                    monitorInteract = false;
                }
            }
        }
    }
}
