using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static PlayerUI instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
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
