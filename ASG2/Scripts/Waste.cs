/*
 * Author: Ashley Goh Yu Ting
 * Date: 02/07/2023
 * Description: I3E/STLD Assignment 2 - Waste
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour
{
    /// <summary>
    /// Is the player in waste
    /// </summary>
    public bool inWaste = false;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static Waste instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// What happens when player is on waste
    /// </summary>
    void OnTriggerStay()
    {
        if (GameManager.gameManager.disableWasteDamage != true)
        {
            Audio.instance.damage.Play();
            ASG2_HealthBar.instance.Damage(100); //Lose HP
        }

        inWaste = true;
    }

    /// <summary>
    /// What happens when player exit waste
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        inWaste = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
