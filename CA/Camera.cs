using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour
{
    Vector3 rotationInput = Vector3.zero;
    public float rotationSpeed = 1.0f;

    void OnLook(InputValue value) //For mouse camera movement
    {
        rotationInput.x = value.Get<Vector2>().y; //For up down movement
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rot = transform.rotation.eulerAngles + rotationInput * rotationSpeed;

        while (rot.x > 180f)
        {
            rot.x -= 360f;
        }

        while (rot.x < -180f)
        {
            rot.x += 360f;
        }

        if (rot.x > 0f)
        {
            rot.x = 0f;
        }

        if (rot.x < -60f)
        {
            rot.x = -60f;
        }

        transform.rotation =
            Quaternion.Euler(rot);

    }
}
