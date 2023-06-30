/*
 * Author: Ashley Goh Yu Ting
 * Date: 30/06/2023
 * Description: I3E/STLD Assignment 2 - Player Death
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static PlayerDeath instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// What happens after player dies
    /// </summary>
    void KillPlayer() 
    {
        Debug.Log("Kill Player");

        GameManager.gameManager.suitSectionStart = false;
        GameManager.gameManager.dead = true;
        ASG2_HealthBar.instance.Damage(-10000); //Restore HP so doesn't trigger player death again
    }

    /// <summary>
    /// Play the player death animation
    /// </summary>
    public void PlayerDeathSequence()
    {
        Debug.Log("Oof");
        GetComponent<Animator>().enabled = true;
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
