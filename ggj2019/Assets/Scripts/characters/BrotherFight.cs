﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherFight : MonoBehaviour
{
    public float attackRest = 1f;
    public Collider[] hitBoxes;
    public GameObject[] enemys;
    public float swordDamage = 10f;
    private Animator anim;

    private float attackNext = 1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (Input.GetKeyDown(KeyCode.G) && attackNext < Time.time)
        {
            attackNext = Time.time + attackRest;
            //przeciagnac objekt miecza
            anim.SetTrigger("AttackTrigger");
            //LaunchAttack(hitBoxes[0]);
        }
    }/*
    void LaunchAttack(Collider col)
    {
        //animacje
        
        //Nadac maske przeciwnikom
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        for (int i = 0; i < cols.Length; i++)
        {
            Rigidbody targetRigidbody = cols[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;
            //damage
            MeleeHealth meleeHealth = targetRigidbody.GetComponent<MeleeHealth>();
            RangeHealth rangeHealth = targetRigidbody.GetComponent<RangeHealth>();
            meleeHealth.DamageEnemy(swordDamage);
            rangeHealth.DamageEnemy(swordDamage);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
            while (AnimatorIsPlaying("Attacking"))
        {
                for (int i = 0; i < enemys.Length; i++)
                {

                    Collider hit = enemys[i].GetComponent<Collider>();
                    if (other == hit)
                    {
                        MeleeHealth meleeHealth = hit.GetComponent<MeleeHealth>();
                        //RangeHealth rangeHealth = hit.GetComponent<RangeHealth>();
                        meleeHealth.DamageEnemy(swordDamage);
                        //rangeHealth.DamageEnemy(swordDamage);
                    }
                }
        }
    }
    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
