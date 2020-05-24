using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour
{
    private float speed = 8f;
    private int boltDamage = 20;

    //Delay self destroy of the bolt
    private float destroyDelay = 1.5f;

    [HideInInspector]public GameObject[] enemys;
    private Rigidbody boltBody;

    private void Awake()
    {
        boltBody = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        boltBody.velocity = transform.forward * speed;
        Destroy(gameObject, destroyDelay);
    }
    
    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    //Apply damage to enemies
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            EnemyHealth enemy = enemys[i].GetComponent<EnemyHealth>();
            Collider hit = enemys[i].GetComponent<Collider>();
            if (other == hit)
            {
                enemy.DamageEnemy(boltDamage);
                Destroy(this.gameObject);
            }
        }
    }
}
