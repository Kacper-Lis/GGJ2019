using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister : Player
{
    //Basic Attack
    public GameObject bolt;
    public Transform barrelEnd;

    //Power Attack
    public Transform exploCenter;
    private float exploRadius = 2f;
    private float knockForce = 500f;
    private float exploDamage = 80f;

    private void LateUpdate()
    {
        if (AnimatorIsPlaying("BasicAttack") || AnimatorIsPlaying("PowerAttack")) 
        {
            moveX = 0;
            rotateX = 0;
        }
    }
    public override void basicAttack() 
    {
        //Attached event to animation 
        Instantiate(bolt, barrelEnd);
    }

    public override void powerAttack() 
    {
        //Add Mask to the enemies
        Collider[] colliders = Physics.OverlapSphere(exploCenter.position, exploRadius, LayerMask.GetMask("Hitbox"));

        exploCenter.GetComponent<ParticleSystem>().Play();

        for (int i = 0; i < colliders.Length; i++) 
        {
            if (colliders[i].gameObject.tag != "Enemy")
                continue;

            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(knockForce, exploCenter.position, exploRadius);

            EnemyHealth enemy = targetRigidbody.GetComponent<EnemyHealth>();

            enemy.DamageEnemy(CalculateDamage(targetRigidbody.position));
        }
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - exploCenter.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (exploRadius - explosionDistance) / exploRadius;

        float damage = relativeDistance * exploDamage;

        damage = Mathf.Max(5f, damage);

        return damage;
    }

    public override void specialAttack()
    {
        
    }

    public override void setupStats()
    {
        setHpRegenTime(3);
        setHpRegenValue(2);
        setPowerRegenTime(0.5f);
        setPowerRegenValue(5);
    }
}
