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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
