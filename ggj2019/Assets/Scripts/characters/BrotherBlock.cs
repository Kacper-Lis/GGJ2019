using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherBlock : MonoBehaviour
{
    float Cdvalue = 5f;
    public float BlockCooldown = 4;
    public GameObject Shield;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Block()
    {
        anim.SetBool("Blocking", true);
        //Change Shield Position to block
    }

    void UnBlock()
    {
        //Change Shield Position to no-block
        anim.SetBool("Blocking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && Cdvalue < Time.time)
        {
            Block();
            Cdvalue = Time.time + BlockCooldown;
        }

        if (Cdvalue < Time.time)
        {
            UnBlock();
        }
        
        // Pamietaj o dodaniu warunku w enemy attack do bloku

    }
}
