/*
 * Author: Ashley Goh Yu Ting
 * Date: 29/06/2023
 * Description: I3E/STLD Assignment 2 - Block the Living Quarters/Escape Pod during Suit Section
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitSectionBlock : MonoBehaviour
{
    /// <summary>
    /// For suit section living block
    /// </summary>
    public GameObject livingSuitBlock;
    /// <summary>
    /// For suit section escape block
    /// </summary>
    public GameObject escapeSuitBlock;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static SuitSectionBlock instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// When to activate the block
    /// </summary>
    public void TriggerBlock()
    {
        livingSuitBlock.SetActive(true);
        escapeSuitBlock.SetActive(true);
    }

    /// <summary>
    /// When to destroy the block
    /// </summary>
    public void DestroyBlock()
    {
        Destroy(livingSuitBlock);
        Destroy(escapeSuitBlock);
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
