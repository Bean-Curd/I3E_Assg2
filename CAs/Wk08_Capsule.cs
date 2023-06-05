using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wk08_Capsule : MonoBehaviour
{
    public GameObject player;

    public void PlayerDeath()
    {
        GetComponent<Animator>().SetTrigger("isDead");
    }

    void Died()
    {
        Destroy(player);
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
