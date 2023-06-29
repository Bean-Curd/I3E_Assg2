/*
 * Author: Ashley Goh Yu Ting
 * Date: 29/06/2023
 * Description: I3E/STLD Assignment 2 - On normal lights
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOn : MonoBehaviour
{
    /// <summary>
    /// Lights in 1F stair
    /// </summary>
    public GameObject lights1;
    /// <summary>
    /// Lights in 2F stair
    /// </summary>
    public GameObject lights2;
    /// <summary>
    /// Lights in 3F stair
    /// </summary>
    public GameObject lights3;
    /// <summary>
    /// Lights in storage
    /// </summary>
    public GameObject lights4;
    /// <summary>
    /// Lights in engine
    /// </summary>
    public GameObject lights5;
    /// <summary>
    /// Lights in medical
    /// </summary>
    public GameObject lights6;
    /// <summary>
    /// Lights in control room
    /// </summary>
    public GameObject lights7;
    /// <summary>
    /// Lights in 2F corridors
    /// </summary>
    public GameObject lights8;
    /// <summary>
    /// Lights in 3F corridors
    /// </summary>
    public GameObject lights9;


    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static LightsOn instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// To on the normal lights
    /// </summary>
    public void Activate()
    {
        lights1.SetActive(true);
        lights2.SetActive(true);
        lights3.SetActive(true);
        lights4.SetActive(true);
        lights5.SetActive(true);
        lights6.SetActive(true);
        lights7.SetActive(true);
        lights8.SetActive(true);
        lights9.SetActive(true);
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
