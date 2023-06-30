/*
 * Author: Ashley Goh Yu Ting
 * Date: 30/06/2023
 * Description: I3E/STLD Assignment 2 - Suit Section Timer
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //For the UI 
using TMPro; //For TextMeshPro

public class SuitSectionTimer : MonoBehaviour
{
    /// <summary>
    /// Timer text for suit section
    /// </summary>
    public GameObject suitSectionTimerText;

    /// <summary>
    /// Text for timer
    /// </summary>
    public TextMeshProUGUI timerText;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static SuitSectionTimer instance;

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
        if (GameManager.gameManager.timerTemp > 0)
        {
            timerText.text = "" + GameManager.gameManager.timerTemp; //Change the text to the number
        }
        else
        {
            timerText.text = "0"; //Change the text to the number
        }
    }
}
