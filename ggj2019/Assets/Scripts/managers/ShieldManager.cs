using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    Rigidbody ShieldBody;
    public Rigidbody Brother;
    public GameObject[] projectiles;
    

    private void Awake()
    {
        ShieldBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        projectiles = GameObject.FindGameObjectsWithTag("Projectiles");

        for(int i=0; i < projectiles.Length; i++)
        {
            Collider hit = projectiles[i].GetComponent<Collider>();

            if(other == hit)
            {
                projectileEnemy proj = hit.GetComponent<projectileEnemy>();
                proj.DestroyBullet();
            }
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        



    }
}
