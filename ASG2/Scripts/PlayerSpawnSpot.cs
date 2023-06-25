/*
 * Author: Ashley Goh Yu Ting
 * Date: 24/06/2023
 * Description: I3E/STLD Assignment 2 - Player Spawn Location (Ship Control Room)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnSpot : MonoBehaviour
{
    public static PlayerSpawnSpot instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
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
