/*
 * Author: Ashley Goh Yu Ting
 * Date: 24/06/2023
 * Description: I3E/STLD Assignment 2 - Player UI 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //For the UI 
using TMPro; //For TextMeshPro
using UnityEngine.SceneManagement; //For managing scenes

public class PlayerUI : MonoBehaviour
{
    /// <summary>
    /// The end
    /// </summary>
    public GameObject finalCutscene;

    /// <summary>
    /// Loading Screen
    /// </summary>
    public GameObject loadingScreen;

    /// <summary>
    /// Pause menu
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// Death menu
    /// </summary>
    public GameObject deathMenu;

    /// <summary>
    /// Void Screen
    /// </summary>
    public GameObject voidScreen;

    /// <summary>
    /// Interactible Object Text
    /// </summary>
    public GameObject interactibleText;

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
    public GameObject weaponDoor1;
    /// <summary>
    /// Text that appears for unlocked weapon door
    /// </summary>
    public GameObject weaponDoor2;


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
    /// If on hard mode, warn of heals left
    /// </summary>
    public GameObject healLimitWarning;
    /// <summary>
    /// Clicks for heal limit
    /// </summary>
    private int healLimitClicks;
    /// <summary>
    /// Text for heal limit
    /// </summary>
    public TextMeshProUGUI healLimitText;

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
    /// Starting the power puzzle text
    /// </summary>
    public GameObject powerPuzzle1;
    /// <summary>
    /// Power puzzle page
    /// </summary>
    public GameObject powerPuzzlePage;
    /// <summary>
    /// Text shown when puzzle completed
    /// </summary>
    public GameObject puzzleCompleted1;

    /// <summary>
    /// Cutscene 1 dialogue 1
    /// </summary>
    public GameObject cutscene11;
    /// <summary>
    /// Cutscene 1 dialogue 2
    /// </summary>
    public GameObject cutscene12;
    /// <summary>
    /// Cutscene 1 dialogue 3
    /// </summary>
    public GameObject cutscene13;
    /// <summary>
    /// Cutscene 1 dialogue 4
    /// </summary>
    public GameObject cutscene14;
    /// <summary>
    /// Clicks for Cutscene 1
    /// </summary>
    private int cutscene1Clicks;

    /// <summary>
    /// To hide after Cutscene 1 dialogue 1
    /// </summary>
    public bool afterCutscene1Interact = false;
    /// <summary>
    /// After Cutscene 1 dialogue 1
    /// </summary>
    public GameObject afterCutscene11;
    /// <summary>
    /// After Cutscene 1 dialogue 2
    /// </summary>
    public GameObject afterCutscene12;
    /// <summary>
    /// After Cutscene 1 dialogue 3
    /// </summary>
    public GameObject afterCutscene13;
    /// <summary>
    /// Clicks for after Cutscene 1
    /// </summary>
    public int afterCutscene1Clicks;

    /// <summary>
    /// When approaching suit section blocks
    /// </summary>
    public bool suitSectionBlockInteract = false;
    /// <summary>
    /// For suit section blocks
    /// </summary>
    public GameObject suitSectionBlock;

    /// <summary>
    /// When near suit
    /// </summary>
    public bool suitInteract = false;
    /// <summary>
    /// Approaching suit dialogue 1
    /// </summary>
    public GameObject suit1;
    /// <summary>
    /// Collecting suit dialogue 1
    /// </summary>
    public GameObject suitCollect1;
    /// <summary>
    /// Collected Suit UI
    /// </summary>
    public GameObject suitUI;

    /// <summary>
    /// When approaching before weapons area is unlocked blocks
    /// </summary>
    public bool beforeWeaponsBlockInteract = false;
    /// <summary>
    /// For before weapons blocks
    /// </summary>
    public GameObject beforeWeaponsBlock;

    /// <summary>
    /// When approaching Jose's body
    /// </summary>
    public bool joseInteract = false;
    /// <summary>
    /// Jose dialogue
    /// </summary>
    public GameObject jose1;

    /// <summary>
    /// When collected Weapons' card
    /// </summary>
    public bool weaponInteract = false;
    /// <summary>
    /// Weapons' card dialogue 1
    /// </summary>
    public GameObject weapon1;
    /// <summary>
    /// Weapons' card dialogue 2
    /// </summary>
    public GameObject weapon2;
    /// <summary>
    /// Clicks for Weapons' card 
    /// </summary>
    private int weaponClicks;
    /// <summary>
    /// Weapons' card kit symbol
    /// </summary>
    public GameObject weaponCard;

    /// <summary>
    /// When collected c4
    /// </summary>
    public bool c4Interact = false;
    /// <summary>
    /// C4 dialogue 1
    /// </summary>
    public GameObject c41;
    /// <summary>
    /// C4 symbol
    /// </summary>
    public GameObject c4;
    /// <summary>
    /// C4 symbol overlay
    /// </summary>
    public GameObject c4Overlay;

    /// <summary>
    /// When approaching escape pod
    /// </summary>
    public bool escapePodInteract = false;
    /// <summary>
    /// When you didn't use the c4 yet
    /// </summary>
    public GameObject escapePodNo;
    /// <summary>
    /// When you used the c4
    /// </summary>
    public GameObject escapePodYes;

    /// <summary>
    /// When approaching exit/main hatch terminal
    /// </summary>
    public bool exitInteract = false;
    /// <summary>
    /// When c4 not obtained
    /// </summary>
    public GameObject exitNo;
    /// <summary>
    /// When c4 obtained
    /// </summary>
    public GameObject exitYes;

    /// <summary>
    /// When approaching rocks
    /// </summary>
    public bool rockInteract = false;
    /// <summary>
    /// When you have the c4
    /// </summary>
    public GameObject rockYes;

    /// <summary>
    /// Cutscene 2 dialogue 1
    /// </summary>
    public GameObject cutscene21;

    /// <summary>
    /// To hide after Cutscene 2 dialogue 1
    /// </summary>
    public bool afterCutscene2Interact = false;
    /// <summary>
    /// After Cutscene 2 dialogue 1
    /// </summary>
    public GameObject afterCutscene21;

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
        introClicks = 1;
        firstAidClicks = 1;
        healLimitClicks = 1;
        captainClicks = 1;
        cutscene1Clicks = 1;
        afterCutscene1Clicks = 1;
        weaponClicks = 1;
        introDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.dead) //If currently dead, show death menu
        {
            voidScreen.SetActive(true);
            deathMenu.SetActive(true);
        }

        if (GameManager.gameManager.pause) //If currently paused, show pause menu
        {
            pauseMenu.SetActive(true);
        }
        else if (GameManager.gameManager.pause != true) //If not paused, hide paused menu
        {
            pauseMenu.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0)) //If left click is pressed, change dialogue
        {
            if (GameManager.gameManager.pause != true) //If not paused, can change text
            {
                if (GameManager.gameManager.secondCutscene && SceneManager.GetActiveScene().buildIndex == 3) //For dialogue after scene change back to external area after cutscene 2
                {
                    afterCutscene21.SetActive(false);
                    afterCutscene2Interact = true;
                }

                if (GameManager.gameManager.secondCutscene && SceneManager.GetActiveScene().buildIndex == 4) //For second cutscene dialogue after scene change to cutscene 2 scene
                {
                    cutscene21.SetActive(false);
                    voidScreen.SetActive(false);
                    Cutscene2Rocks.instance.Cutscene2RocksSinking();
                }

                if (GameManager.gameManager.firstCutscene && SceneManager.GetActiveScene().buildIndex == 1 && GameManager.gameManager.suitObtained != true) //For dialogue after scene change back to spaceship after cutscene 1
                {
                    afterCutscene11.SetActive(false);
                    GameManager.gameManager.suitSectionStart = false;
                    afterCutscene1Interact = true;
                    afterCutscene1Clicks += 1;

                    if (afterCutscene1Clicks > 3 && GameManager.gameManager.suitObtained != true)
                    {
                        afterCutscene13.SetActive(false);
                        Audio.instance.indoorAmbience.Stop();
                        Audio.instance.wind.Play();
                        GameManager.gameManager.suitSectionStart = true;
                    }
                    else if (afterCutscene1Clicks == 3)
                    {
                        afterCutscene12.SetActive(false);
                        afterCutscene13.SetActive(true);
                    }
                    else if (afterCutscene1Clicks == 2)
                    {
                        PowerPuzzle.instance.PuzzleStart(); //Reset puzzle
                        afterCutscene12.SetActive(true);
                    }
                }

                if (GameManager.gameManager.firstCutscene && SceneManager.GetActiveScene().buildIndex == 2) //For first cutscene dialogue after scene change to cutscene 1 scene
                {
                    cutscene11.SetActive(false);
                    cutscene1Clicks += 1;

                    if (cutscene1Clicks > 4)
                    {
                        cutscene14.SetActive(false);
                        voidScreen.SetActive(false);
                        Cutscene1DoorDown.instance.Cutscene1DoorDownAnimation();
                        Cutscene1DoorUp.instance.Cutscene1DoorUpAnimation();
                    }
                    else if (cutscene1Clicks == 4)
                    {
                        cutscene13.SetActive(false);
                        cutscene14.SetActive(true);
                    }
                    else if (cutscene1Clicks == 3)
                    {
                        cutscene12.SetActive(false);
                        cutscene13.SetActive(true);
                    }
                    else if (cutscene1Clicks == 2)
                    {
                        cutscene12.SetActive(true);
                    }
                }

                if (GameManager.gameManager.firstEnter && SceneManager.GetActiveScene().buildIndex == 1) //On first time entering spaceship scene,
                {
                    introClicks += 1;

                    if (introClicks > 3)
                    {
                        intro3.SetActive(false);
                        GameManager.gameManager.firstEnter = false;
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

                if (scottInteract) //If done approaching scott's body
                {
                    scott1.SetActive(false);
                }

                if (emergencyDoorInteract) //If approaching locked doors
                {
                    emergency1.SetActive(false);
                }

                if (weaponDoorInteract) //If approaching weapon door
                {
                    weaponDoor1.SetActive(false);
                    weaponDoor2.SetActive(false);
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
                    healingNo.SetActive(false);
                    healingYes.SetActive(false);
                    healLimitClicks += 1;

                    if (GameManager.gameManager.healLimit) //If there is a heal limit, show warning
                    {
                        healLimitText.text = "[" + GameManager.gameManager.healCount + " Heals Left]"; //Change the text to the number

                        if (healLimitClicks >= 1 && (healLimitClicks % 2) == 1) //If odd number that is not 1
                        {
                            healLimitWarning.SetActive(false);
                            healingInteract = false;
                        }
                        else if ((healLimitClicks%2) == 0) //If even number
                        {
                            healLimitWarning.SetActive(true);
                        }

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
                    if (GameManager.gameManager.suitSectionStart && GameManager.gameManager.inPowerPuzzle != true) //If in suit section and not in puzzle, Pull up puzzle
                    {
                        powerPuzzle1.SetActive(false);
                        powerPuzzlePage.SetActive(true);
                        GameManager.gameManager.inPowerPuzzle = true;
                        monitorInteract = false;
                    }
                    else if (GameManager.gameManager.captainCard && GameManager.gameManager.firstCutscene != true) //If have the captain's card and have not seen the 1st cutscene before, trigger emergency lockdown cutscene
                    {
                        monitorYes.SetActive(false);
                        monitorInteract = false;
                        GameManager.gameManager.LoadingScreen();
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Moves to the next scene
                    }
                    else if (GameManager.gameManager.captainCard != true)
                    {
                        monitorNo.SetActive(false);
                        monitorInteract = false;
                    }
                }

                if (suitSectionBlockInteract) //If done approaching suit section block
                {
                    suitSectionBlock.SetActive(false);
                }

                if (suitInteract) //If done approaching suit
                {
                    suit1.SetActive(false);
                    suitCollect1.SetActive(false);
                }

                if (GameManager.gameManager.powerPuzzleDone) //If done with power puzzle
                {
                    puzzleCompleted1.SetActive(false);
                }

                if (beforeWeaponsBlockInteract) //If done approaching before weapons block
                {
                    beforeWeaponsBlock.SetActive(false);
                }

                if (joseInteract) //If done approaching Jose's body
                {
                    jose1.SetActive(false);
                }

                if (weaponInteract) //If picked up Weapons' card
                {
                    weapon1.SetActive(false);
                    weaponClicks += 1;

                    if (weaponClicks > 2)
                    {
                        weapon2.SetActive(false);
                    }
                    else if (weaponClicks == 2)
                    {
                        weapon2.SetActive(true);
                    }
                }

                if (c4Interact) //If picked up C4
                {
                    c41.SetActive(false);
                }

                if (escapePodInteract) //If done approaching escape pod
                {
                    if (GameManager.gameManager.secondCutscene && escapePodNo.activeSelf != true) //If used c4, allow exit
                    {
                        escapePodYes.SetActive(false);
                        escapePodInteract = false;
                        GameManager.gameManager.LoadingScreen();

                        Debug.Log("Final Cutscene");

                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4); //Moves to the final cutscene
                    }
                    else if (GameManager.gameManager.secondCutscene != true) //If not used c4, says escape pod is blocked
                    {
                        escapePodNo.SetActive(false);
                        escapePodInteract = false;
                    }
                }

                if (exitInteract) //If done approaching exit/main hatch terminal
                {
                    if (GameManager.gameManager.c4) //If obtained c4, allow exit
                    {
                        exitYes.SetActive(false);
                        exitInteract = false;
                        GameManager.gameManager.LoadingScreen();

                        Debug.Log("Exiting Ship");
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //Moves to the next next scene
                    }
                    else if (GameManager.gameManager.c4 != true) //If not obtained c4, deny exit
                    {
                        exitNo.SetActive(false);
                        exitInteract = false;
                    }
                }

                if (rockInteract) //If done approaching pile of rocks
                {
                    rockYes.SetActive(false);
                    rockInteract = false;
                    GameManager.gameManager.LoadingScreen();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Moves to the next scene
                }
            }
        }
    }
}
