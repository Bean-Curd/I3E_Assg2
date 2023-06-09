/*
 * Author: Ashley Goh Yu Ting
 * Date: 08/05/2023
 * Description: I3E Assignment 1 Player Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //For movement
using TMPro; //For TextMeshPro

public class ASG1 : MonoBehaviour
{
    
    /// <summary>
    /// New vector with (0,0,0), for WASD movement
    /// </summary>
    Vector3 moveData = Vector3.zero;

    /// <summary>
    /// Movement speed
    /// </summary>
    public float moveSpeed = 0.11f;

    /// <summary>
    /// New vextor for mouse/camera movement
    /// </summary>
    Vector3 rotationInput = Vector3.zero;

    /// <summary>
    /// Rotation speed
    /// </summary>
    public float rotationSpeed = 0.25f;

    /// <summary>
    /// Is player trying to jump
    /// </summary>
    bool jump;

    /// <summary>
    /// Check if player is on the floor -> Prevents double jumping
    /// </summary>
    bool onFloor;

    /// <summary>
    /// Text for score
    /// </summary>
    public TextMeshProUGUI displayText;

    /// <summary>
    /// Text for number of collectibles
    /// </summary>
    public TextMeshProUGUI collectText;

    /// <summary>
    /// Number of collectibles
    /// </summary>
    int collectNum = 45; //3 keycards, 26 coins, 10 bars, 6 chests -> Total 45

    /// <summary>
    /// How many keycards collected/what doors can open
    /// </summary>
    public int accesslvl = 0;

    /// <summary>
    /// Total Score
    /// </summary>
    int score = 0;

    /// <summary>
    /// Score of collectibles
    /// </summary>
    public int keycard1 = 10; //Blue Keycard
    public int keycard2 = 10; //Orange Keycard
    public int keycard3 = 10; //Red Keycard
    public int obj1 = 5; //Obj1 is coins
    public int obj2 = 10; //Obj2 is gold bars
    public int obj3 = 20; //Obj3 is a chest
    public int bird = -5; //Bird deducts points

    /// <summary>
    /// Congratulations message after collecting all collectibles
    /// </summary>
    public GameObject congrats;

    /// <summary>
    /// Message at start of game
    /// </summary>
    public GameObject introDisplay;

    /// <summary>
    /// Message when interacting with pushable object
    /// </summary>
    public GameObject pushAlertDisplay;

    /// <summary>
    /// Message when entering bird area
    /// </summary>
    public GameObject birdWarnDisplay;

    /// <summary>
    /// Message when keycard 1/2/3 are obtained
    /// </summary>
    public GameObject card1Got;
    public GameObject card2Got;
    public GameObject card3Got;

    /// <summary>
    /// Message when door is locked
    /// </summary>
    public GameObject doorLocked;

    /// <summary>
    /// Door that requires Keycard1/2/3
    /// </summary>
    public GameObject hj1;
    public GameObject hj2;
    public GameObject hj3;

    /// <summary>
    /// Choose the camera for the head so it can rotate the camera instead of the whole body
    /// </summary>
    public Transform head;


    // Start is called before the first frame update
    void Start()
    {
        collectText.text = "Remaining Collectibles: " + collectNum; //Print number of collectibles at the start
        displayText.text = "Score: 0"; //Set score to 0 at the start
    }

    /// <summary>
    /// Triggers when WASD pressed -> Retrieving the input
    /// </summary>
    /// <param name="value"></param>
    void OnMove(InputValue value)
    {
        moveData = value.Get<Vector2>(); //WASD value (W=1,S=-1,A=-1,D=1) -> Generated by Unity
    }

    /// <summary>
    /// For mouse/camera movement
    /// </summary>
    /// <param name="value"></param>
    void OnLook(InputValue value)
    {
        rotationInput.y = value.Get<Vector2>().x; //For left right movement
        rotationInput.x = -value.Get<Vector2>().y; //For up down movement
    }

    /// <summary>
    /// So player can jump
    /// </summary>
    void OnSpaceKey()
    {
        if (onFloor) //If player is on the floor, can jump 
        {
            jump = true;
        }
    }

    /// <summary>
    /// What happens when you enter an object
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(gameObject.name + " Enter " + collision.gameObject.name);

        if (collision.gameObject.tag == "Keycard1") //If it is Keycard1, destroy it and add its points
        {
            Destroy(collision.gameObject);
            card1Got.SetActive(true); //Display to show keycard1 has been obtained
            collectNum -= 1;
            collectText.text = "Remaining Collectibles: " + collectNum;
            score += keycard1;
            displayText.text = "Score: " + score;
            accesslvl += 1;
        }

        else if (collision.gameObject.tag == "Keycard2") //If it is Keycard2, destroy it and add its points
        {
            Destroy(collision.gameObject);
            card2Got.SetActive(true); //Display to show keycard2 has been obtained
            collectNum -= 1;
            collectText.text = "Remaining Collectibles: " + collectNum;
            score += keycard2;
            displayText.text = "Score: " + score;
            accesslvl += 1;
        }

        else if (collision.gameObject.tag == "Keycard3") //If it is Keycard3, destroy it and add its points
        {
            Destroy(collision.gameObject);
            card3Got.SetActive(true); //Display to show keycard3 has been obtained
            collectNum -= 1;
            collectText.text = "Remaining Collectibles: " + collectNum;
            score += keycard3;
            displayText.text = "Score: " + score;
            accesslvl += 1;
        }

        else if (collision.gameObject.tag == "Obj1") //If it is Obj1, destroy it and add its points
        {
            Destroy(collision.gameObject);
            collectNum -= 1;
            collectText.text = "Remaining Collectibles: " + collectNum;
            score += obj1;
            displayText.text = "Score: " + score;
        }

        else if (collision.gameObject.tag == "Obj2") //If it is Obj2, destroy it and add its points
        {
            Destroy(collision.gameObject);
            collectNum -= 1;
            collectText.text = "Remaining Collectibles: " + collectNum;
            score += obj2;
            displayText.text = "Score: " + score;
        }

        else if (collision.gameObject.tag == "Obj3") //If it is Obj3, destroy it and add its points
        {
            Destroy(collision.gameObject);
            collectNum -= 1;
            collectText.text = "Remaining Collectibles: " + collectNum;
            score += obj3;
            displayText.text = "Score: " + score;
        }

        if (collectNum == 0) //If all collectibles are collected, display congrats message
        {
            congrats.SetActive(true);
        }

        if (collision.gameObject.tag == "Bird") //If touching a bird, -3 point
        {
            score += bird;

            if (score <= 0) //If score is less than or equal to 0, keep score at 0
            {
                score = 0;
            }

            displayText.text = "Score: " + score;
        }


        if (collision.gameObject.tag == "Intro") //At start of the game, display intro
        { 
            introDisplay.SetActive(true);
        }

        if (collision.gameObject.tag == "Push") //If near interactable, display message
        {
            pushAlertDisplay.SetActive(true);
        }

        if (collision.gameObject.tag == "BirdWarn") //If entering the area with birds, display warning
        {
            birdWarnDisplay.SetActive(true);
        }

        if (collision.gameObject.tag == "Door1") //If object is a door requiring keycard1, unlock position so it can open depending on the accesslvl
        {
            if (accesslvl == 0)
            {
                doorLocked.SetActive(true); //Show door locked message

            }
            if (accesslvl >= 1)
            {
                HingeJoint hinge = hj1.GetComponent<HingeJoint>(); //Get the limits from the door

                JointLimits limits = hinge.limits; //Change the limits so the door can move
                limits.min = -90;
                limits.max = 90;
                hinge.limits = limits; //To apply the limits :/
            }
        }

        if (collision.gameObject.tag == "Door2") //If object is a door requiring keycard2, unlock position so it can open depending on the accesslvl
        {
            if (accesslvl <= 1)
            {
                doorLocked.SetActive(true); //Show door locked message

            }
            if (accesslvl >= 2)
            {
                HingeJoint hinge = hj2.GetComponent<HingeJoint>(); //Get the limits from the door

                JointLimits limits = hinge.limits; //Change the limits so the door can move
                limits.min = -90;
                limits.max = 90;
                hinge.limits = limits; //To apply the limits :/
            }
        }

        if (collision.gameObject.tag == "Door3") //If object is a door requiring keycard3, unlock position so it can open depending on the accesslvl
        {
            if (accesslvl <= 2)
            {
                doorLocked.SetActive(true); //Show door locked message

            }
            if (accesslvl >= 3)
            {
                HingeJoint hinge = hj3.GetComponent<HingeJoint>(); //Get the limits from the door

                JointLimits limits = hinge.limits; //Change the limits so the door can move
                limits.min = -90;
                limits.max = 90;
                hinge.limits = limits; //To apply the limits :/
            }
        }
    }

    /// <summary>
    /// What happens when player is on an object
    /// </summary>
    void OnCollisionStay()
    {
        onFloor = true; //Confirm the player is on the floor 
    }

    /// <summary>
    /// What happens when you exit an object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log(gameObject.name + " Exit " + collision.gameObject.name);

        onFloor = false; //Once player is off an object they are no longer touching floor

        if (collision.gameObject.tag == "Door1") //If object is a door requiring keycard1, unlock position so it can open depending on the accesslvl
        {
            if (accesslvl == 0)
            {
                doorLocked.SetActive(false); //Hide door locked message once you stop touching the door
            }
        }

        if (collision.gameObject.tag == "Door2") //If object is a door requiring keycard2, unlock position so it can open depending on the accesslvl
        {
            if (accesslvl <= 1)
            {
                doorLocked.SetActive(false); //Hide door locked message once you stop touching the door
            }
        }

        if (collision.gameObject.tag == "Door3") //If object is a door requiring keycard3, unlock position so it can open depending on the accesslvl
        {
            if (accesslvl <= 2)
            {
                doorLocked.SetActive(false); //Hide door locked message once you stop touching the door
            }
        }

        if (collision.gameObject.tag == "Intro") //Once player starts moving around, stop intro display
        {
            introDisplay.SetActive(false);
            Destroy(collision.gameObject); //So it doesn't trigger again
        }

        if (collision.gameObject.tag == "Push") //If moving out of block range, remove display
        {
            pushAlertDisplay.SetActive(false);
            Destroy(collision.gameObject); //So it doesn't trigger again
        }

        if (collision.gameObject.tag == "BirdWarn") //If moving out of initial bird area, remove display
        {
            birdWarnDisplay.SetActive(false);
            Destroy(collision.gameObject); //So it doesn't trigger again
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jump && onFloor) //If player is trying to jump and is on the floor
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onFloor = false; //Prevents player from jumping immediately after
            jump = false; //Resets jump
        }

        /// <summary>
        /// Turning the input into movement -> forward/back movement
        /// </summary>
        Vector3 forwardMove = transform.forward; //Vector3(0,0,1)

        /// <summary>
        /// Turning the input into movement -> left/right movement
        /// </summary>
        Vector3 rightMove = transform.right; //Vector3(1,0,0)

        /// <summary>
        /// For the player to move
        /// </summary>
        GetComponent<Rigidbody>().MovePosition(transform.position + (forwardMove * moveData.y
        + rightMove * moveData.x) * moveSpeed);

        /// <summary>
        /// For the player to rotate
        /// </summary>
        transform.rotation =
            Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotationInput.y) * rotationSpeed);

        /// <summary>
        /// Setting limits so the camera can rotate like how a head would
        /// </summary>
        var rot = head.rotation.eulerAngles + new Vector3(rotationInput.x, 0) * rotationSpeed; //For camera to rotate 

        // Setting limits so the camera can rotate like how a head would
        while (rot.x > 180f)
        {
            rot.x -= 360f;
        }

        while (rot.x < -180f)
        {
            rot.x += 360f;
        }

        if (rot.x > 60f)
        {
            rot.x = 60f;
        }

        if (rot.x < -60f)
        {
            rot.x = -60f;
        }

        /// <summary>
        /// Applying the limits to the head rotation
        /// </summary>
        head.rotation =
            Quaternion.Euler(rot);
    }
}
    
