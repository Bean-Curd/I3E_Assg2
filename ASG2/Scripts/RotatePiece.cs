/*
 * Author: Ashley Goh Yu Ting
 * Date: 01/07/2023
 * Description: I3E/STLD Assignment 2 - Power Puzzle Rotating Pieces
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePiece : MonoBehaviour
{
    /// <summary>
    /// Rotate 90 degrees when clicked
    /// </summary>
    public void Rotate()
    {
        Audio.instance.turningPuzzle.Play();
        transform.Rotate(Vector3.forward * -90);
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
