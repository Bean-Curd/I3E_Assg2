using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    /// <summary>
    /// To make the object appear on the screen
    /// </summary>
    new Renderer renderer;

    public static Interactible instance;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseEnter()
    {
        renderer.material.color = Color.blue;
        PlayerUI.instance.interactibleText.SetActive(true);

    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
        PlayerUI.instance.interactibleText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
