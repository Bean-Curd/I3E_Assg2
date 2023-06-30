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
    /// Player is dead
    /// </summary>
    public bool dead;

    /// <summary>
    /// What to do when player respawns
    /// </summary>
    public bool respawn;

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
    /// Delay between hp loss
    /// </summary>
    private bool hpTickDelay;
    /// <summary>
    /// Delay between seconds
    /// </summary>
    private bool timerTickDelay;
    /// <summary>
    /// Float to hold the timer value
    /// </summary>
    public float timerTemp;
    /// <summary>
    /// Suit power puzzle
    /// </summary>
    public bool powerPuzzle;
    /// <summary>
    /// First time seeing C4 Cutscene (Cutscene2)
    /// </summary>
    public bool secondCutscene;


    // For difficulty variables
    /// <summary>
    /// Is damage wind does over time increased (Normal - 1HP/2sec, Hard 1HP/sec)
    /// </summary>
    public bool windTick; 
    /// <summary>
    /// Time limit (Normal - 5 mins, Hard - 3 mins)
    /// </summary>
    public float windTimer; 
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
    /// For the hp decay in suit section
    /// </summary>
    private Coroutine hpDecay;
    /// <summary>
    /// For the timer in suit section
    /// </summary>
    private Coroutine suitTimer;

    /// <summary>
    /// For normal mode variables
    /// </summary>
    public void NormalMode(bool active)
    {
        if (active)
        {
            windTick = false; //Not increased
            windTimer = 300f; 
            healLimit = false;

            pause = false;
            dead = false;
            respawn = false;
            initialDamage = false;
            firstEnter = true;
            firstCutscene = false;
            suitSectionStart = false;
            hpTickDelay = false;
            timerTickDelay = false;
            powerPuzzle = false;
            secondCutscene = false;
            firstAidKit = false;
            captainCard = false;
            weaponCard = false;
            c4 = false;

            timerTemp = windTimer;

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
            windTick = true; //Increased
            windTimer = 180f;
            healLimit = true;

            pause = false;
            dead = false;
            respawn = false;
            initialDamage = false;
            firstEnter = true;
            firstCutscene = false;
            suitSectionStart = false;
            hpTickDelay = false;
            timerTickDelay = false;
            powerPuzzle = false;
            secondCutscene = false;
            firstAidKit = false;
            captainCard = false;
            weaponCard = false;
            c4 = false;

            timerTemp = windTimer;

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

    /// <summary>
    /// Loading Screen between scenes
    /// </summary>
    public void LoadingScreen()
    {
        if (dead) //If dead hide the player death page
        {
            PlayerUI.instance.deathMenu.SetActive(false);
            dead = false;
        }

        PlayerUI.instance.loadingScreen.SetActive(true);
        PlayerUI.instance.voidScreen.SetActive(true);

        loadingScreenWait = StartCoroutine(WaitForLoading());
    }

    /// <summary>
    /// Spawns the player after death
    /// </summary>
    private void RespawnPlayer()
    {
        PlayerUI.instance.deathMenu.SetActive(false);
        ASG2_HealthBar.instance.Damage(-10000); //Restore HP

        LoadingScreen();

        Destroy(activePlayer); //Destroy player and canvas, respawn them at spawn location
        Destroy(activeCanvas);
        Debug.Log("Original player destroyed: " + activePlayer);
        activePlayer = null;
        activeCanvas = null;

        if (buildIndex == 1) //In specific scenes, have specific rotations/resets
        {
            activePlayer = Instantiate(playerPrefab, spawn1Location, Quaternion.Euler(new Vector3(0, 180, 0)));
            suitSectionStart = true;
            hpTickDelay = false;
            timerTickDelay = false;
            timerTemp = windTimer;
        }

        activeCanvas = Instantiate(canvasPrefab);
        Debug.Log("Active player spawned: " + activePlayer);
    }

    // Start is called before the first frame updates
    void Start()
    {
        pause = false;
        dead = false;
        respawn = false;
        initialDamage = false;
        firstEnter = true;
        firstCutscene = false;
        suitSectionStart = false;
        hpTickDelay = false;
        timerTickDelay = false;
        powerPuzzle = false;
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
    /// Take 1 HP every second
    /// </summary>
    IEnumerator WindTick()
    {
        if (windTick) //If wind damage increased
        {
            yield return new WaitForSeconds(1f);

            ASG2_HealthBar.instance.Damage(100); //100 as in 1.00

        }
        else //If wind damage not increased
        {
            yield return new WaitForSeconds(2f);

            ASG2_HealthBar.instance.Damage(100); //100 as in 1.00
        }

        hpTickDelay = false;
        Debug.Log("1 HP lost");
        hpDecay = null;
    }

    /// <summary>
    /// Timer -1 every second
    /// </summary>
    IEnumerator SuitTimer()
    {
        if (timerTemp > 0) //If there is time left, deduct 1 sec
        {
            yield return new WaitForSeconds(1f);

            timerTemp -= 1f;
        }
        else //If there is no time left, kill player
        {
            ASG2_HealthBar.instance.Damage(10000); //10000 as in 100.00
            Debug.Log("Time's Up");
        }

        timerTickDelay = false;
        suitTimer = null;
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

        if (respawn) //If respawning, kill player and respawn at spawn point
        {
            Debug.Log("Respawning Player");
            RespawnPlayer();
            respawn = false;
        }

        if (dead) //If currently dead, stop time
        {
            Time.timeScale = 0;
            Player.instance.rotationSpeed = 0.00f;
        }
        else if (pause) //If currently paused, stop time
        {
            Time.timeScale = 0;
            Player.instance.rotationSpeed = 0.00f;
        } 
        else if (pause != true) //If not paused or dead, time flows normally
        {
            Time.timeScale = 1;
            Player.instance.rotationSpeed = 0.25f;
            Player.instance.moveSpeed = 4.0f;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 ) //If in cutscene, stop player movement
        {
            Player.instance.rotationSpeed = 0.00f;
            Player.instance.moveSpeed = 0.00f;
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

        if (firstCutscene && SceneManager.GetActiveScene().buildIndex == 1 && PlayerUI.instance.afterCutscene1Clicks <= 3)
        {
            Debug.Log("Lock player movement");
            Time.timeScale = 0;
            Player.instance.rotationSpeed = 0.00f; //Stop player from moving to cheat the suit section
            Player.instance.moveSpeed = 0.00f;
        }

        if (suitSectionStart && hpTickDelay != true && timerTickDelay != true) //When in suit section, set HP decay and timer
        {
            hpTickDelay = true; //So update() does not run windtick() every frame 
            timerTickDelay = true;

            SuitSectionTimer.instance.suitSectionTimerText.SetActive(true);

            hpDecay = StartCoroutine(WindTick());
            suitTimer = StartCoroutine(SuitTimer());
        }
    }
}
