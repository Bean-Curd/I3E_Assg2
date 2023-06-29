/*
 * Author: Ashley Goh Yu Ting
 * Date: 29/06/2023
 * Description: I3E/STLD Assignment 2 - Cutscene 1 Door Down Movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1DoorDown : MonoBehaviour
{
    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static Cutscene1DoorDown instance;

    private void Awake()
    {
        instance = this;
    }

    void DoorOpened()
    {
        Destroy(gameObject);
    }

    public void Cutscene1DoorDownAnimation()
    {
        Debug.Log("Cutscene Door Down Opening");
        GetComponent<Animator>().SetBool("isTextDone", true);
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
