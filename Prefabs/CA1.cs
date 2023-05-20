using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA1 : MonoBehaviour
{
    
    // Public allows you to change the number in unity (No longer affected by the number here anymore, only affected by the one in unity)
    // e.g. public int x = 1
    int x = 4;
    int y = 5;

    //Task 1: Bound to key 1
    void OnEqualInt()
    {
        if (x == y)
        {
            // If x and y are equal
            Debug.Log("The variables are equal");
        }
        else
        {
            // If x and y are NOT equal
            Debug.Log("The variables are NOT equal");

            if (x > y)
            {
                // If x > y
                Debug.Log("The larger number is " +x);
            }
            else if (y > x)
            {
                // If y > x
                Debug.Log("The larger number is " +y);
            }
        }
    }

    //Task 2: Bound to key 2
    void OnNumberLine()
    {
        string numLine = "";
        for (int i = 0; i < 10; i++)
        {
            numLine += (i+1).ToString();
        }
        Debug.Log(numLine);
    }

    //Task 3: Bound to key 3
    void OnHellos()
    {
        int a = 0;
        while (a < 10)
        {
            Debug.Log("Hello World");
            a++;
        }
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
