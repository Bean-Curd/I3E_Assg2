using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex01 : MonoBehaviour
{
    int x = 10;
    int y = 2;

    void QuickMath()
    {
        Debug.Log(x / y);
        Debug.Log((x/2) - y);
        Debug.Log(x % y);
        Debug.Log((x * x) + (y * y));
        Debug.Log((x / y) * (x / y) * (x / y));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnFire()
    {
        QuickMath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
