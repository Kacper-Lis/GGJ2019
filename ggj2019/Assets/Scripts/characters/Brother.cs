using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brother : Player
{
    //Basic attack
    private float swordDamage = 20f;
    public BoxCollider sword;

    public override void basicAttack()
    {
        sword.enabled = true;
        moveSpeed = 1.0f;
        Invoke("resetAfterAttack", 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                Collider hit = enemies[i].GetComponent<Collider>();
                if (other == hit)
                {
                    //KnockBack not working to fix 
                    Rigidbody hitBody = hit.GetComponent<Rigidbody>();
                    hitBody.AddForce(hitBody.velocity * -1, ForceMode.VelocityChange);
                    EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
                    enemy.DamageEnemy(swordDamage);
                }
            }
        }
    }

    private void resetAfterAttack() 
    {
        sword.enabled = false;
        moveSpeed = 2.0f;
    }

    public override void powerAttack() 
    {
        
    }

    public override void specialAttack()
    {
        
    }

    public override void setupStats()
    {
        setHpRegenTime(2);
        setHpRegenValue(3);
        setPowerRegenTime(0.5f);
        setPowerRegenValue(2);
    }
}
