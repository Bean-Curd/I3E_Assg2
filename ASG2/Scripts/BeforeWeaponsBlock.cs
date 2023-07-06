/*
 * Author: Ashley Goh Yu Ting
 * Date: 01/07/2023
 * Description: I3E/STLD Assignment 2 - Block the Main Hatch/Escape Pod before Weapons Card obtained
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeWeaponsBlock : MonoBehaviour
{
    /// <summary>
    /// For escape pods block
    /// </summary>
    public GameObject escapeBlock;
    /// <summary>
    /// For main hatch block
    /// </summary>
    public GameObject mainHatchBlock;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static BeforeWeaponsBlock instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// When to activate the block
    /// </summary>
    public void TriggerBlock()
    {
        escapeBlock.SetActive(true);
        mainHatchBlock.SetActive(true);
    }

    /// <summary>
    /// When to destroy the block
    /// </summary>
    public void DestroyBlock()
    {
        Destroy(escapeBlock);
        Destroy(mainHatchBlock);
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
