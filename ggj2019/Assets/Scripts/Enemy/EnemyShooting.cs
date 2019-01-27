﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bolt;
    public Transform boltEnd;
    public float Cooldown = 5f;
    private float spawn = 5f;
    private float NextAttack;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Do sprawdzenia
        if (Time.time > 5)
        {
            if (NextAttack < Time.time)
            {
                //Shoooots
                NextAttack += Time.time + Cooldown;
                anim.SetTrigger("Shoot");
                Instantiate(bolt, boltEnd);
            }
        }
        
    }
}
