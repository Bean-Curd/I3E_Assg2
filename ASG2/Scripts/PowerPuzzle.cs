/*
 * Author: Ashley Goh Yu Ting
 * Date: 01/07/2023
 * Description: I3E/STLD Assignment 2 - Power Puzzle
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //For movement

public class PowerPuzzle : MonoBehaviour
{
    //By column
    /// <summary>
    /// Is C1 correct
    /// </summary>
    public bool correctCol1 = false;
    /// <summary>
    /// Is C2 correct
    /// </summary>
    public bool correctCol2 = false;
    /// <summary>
    /// Is C3 correct
    /// </summary>
    public bool correctCol3 = false;
    /// <summary>
    /// Is C4 correct
    /// </summary>
    public bool correctCol4 = false;
    /// <summary>
    /// Is C5 correct
    /// </summary>
    public bool correctCol5 = false;

    //For every piece and is it correct
    /// <summary>
    /// Is R1C1 correct
    /// </summary>
    public bool correctR1C1 = false;
    /// <summary>
    /// R1C1
    /// </summary>
    public GameObject R1C1;
    /// <summary>
    /// Is R2C1 correct
    /// </summary>
    public bool correctR2C1 = false;
    /// <summary>
    /// R2C1
    /// </summary>
    public GameObject R2C1;
    /// <summary>
    /// Is R3C1 correct
    /// </summary>
    public bool correctR3C1 = false;
    /// <summary>
    /// R3C1
    /// </summary>
    public GameObject R3C1;
    /// <summary>
    /// Is R4C1 correct
    /// </summary>
    public bool correctR4C1 = false;
    /// <summary>
    /// R4C1
    /// </summary>
    public GameObject R4C1;
    /// <summary>
    /// Is R5C1 correct
    /// </summary>
    public bool correctR5C1 = false;
    /// <summary>
    /// R5C1
    /// </summary>
    public GameObject R5C1;

    /// <summary>
    /// Is R1C2 correct
    /// </summary>
    public bool correctR1C2 = false;
    /// <summary>
    /// R1C2
    /// </summary>
    public GameObject R1C2;
    /// <summary>
    /// Is R2C2 correct
    /// </summary>
    public bool correctR2C2 = false;
    /// <summary>
    /// R2C2
    /// </summary>
    public GameObject R2C2;
    /// <summary>
    /// Is R3C2 correct
    /// </summary>
    public bool correctR3C2 = false;
    /// <summary>
    /// R3C2
    /// </summary>
    public GameObject R3C2;
    /// <summary>
    /// Is R4C2 correct
    /// </summary>
    public bool correctR4C2 = false;
    /// <summary>
    /// R4C2
    /// </summary>
    public GameObject R4C2;
    /// <summary>
    /// Is R5C2 correct
    /// </summary>
    public bool correctR5C2 = false;
    /// <summary>
    /// R5C2
    /// </summary>
    public GameObject R5C2;

    /// <summary>
    /// Is R1C3 correct
    /// </summary>
    public bool correctR1C3 = false;
    /// <summary>
    /// R1C3
    /// </summary>
    public GameObject R1C3;
    /// <summary>
    /// Is R2C3 correct
    /// </summary>
    public bool correctR2C3 = false;
    /// <summary>
    /// R2C3
    /// </summary>
    public GameObject R2C3;
    /// <summary>
    /// Is R3C3 correct
    /// </summary>
    public bool correctR3C3 = false;
    /// <summary>
    /// R3C3
    /// </summary>
    public GameObject R3C3;
    /// <summary>
    /// Is R4C3 correct
    /// </summary>
    public bool correctR4C3 = false;
    /// <summary>
    /// R4C3
    /// </summary>
    public GameObject R4C3;
    /// <summary>
    /// Is R5C3 correct
    /// </summary>
    public bool correctR5C3 = false;
    /// <summary>
    /// R5C3
    /// </summary>
    public GameObject R5C3;

    /// <summary>
    /// Is R1C4 correct
    /// </summary>
    public bool correctR1C4 = false;
    /// <summary>
    /// R1C4
    /// </summary>
    public GameObject R1C4;
    /// <summary>
    /// Is R2C4 correct
    /// </summary>
    public bool correctR2C4 = false;
    /// <summary>
    /// R2C4
    /// </summary>
    public GameObject R2C4;
    /// <summary>
    /// Is R3C4 correct
    /// </summary>
    public bool correctR3C4 = false;
    /// <summary>
    /// R3C4
    /// </summary>
    public GameObject R3C4;
    /// <summary>
    /// Is R4C4 correct
    /// </summary>
    public bool correctR4C4 = false;
    /// <summary>
    /// R4C4
    /// </summary>
    public GameObject R4C4;
    /// <summary>
    /// Is R5C4 correct
    /// </summary>
    public bool correctR5C4 = false;
    /// <summary>
    /// R5C4
    /// </summary>
    public GameObject R5C4;

    /// <summary>
    /// Is R1C5 correct
    /// </summary>
    public bool correctR1C5 = false;
    /// <summary>
    /// R1C5
    /// </summary>
    public GameObject R1C5;
    /// <summary>
    /// Is R2C5 correct
    /// </summary>
    public bool correctR2C5 = false;
    /// <summary>
    /// R2C5
    /// </summary>
    public GameObject R2C5;
    /// <summary>
    /// Is R3C5 correct
    /// </summary>
    public bool correctR3C5 = false;
    /// <summary>
    /// R3C5
    /// </summary>
    public GameObject R3C5;
    /// <summary>
    /// Is R4C5 correct
    /// </summary>
    public bool correctR4C5 = false;
    /// <summary>
    /// R4C5
    /// </summary>
    public GameObject R4C5;
    /// <summary>
    /// Is R5C5 correct
    /// </summary>
    public bool correctR5C5 = false;
    /// <summary>
    /// R5C5
    /// </summary>
    public GameObject R5C5;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static PowerPuzzle instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// How the puzzle looks like in the beginning
    /// </summary>
    public void PuzzleStart()
    {
        Debug.Log("Puzzle resets");

        R1C1.transform.Rotate(Vector3.forward * -270);
        R2C1.transform.Rotate(Vector3.forward * -270);
        R4C1.transform.Rotate(Vector3.forward * -90);
        R5C1.transform.Rotate(Vector3.forward * -270);

        R1C2.transform.Rotate(Vector3.forward * -90);
        R3C2.transform.Rotate(Vector3.forward * -90);
        R5C2.transform.Rotate(Vector3.forward * -270);

        R1C3.transform.Rotate(Vector3.forward * -180);
        R2C3.transform.Rotate(Vector3.forward * -180);
        R3C3.transform.Rotate(Vector3.forward * -180);
        R4C3.transform.Rotate(Vector3.forward * -270);
        R5C3.transform.Rotate(Vector3.forward * -270);

        R1C4.transform.Rotate(Vector3.forward * -180);
        R2C4.transform.Rotate(Vector3.forward * -90);
        R3C4.transform.Rotate(Vector3.forward * -180);

        R1C5.transform.Rotate(Vector3.forward * -270);
        R2C5.transform.Rotate(Vector3.forward * -180);
        R3C5.transform.Rotate(Vector3.forward * -180);
        R4C5.transform.Rotate(Vector3.forward * -270);
        R5C5.transform.Rotate(Vector3.forward * -270);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.inPowerPuzzle) // If during power puzzle
        {
            //If pieces are in the correct places during power puzzle
            if (correctR1C1 && correctR2C1 && correctR3C1 && correctR4C1 && correctR5C1)
            {
                Debug.Log("Col1 clear");
                correctCol1 = true;
            }
            else
            {
                correctCol1 = false;
            }

            if (correctR1C2 && correctR2C2 && correctR3C2 && correctR4C2 && correctR5C2)
            {
                Debug.Log("Col2 clear");
                correctCol2 = true;
            }
            else
            {
                correctCol2 = false;
            }

            if (correctR1C3 && correctR2C3 && correctR3C3 && correctR4C3 && correctR5C3)
            {
                Debug.Log("Col3 clear");
                correctCol3 = true;
            }
            else
            {
                correctCol3 = false;
            }

            if (correctR1C4 && correctR2C4 && correctR3C4 && correctR4C4 && correctR5C4)
            {
                Debug.Log("Col4 clear");
                correctCol4 = true;
            }
            else
            {
                correctCol4 = false;
            }

            if (correctR1C5 && correctR2C5 && correctR3C5 && correctR4C5 && correctR5C5)
            {
                Debug.Log("Col5 clear");
                correctCol5 = true;
            }
            else
            {
                correctCol5 = false;
            }

            if (correctCol1 && correctCol2 && correctCol3 && correctCol4 && correctCol5)
            {
                Debug.Log("YAY NICE GOOD JOB :D");
                PlayerUI.instance.powerPuzzlePage.SetActive(false);
                PlayerUI.instance.puzzleCompleted1.SetActive(true);
                GameManager.gameManager.inPowerPuzzle = false;
                GameManager.gameManager.powerPuzzleDone = true;
            }

            if (R1C1.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR1C1 = true;
                Debug.Log("True" + R1C1.GetComponent<RectTransform>().eulerAngles.z);
            }
            else
            {
                correctR1C1 = false;
                Debug.Log("Wrong" + R1C1.GetComponent<RectTransform>().eulerAngles.z);
            }
            if (R2C1.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR2C1 = true;
            }
            else
            {
                correctR2C1 = false;
            }
            if (R3C1.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR3C1 = true;
            }
            else
            {
                correctR3C1 = false;
            }
            if (R4C1.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR4C1 = true;
            }
            else
            {
                correctR4C1 = false;
            }
            if (R5C1.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR5C1 = true;
            }
            else
            {
                correctR5C1 = false;
            }

            if (R1C2.GetComponent<RectTransform>().eulerAngles.z == 0 || R1C2.GetComponent<RectTransform>().eulerAngles.z == 180)
            {
                correctR1C2 = true;
            }
            else
            {
                correctR1C2 = false;
            }
            if (R2C2.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR2C2 = true;
            }
            else
            {
                correctR2C2 = false;
            }
            if (R3C2.GetComponent<RectTransform>().eulerAngles.z == 0 || R3C2.GetComponent<RectTransform>().eulerAngles.z == 180)
            {
                correctR3C2 = true;
            }
            else
            {
                correctR3C2 = false;
            }
            if (R4C2.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR4C2 = true;
            }
            else
            {
                correctR4C2 = false;
            }
            if (R5C2.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR5C2 = true;
            }
            else
            {
                correctR5C2 = false;
            }

            if (R1C3.GetComponent<RectTransform>().eulerAngles.z > -90 && R1C3.GetComponent<RectTransform>().eulerAngles.z < 90) //0 doesn't work and i'm not sure how to fix float point imprecision
            {
                correctR1C3 = true;
            }
            else
            {
                correctR1C3 = false;
            }
            if (R2C3.GetComponent<RectTransform>().eulerAngles.z > -90 && R2C3.GetComponent<RectTransform>().eulerAngles.z < 90)
            {
                correctR2C3 = true;
            }
            else
            {
                correctR2C3 = false;
            }
            if (R3C3.GetComponent<RectTransform>().eulerAngles.z > -90 && R3C3.GetComponent<RectTransform>().eulerAngles.z < 90)
            {
                correctR3C3 = true;
            }
            else
            {
                correctR3C3 = false;
            }
            if (R4C3.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR4C3 = true;
            }
            else
            {
                correctR4C3 = false;
            }
            if (R5C3.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR5C3 = true;
            }
            else
            {
                correctR5C3 = false;
            }

            if (R1C4.GetComponent<RectTransform>().eulerAngles.z > -90 && R1C4.GetComponent<RectTransform>().eulerAngles.z < 90)
            {
                correctR1C4 = true;
            }
            else
            {
                correctR1C4 = false;
            }
            if (R2C4.GetComponent<RectTransform>().eulerAngles.z == 0 || R2C4.GetComponent<RectTransform>().eulerAngles.z == 180)
            {
                correctR2C4 = true;
            }
            else
            {
                correctR2C4 = false;
            }
            if (R3C4.GetComponent<RectTransform>().eulerAngles.z > -90 && R3C4.GetComponent<RectTransform>().eulerAngles.z < 90)
            {
                correctR3C4 = true;
            }
            else
            {
                correctR3C4 = false;
            }
            if (R4C4.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR4C4 = true;
            }
            else
            {
                correctR4C4 = false;
            }
            if (R5C4.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR5C4 = true;
            }
            else
            {
                correctR5C4 = false;
            }

            if (R1C5.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR1C5 = true;
            }
            else
            {
                correctR1C5 = false;
            }
            if (R2C5.GetComponent<RectTransform>().eulerAngles.z > -90 && R2C5.GetComponent<RectTransform>().eulerAngles.z < 90)
            {
                correctR2C5 = true;
            }
            else
            {
                correctR2C5 = false;
            }
            if (R3C5.GetComponent<RectTransform>().eulerAngles.z > -90 && R3C5.GetComponent<RectTransform>().eulerAngles.z < 90)
            {
                correctR3C5 = true;
            }
            else
            {
                correctR3C5 = false;
            }
            if (R4C5.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR4C5 = true;
            }
            else
            {
                correctR4C5 = false;
            }
            if (R5C5.GetComponent<RectTransform>().eulerAngles.z == 0)
            {
                correctR5C5 = true;
            }
            else
            {
                correctR5C5 = false;
            }
        }
    }
}
