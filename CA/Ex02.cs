using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex02 : MonoBehaviour
{
    int x = 3;
    int y = 2;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i <= 4; i++)
        {
            x += 1;

            if ((x - y) < 4 && (x - y) >= 1)
            {
                //If x-y is between 3 and 1
                Debug.Log("True");
            }
            else
            {
                Debug.Log("Failed");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
