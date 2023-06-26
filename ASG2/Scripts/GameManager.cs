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
    /// Player prefab
    /// </summary>
    public GameObject playerPrefab;

    /// <summary>
    /// Current player
    /// </summary>
    private GameObject activePlayer;

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
    /// First time entering the spaceship
    /// </summary>
    private bool firstEnter;

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
    /// For normal mode variables
    /// </summary>
    public void NormalMode(bool active)
    {
        if (active)
        {
            windTick = 100; //100 as in 1.00
            windTimer = 300; 
            healLimit = false;

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
        SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

        activePlayer = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// Spawns the player when the scene is loaded
    /// </summary>
    private void SpawnPlayerOnSceneLoad(Scene currentScene, Scene nextScene)
    {
        spawn1 = GameObject.Find("Spawn1(Control)");

        buildIndex = nextScene.buildIndex;

        if (spawn1 != null) //If there is no player, spawn a player
        {
            spawn1Location = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);

            Debug.Log("New player");
        }

        else if (activePlayer == null && buildIndex != 0)
        {
            activePlayer = Instantiate(playerPrefab, spawn1Location, Quaternion.identity);

            Debug.Log("Active player spawned");
        }

        else if (buildIndex == 0 || buildIndex == 1)
        {
            Destroy(activePlayer);
            Debug.Log("Player destroyed");
        }

        else
        {
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        firstEnter = true;
        firstAidKit = false;
        captainCard = false;
        weaponCard = false;
        c4 = false;
}

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && firstAidKit != true && firstEnter) //If loading into the spaceship for the first time (without the First-Aid Kit), reduce HP to 40
        {
            ASG2_HealthBar.instance.Damage(6000);
            firstEnter = false;

            Debug.Log("HP to 40");
        }
    }
}
