/*
 * Author: Ashley Goh Yu Ting
 * Date: 20/06/2023
 * Description: I3E/STLD Assignment 2 - Game Manager
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //For managing scenes
using UnityEngine.UI; //For the UI 
using TMPro; //For TextMeshPro

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static GameManager gameManager { get; private set; }

    /// <summary>
    /// Pause the game
    /// </summary>
    public bool pause;

    /// <summary>
    /// Player prefab
    /// </summary>
    public GameObject playerPrefab;

    /// <summary>
    /// Canvas prefab
    /// </summary>
    public GameObject canvasPrefab;

    /// <summary>
    /// Current player
    /// </summary>
    private GameObject activePlayer;

    /// <summary>
    /// Current canvas
    /// </summary>
    private GameObject activeCanvas;

    /// <summary>
    /// Player spawn 1 (Control room)
    /// </summary>
    private GameObject spawn1;

    /// <summary>
    /// Spawn 1 Location
    /// </summary>
    private Vector3 spawn1Location;

    /// <summary>
    /// Scene
    /// </summary>
    private Scene scene;

    /// <summary>
    /// Build Index of the scene
    /// </summary>
    private int buildIndex;

    /// <summary>
    /// Game Object Array to destroy doors 
    /// </summary>
    private GameObject[] emergencyDoorArray;
    /// <summary>
    /// Game Object Array to change red lights
    /// </summary>
    private GameObject[] redLightsArray;

    /// <summary>
    /// First time entering the spaceship for deducting HP
    /// </summary>
    public bool initialDamage;
    /// <summary>
    /// First time entering the spaceship for initial text
    /// </summary>
    public bool firstEnter;
    /// <summary>
    /// First time seeing Emergency Cutscene (Cutscene1)
    /// </summary>
    public bool firstCutscene;
    /// <summary>
    /// Starting suit section
    /// </summary>
    public bool suitSectionStart;
    /// <summary>
    /// First time seeing C4 Cutscene (Cutscene2)
    /// </summary>
    public bool secondCutscene;


    // For difficulty variables
    /// <summary>
    ///Damage wind does over time (Normal - 5HP/5sec, Hard 10HP/5sec)
    /// </summary>
    public int windTick; 
    /// <summary>
    /// Time limit (Normal - 5 mins, Hard - 2.5 mins)
    /// </summary>
    public int windTimer; 
    /// <summary>
    /// Limits heals at 5 times a playthrough
    /// </summary>
    public bool healLimit; 

    //Items obtained
    /// <summary>
    /// First-Aid Kit item
    /// </summary>
    public bool firstAidKit;
    /// <summary>
    /// Captain's card item
    /// </summary>
    public bool captainCard;
    /// <summary>
    /// Weapon's Access Card item
    /// </summary>
    public bool weaponCard;
    /// <summary>
    /// C4 item
    /// </summary>
    public bool c4;

    /// <summary>
    /// For the loading screen
    /// </summary>
    private Coroutine loadingScreenWait;

    /// <summary>
    /// For normal mode variables
    /// </summary>
    public void NormalMode(bool active)
    {
        if (active)
        {
            windTick = 100; //100 as in 1.00
            windTimer = 300; 
            healLimit = false;

            pause = false;
            initialDamage = false;
            firstEnter = true;
            firstCutscene = false;
            suitSectionStart = false;
            secondCutscene = false;
            firstAidKit = false;
            captainCard = false;
            weaponCard = false;
            c4 = false;

            Debug.Log("Normal");
        }

    }

    /// <summary>
    /// For hard mode variables
    /// </summary>
    public void HardMode(bool active)
    {
        if (active)
        {
            windTick = 200; //200 as in 2.00
            windTimer = 150;
            healLimit = true;

            pause = false;
            initialDamage = false;
            firstEnter = true;
            firstCutscene = false;
            suitSectionStart = false;
            secondCutscene = false;
            firstAidKit = false;
            captainCard = false;
            weaponCard = false;
            c4 = false;

            Debug.Log("Hard");
        }

    }

    private void Awake()
    {
        if (gameManager != null && gameManager != this) //If there is another game manager, destroy this one
        {
            Destroy(gameObject);

            Debug.Log("GameManager destroyed");

            return;
            
        } 
        else
        {
            gameManager = this;

            Debug.Log("GameManager not destroyed");
        }

        DontDestroyOnLoad(gameObject);
        activePlayer = GameObject.FindGameObjectWithTag("Player");
        activeCanvas = GameObject.FindGameObjectWithTag("Canvas");

        spawn1 = GameObject.FindGameObjectWithTag("Spawn1");
        spawn1Location = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);

        SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;
    }

    /// <summary>
    /// Spawns the player when the scene is loaded
    /// </summary>
    private void SpawnPlayerOnSceneLoad(Scene currentScene, Scene nextScene)
    {
        buildIndex = nextScene.buildIndex;
        Debug.Log(activePlayer);

        if (activePlayer != null) //If there is a player originally in the scene, kill it
        {
            Destroy(activePlayer);
            Destroy(activeCanvas);
            Debug.Log("Original player destroyed: " + activePlayer);
            activePlayer = null;
            activeCanvas = null;
        }

        if (activePlayer == null && buildIndex != 0) //If there is no player and not in start menu, spawn player prefab at spawn point
        {
            if (buildIndex == 2) //In specific scenes, have specific rotations
            {
                activePlayer = Instantiate(playerPrefab, spawn1Location, Quaternion.Euler(new Vector3(0, 150, 0)));
            }
            else if (buildIndex == 1) //In specific scenes, have specific rotations
            {
                activePlayer = Instantiate(playerPrefab, spawn1Location, Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            else
            {
                //activePlayer = Instantiate(playerPrefab, spawn1Location, Quaternion.identity);
            }

            activeCanvas = Instantiate(canvasPrefab);
            Debug.Log("Active player spawned: " + activePlayer);
        } 

        /*if (spawn1 != null) //If there is no spawn point, add it
        {
            spawn1Location = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);

            Debug.Log("New spawn");
        }

        if (activePlayer == null && buildIndex != 0) //If there is no player and not in start menu, spawn player prefab at spawn point
        {
            Debug.Log(spawn1Location);
            activePlayer = Instantiate(playerPrefab, spawn1Location, Quaternion.identity);

            Debug.Log("Active player spawned");
        }

        else if (activePlayer == null && buildIndex == 0 || buildIndex == 1)
        {
            Destroy(activePlayer);
            Debug.Log("Player destroyed");
        }*/

        else
        {
            return;
        }
    }

    // Start is called before the first frame updates
    void Start()
    {
        pause = false;
        initialDamage = false;
        firstEnter = true;
        firstCutscene = false;
        suitSectionStart = false;
        secondCutscene = false;
        firstAidKit = false;
        captainCard = false;
        weaponCard = false;
        c4 = false;
    }


    /// <summary>
    /// Delay new sceme load for 3 seconds
    /// </summary>
    IEnumerator WaitForLoading()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Delay 3 second");

        loadingScreenWait = null;
    }

    /// <summary>
    /// Loading Screen between scenes
    /// </summary>
    public void LoadingScreen()
    {
        PlayerUI.instance.loadingScreen.SetActive(true);
        PlayerUI.instance.voidScreen.SetActive(true);

        loadingScreenWait = StartCoroutine(WaitForLoading());
    }

    /// <summary>
    /// Destroy emergency locked doors
    /// </summary>
    void EmergencyLockdownLifted()
    {
        emergencyDoorArray = GameObject.FindGameObjectsWithTag("EmergencyDoor");

        foreach (GameObject gameObject in emergencyDoorArray)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Change red lights to white
    /// </summary>
    void ChangeRedLights()
    {
        redLightsArray = GameObject.FindGameObjectsWithTag("RedLight");

        foreach (GameObject gameObject in redLightsArray)
        {
            Destroy(gameObject);
        }

        LightsOn.instance.Activate();

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && firstAidKit != true && initialDamage != true) //If loading into the spaceship for the first time (without the First-Aid Kit), reduce HP to 40
        {
            ASG2_HealthBar.instance.Damage(6000);
            PlayerUI.instance.intro1.SetActive(true); //Show 1st dialogue
            initialDamage = true;

            Debug.Log("HP to 40");
        }

        if (pause) //If currently paused, stop time
        {
            Time.timeScale = 0;
            Player.instance.rotationSpeed = 0.00f;
        } 
        else if (pause != true) //If not paused, time flows normally
        {
            Time.timeScale = 1;
            Player.instance.rotationSpeed = 0.25f;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2) //If in cutscene, stop player movement
        {
            Player.instance.rotationSpeed = 0.00f;
            Player.instance.moveSpeed = 0.00f;
        }
        else if (SceneManager.GetActiveScene().buildIndex != 2) //If out of cutscene, stop player movement 
        {
            Player.instance.rotationSpeed = 0.25f;
            Player.instance.moveSpeed = 0.11f;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 && firstCutscene != true) //When entering 1st cutscene
        {
            Debug.Log("Starting Cutscene 1: Emergency Lockdown Lifted");
            PlayerUI.instance.voidScreen.SetActive(true);
            PlayerUI.instance.cutscene11.SetActive(true);
            firstCutscene = true;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && firstCutscene && PlayerUI.instance.afterCutscene1Interact != true) //When entering spaceship after 1st cutscene
        {
            Debug.Log("Cutscene 1: Emergency Lockdown Lifted End");
            EmergencyLockdownLifted();
            ChangeRedLights();
            SuitSectionBlock.instance.TriggerBlock();
            PlayerUI.instance.afterCutscene11.SetActive(true);
        }
    }
}
