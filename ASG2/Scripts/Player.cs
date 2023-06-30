/*
 * Author: Ashley Goh Yu Ting
 * Date: 05/06/2023
 * Description: I3E/STLD Assignment 2 - Player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //For movement
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    /// <summary>
    /// New vector with (0,0,0), for WASD movement
    /// </summary>
    Vector3 moveData = Vector3.zero;

    /// <summary>
    /// Movement speed
    /// </summary>
    public float moveSpeed = 4.0f;

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
    /// Choose the camera for the head so it can rotate the camera instead of the whole body
    /// </summary>
    public Transform head;

    /// <summary>
    /// Raycast ray distance
    /// </summary>
    public float InteractionDistance = 3f;

    /// <summary>
    /// To set as main camera
    /// </summary>
    Camera cam;

    /// <summary>
    /// E from exit
    /// </summary>
    public bool eKey = false;
    /// <summary>
    /// X from exit
    /// </summary>
    public bool xKey = false;
    /// <summary>
    /// I from exit
    /// </summary>
    public bool iKey = false;
    /// <summary>
    /// T from exit
    /// </summary>
    public bool tKey = false;

    /// <summary>
    /// For the first-aid kit collection
    /// </summary>
    private Coroutine firstAidText;
    /// <summary>
    /// For the captainCard collection
    /// </summary>
    private Coroutine captainCardText;
    /// <summary>
    /// For the main monitor interaction
    /// </summary>
    private Coroutine mainMonitorText;

    /// <summary>
    /// Number of times player can heal
    /// </summary>
    public int healCount = 3;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static Player instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        eKey = false;
        xKey = false;
        iKey = false;
        tKey = false;

        if (GameManager.gameManager.firstAidKit) //If have the first aid kit, show the symbol
        {
            PlayerUI.instance.firstAidKit.SetActive(true);
            PlayerUI.instance.firstAidKitOverlay.SetActive(true);
        }
        if (GameManager.gameManager.captainCard) //If have the captain's card, show the symbol
        {
            PlayerUI.instance.captainCard.SetActive(true);
        }
        if (GameManager.gameManager.weaponCard) //If have the weapons card, show the symbol
        {

        }
        if (GameManager.gameManager.c4) //If have the c4, show the symbol
        {

        }
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
    /// To pause the game
    /// </summary>
    void OnPause() //When the escape key is pressed, stop time and bring up pause screen
    {
        if (GameManager.gameManager.dead) //If currently dead, respawn
        {
            Debug.Log("Respawning");

            GameManager.gameManager.dead = false;
            GameManager.gameManager.respawn = true;
        }
        else if (GameManager.gameManager.pause) //If currently paused, unpause
        {
            GameManager.gameManager.pause = false;
        }
        else if (GameManager.gameManager.pause != true) //If not paused, pause 
        {
            GameManager.gameManager.pause = true;
        }
    }

    /// <summary>
    /// E from exit to leave for start menu
    /// </summary>
    void OnEKey()
    {
        if (GameManager.gameManager.pause || GameManager.gameManager.dead)
        {
            eKey = true;
        }
    }

    /// <summary>
    /// X from exit to leave for start menu
    /// </summary>
    void OnXKey()
    {
        if (GameManager.gameManager.pause || GameManager.gameManager.dead)
        {
            xKey = true;
        }
    }

    /// <summary>
    /// I from exit to leave for start menu
    /// </summary>
    void OnIKey()
    {
        if (GameManager.gameManager.pause || GameManager.gameManager.dead)
        {
            iKey = true;
        }
    }

    /// <summary>
    /// T from exit to leave for start menu
    /// </summary>
    void OnTKey()
    {
        if (GameManager.gameManager.pause || GameManager.gameManager.dead)
        {
            tKey = true;
        }
    }

    /// <summary>
    /// What happens when you enter an object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(gameObject.name + " Enter " + collision.gameObject.name);
    }

    /// <summary>
    /// Trigger when entering an object
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ScottTrigger") //If approaching scott's body
        {
            Debug.Log("Approaching Scott");
            PlayerUI.instance.scottInteract = true;
            PlayerUI.instance.scott1.SetActive(true);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "EmergencyDoor") //If approaching door's locked down during emergency 
        {
            Debug.Log("Approaching Emergency Door");
            PlayerUI.instance.emergencyDoorInteract = true;
            PlayerUI.instance.emergency1.SetActive(true);
        }
        else if (collision.gameObject.tag == "WeaponsDoor") //If approaching door's locked down during emergency 
        {
            Debug.Log("Approaching Weapon Door");
            PlayerUI.instance.weaponDoorInteract = true;
            PlayerUI.instance.weapon1.SetActive(true);
        }
        else if (collision.gameObject.tag == "ElenaTrigger") //If approaching elena's body
        {
            Debug.Log("Approaching Elena");
            PlayerUI.instance.elenaInteract = true;
            PlayerUI.instance.elena1.SetActive(true);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "HealingStation") //If near healing station, restore HP
        {
            PlayerUI.instance.healingInteract = true;

            if (ASG2_HealthBar.instance.currentHealth >= 10000) //If max HP
            {
                Debug.Log("Healing recieved: Max HP");
                PlayerUI.instance.healingNo.SetActive(true);
            }
            else
            {
                Debug.Log("Healing recieved: Low HP");
                if (GameManager.gameManager.healLimit) //If there is a heal limit, deduct 1
                {
                    if (healCount > 0)
                    {
                        ASG2_HealthBar.instance.Damage(-10000); //Restore HP
                        healCount -= 1;
                        PlayerUI.instance.healingYes.SetActive(true);
                        Debug.Log("Heals left = " + healCount);
                    }
                }
                else
                {
                    ASG2_HealthBar.instance.Damage(-10000); //Restore HP
                    PlayerUI.instance.healingYes.SetActive(true);
                }
            }
        }
        else if (collision.gameObject.tag == "JakeTrigger") //If approaching jake's body
        {
            Debug.Log("Approaching Jake");
            PlayerUI.instance.jakeInteract = true;
            PlayerUI.instance.jake1.SetActive(true);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "SuitSectionBlocks") //If approaching a suit section block 
        {
            Debug.Log("Approaching Suit Sectiion Block");
            PlayerUI.instance.suitSectionBlockInteract = true;
            PlayerUI.instance.suitSectionBlock.SetActive(true);
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
    }

    /// <summary>
    /// Delay first-aid kit dialogue for 0.05 second
    /// </summary>
    IEnumerator WaitForFirstAid()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("Delay 0.05 second");

        PlayerUI.instance.firstAidInteract = true; //Set up dialogue
        PlayerUI.instance.firstAid1.SetActive(true);

        firstAidText = null;
    }

    /// <summary>
    /// Delay captain's card dialogue for 0.05 second
    /// </summary>
    IEnumerator WaitForCaptainCard()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("Delay 0.05 second");

        PlayerUI.instance.captainInteract = true; //Set up dialogue
        PlayerUI.instance.captain1.SetActive(true);

        captainCardText = null;
    }

    /// <summary>
    /// Delay monitor interaction dialogue for 0.05 second
    /// </summary>
    IEnumerator WaitForMainMonitor()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("Delay 0.05 second");

        PlayerUI.instance.monitorInteract = true;
        if (GameManager.gameManager.captainCard)
        {
            PlayerUI.instance.monitorYes.SetActive(true);
        }
        else 
        {
            PlayerUI.instance.monitorNo.SetActive(true);
        }

        mainMonitorText = null;
    }

    // Update is called once per frame
    void Update()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (jump && onFloor) //If player is trying to jump and is on the floor
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onFloor = false; //Prevents player from jumping immediately after
            jump = false; //Resets jump
        }

        if (Input.GetKey(KeyCode.LeftShift)) //If left shift is pressed, decrease energy bar
        {
            ASG2_EnergyBar.instance.Sprint(20);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //If left shift is lifted, reset movement speed
        {
            moveSpeed = 4.0f;
        }

        if (GameManager.gameManager.pause || GameManager.gameManager.dead) //If currently paused or dead, allow for exit
        {
            if (eKey) //If E key is pressed
            {
                Debug.Log("E");
                if (xKey) //if X key is pressed
                {
                    Debug.Log("X");
                    if (iKey) //If I key is pressed
                    {
                        Debug.Log("I");
                        if (tKey) //If T key is pressed
                        {
                            Debug.Log("T");
                            GameManager.gameManager.LoadingScreen();
                            SceneManager.LoadScene(0);
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0)) //If left clicking an interactible object -> perform an action
        {
            /// <summary>
            /// Ray sent on left click
            /// </summary>
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractionDistance))
            {
                if (hitInfo.collider.gameObject.GetComponent<Interactible>() != null) //If object is interactible/has the interactible script
                {
                    Debug.Log(hitInfo.collider.gameObject.tag);

                    if (hitInfo.collider.gameObject.tag == "First-Aid Kit")
                    {
                        Debug.Log("Destroying object");
                        GameManager.gameManager.firstAidKit = true;
                        ASG2_HealthBar.instance.Damage(-6000); //Restore HP to max

                        PlayerUI.instance.firstAidKit.SetActive(true); //Show symbols
                        PlayerUI.instance.firstAidKitOverlay.SetActive(true);

                        PlayerUI.instance.interactibleText.SetActive(false); //Hide interactible text

                        Destroy(hitInfo.collider.gameObject);

                        firstAidText = StartCoroutine(WaitForFirstAid());
                    }
                    else if (hitInfo.collider.gameObject.tag == "Captain's Card")
                    {
                        Debug.Log("Destroying object");
                        GameManager.gameManager.captainCard = true;

                        PlayerUI.instance.captainCard.SetActive(true); //Show symbol

                        PlayerUI.instance.interactibleText.SetActive(false); //Hide interactible text

                        Destroy(hitInfo.collider.gameObject);

                        captainCardText = StartCoroutine(WaitForCaptainCard());
                    }
                    else if (hitInfo.collider.gameObject.tag == "Monitor")
                    {
                        Debug.Log("Interacting with Monitor");

                        PlayerUI.instance.interactibleText.SetActive(false); //Hide interactible text

                        mainMonitorText = StartCoroutine(WaitForMainMonitor());
                    }

                }
            }
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
        + rightMove * moveData.x) * moveSpeed * Time.deltaTime);

        /// <summary>
        /// For the player to rotate
        /// </summary>
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotationInput.y) * rotationSpeed);

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
        head.rotation = Quaternion.Euler(rot);
    }
}
