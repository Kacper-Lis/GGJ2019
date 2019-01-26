﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SisterFight : MonoBehaviour
{
    public Collider[] hitBoxes;

        public float spellCooldown = 4f;
        public float spellDamage = 20f;
        public float exploRadius = 5f;
        public float knockForce = 50f;
        public Transform exploCenter;
        private float spellkNext;

        public GameObject bolt;
        public Transform boltEnd;
        public float speed = 20f;
        Rigidbody boltBody;

    
    // Start is called before the first frame update

    private void Awake()
    {
        boltBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && spellkNext < Time.time)
        {
            spellkNext += Time.time + spellCooldown;
            //przeciagnac objekt miecza
            LaunchWave();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            LaunchBolt();
        }
    }
    void LaunchBolt()
    {
        Instantiate(bolt, boltEnd);
    }

    void LaunchWave()
    {
        //animacja

        //Nadac maske przeciwnikom
        Collider[] cols = Physics.OverlapSphere(exploCenter.position, exploRadius, LayerMask.GetMask("Hitbox"));
        for(int i =0;i<cols.Length;i++)
        {
            Rigidbody targetRigidbody = cols[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(knockForce, exploCenter.position, exploRadius);

            EnemyHealth targetHealth = targetRigidbody.GetComponent<EnemyHealth>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);
            
            targetHealth.DamageEnemy(damage);
        }
    }
    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - exploCenter.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (exploRadius - explosionDistance) / exploRadius;

        float damage = relativeDistance * spellDamage;

        damage = Mathf.Max(5f, damage);

        return damage;
    }
}