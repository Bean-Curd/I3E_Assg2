/*
 * Author: Ashley Goh Yu Ting
 * Date: 18/06/2023
 * Description: I3E/STLD Assignment 2 - Health Bar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //For the UI 
using TMPro; //For TextMeshPro

public class ASG2_HealthBar : MonoBehaviour
{
    /// <summary>
    /// The slider for the health bar
    /// </summary>
    public Slider healthBar;

    /// <summary>
    /// Set the maximum health as 100 (10000 as in 100.00)
    /// </summary>
    private int maxHealth = 10000;

    /// <summary>
    /// For the player's health
    /// </summary>
    public int currentHealth;

    /// <summary>
    /// Text for health
    /// </summary>
    public TextMeshProUGUI healthText;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static ASG2_HealthBar instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //Set health to 100
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    /// <summary>
    /// Change health bar when player takes damage/negative for heals
    /// </summary>
    public void Damage(int amount)
    {
        if ((currentHealth - amount) <= 10000 && (currentHealth - amount) > 0) //If there is enough health, deduct the amount
        {
            Debug.Log("HealthBar deducting");
            currentHealth -= amount;
            healthBar.value = currentHealth;
        }
        else if ((currentHealth - amount) > 10000) //If more than 100 HP, limit to 100
        {
            Debug.Log("HealthBar overheal");
            currentHealth = 10000;
            healthBar.value = currentHealth;
        }
        else if ((currentHealth - amount) <= 0) //If not enough health left, change health bar to 0
        {
            Debug.Log("HealthBar not enough");
            currentHealth = 0; 
            healthBar.value = currentHealth;
            Audio.instance.death.Play();
            PlayerDeath.instance.PlayerDeathSequence();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 10000)
        {
            healthText.text = "" + (currentHealth / 100); //Change the text to the number
        } else
        {
            healthText.text = "100"; //Change the text to the number
        }
    }
}
