/*
 * Author: Ashley Goh Yu Ting
 * Date: 20/06/2023
 * Description: I3E/STLD Assignment 2 - Game Manager
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //For managing scenes

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Player prefab
    /// </summary>
    public GameObject playerPrefab;

    /// <summary>
    /// Current player
    /// </summary>
    private Player activePlayer;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this) //If there is another game manager, destroy this one
        {
            Destroy(gameObject);
        } 
        else
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;
            instance = this;
        }
    }

    private void SpawnPlayerOnSceneLoad(Scene currentScene, Scene nextScene)
    {
        if(activePlayer == null) //If there is no player, spawn a player
        {
            GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            activePlayer = newPlayer.GetComponent<Player>();
        }
        else
        {
            PlayerSpawnSpot playerSpot = FindObjectOfType<PlayerSpawnSpot>();
            activePlayer.transform.position = playerSpot.transform.position;
            activePlayer.transform.rotation = playerSpot.transform.rotation;
        }
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
