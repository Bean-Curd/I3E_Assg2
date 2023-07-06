/*
 * Author: Ashley Goh Yu Ting
 * Date: 02/07/2023
 * Description: I3E/STLD Assignment 2 - Audio Effects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //For managing scenes

public class Audio : MonoBehaviour
{
    /// <summary>
    /// For IndoorBGM
    /// </summary>
    public AudioSource indoorAmbience;
    /// <summary>
    /// For OutdoorBGM
    /// </summary>
    public AudioSource outdoorAmbience;
    /// <summary>
    /// For Suit section wind
    /// </summary>
    public AudioSource wind;

    /// <summary>
    /// For UI button press
    /// </summary>
    public AudioSource button;
    /// <summary>
    /// For walking
    /// </summary>
    public AudioSource walk;
    /// <summary>
    /// For jump
    /// </summary>
    public AudioSource jump;
    /// <summary>
    /// For power puzzle rotation
    /// </summary>
    public AudioSource turningPuzzle;
    /// <summary>
    /// For power puzzle completion
    /// </summary>
    public AudioSource puzzleCompleted;
    /// <summary>
    /// For door opening
    /// </summary>
    public AudioSource door;
    /// <summary>
    /// For collectable items (For first-aid kit, captain card, weapons card, c4)
    /// </summary>
    public AudioSource itemCollect;
    /// <summary>
    /// For interactable items (For monitor, suit, escape pod, main hatch door terminal, main hatch door)
    /// </summary>
    public AudioSource itemInteract;
    /// <summary>
    /// For placing down C4
    /// </summary>
    public AudioSource itemPlaced;
    /// <summary>
    /// For recovering HP
    /// </summary>
    public AudioSource heal;
    /// <summary>
    /// For losing HP
    /// </summary>
    public AudioSource damage;
    /// <summary>
    /// For player die
    /// </summary>
    public AudioSource death;
    /// <summary>
    /// For c4 triggered in cutscene 2
    /// </summary>
    public AudioSource bomb;
    /// <summary>
    /// For escape pod launch
    /// </summary>
    public AudioSource launch;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static Audio instance;

    private void Awake()
    {
        instance = this;
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
