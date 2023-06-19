using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASG2_StartPage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// To exit when the player says yes
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; //So it works in play mode for testing
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
