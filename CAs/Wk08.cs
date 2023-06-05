using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wk08 : MonoBehaviour
{
    public GameObject capsule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IdleComplete()
    {
        Debug.Log("Idle done");
    }

    public void Touched()
    {
        GetComponent<Animator>().SetTrigger("isTouched");
    }

    public void Death()
    {
        //Destroy(gameObject);
        capsule.GetComponent<Wk08_Capsule>().PlayerDeath();
    }
}
