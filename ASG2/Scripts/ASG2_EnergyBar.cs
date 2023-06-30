/*
 * Author: Ashley Goh Yu Ting
 * Date: 17/06/2023
 * Description: I3E/STLD Assignment 2 - Energy Bar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //For the UI 
using TMPro; //For TextMeshPro

public class ASG2_EnergyBar : MonoBehaviour
{
    /// <summary>
    /// The slider for the energy bar
    /// </summary>
    public Slider energyBar;

    /// <summary>
    /// Set the maximum energy as 100 (10000 as in 100.00)
    /// </summary>
    private int maxEnergy = 10000;

    /// <summary>
    /// For the player's energy
    /// </summary>
    private int currentEnergy;

    /// <summary>
    /// Text for energy
    /// </summary>
    public TextMeshProUGUI energyText;

    /// <summary>
    /// Time between each stamina regen tick
    /// </summary>
    private WaitForSeconds regenTick = new WaitForSeconds(0.04f);

    /// <summary>
    /// For the player's energy regeneration 
    /// </summary>
    private Coroutine regen;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static ASG2_EnergyBar instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy; //Set energy to 100
        energyBar.maxValue = maxEnergy;
        energyBar.value = maxEnergy;
    }

    /// <summary>
    /// Changes energy bar when player sprints
    /// </summary>
    public void Sprint(int amount)
    {
        if (GameManager.gameManager.firstAidKit) //If first-aid kit collected, enable sprint
        {
            if (currentEnergy - amount >= 0) //If there is enough energy to sprint, deduct the energy required to sprint
            {
                Player.instance.moveSpeed = 8f; //Increase movement speed if player can sprint
                currentEnergy -= amount;
                energyBar.value = currentEnergy;

                if (regen != null)
                { //If using energy mid-regeneration, stop regeneration
                    StopCoroutine(regen);
                }

                regen = StartCoroutine(RegenEnergy());
            }
            else
            {
                Player.instance.moveSpeed = 4f; //Reset movement speed if player is out of energy
            }
        }
    }

    /// <summary>
    /// To regenerate energy when shift is not pressed
    /// </summary>
    private IEnumerator RegenEnergy()
    {
        yield return new WaitForSeconds(1); //Delay before energy is regenerated

        while(currentEnergy < maxEnergy) //While not at max energy, restore energy by 2 (200 as in 2.00)
        {
            currentEnergy += 200;
            energyBar.value = currentEnergy;
            yield return regenTick;
        }

        regen = null; //Once done, reset so player can continue to regenerate energy
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnergy <= 10000)
        {
            energyText.text = "" + (currentEnergy / 100); //Change the text to the number
        } else
        {
            energyText.text = "100"; //Change the text to the number
        }
    }
}
