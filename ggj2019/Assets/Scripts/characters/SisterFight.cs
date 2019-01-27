using System.Collections;
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

        private Animator anim;

        public GameObject bolt;
        public Transform boltEnd;
        public float boltColldown = 0.5f;
        public float speed = 7f;
        private float boltNext;
        Rigidbody boltBody;

    
    // Start is called before the first frame update

    private void Awake()
    {
        boltBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("FireS2") && spellkNext < Time.time)
        {
            spellkNext = Time.time + spellCooldown;
            //przeciagnac objekt miecza
            LaunchWave();
        }
        if (Input.GetButton("FireS1") && boltNext < Time.time)
        {
            boltNext = Time.time + boltColldown;
            LaunchBolt();
        }
    }
    void LaunchBolt()
    {
        anim.SetTrigger("Attack");
        Instantiate(bolt, boltEnd);
    }

    void LaunchWave()
    {
        //animacja
        anim.SetTrigger("Spell");
        //Nadac maske przeciwnikom
        Collider[] cols = Physics.OverlapSphere(exploCenter.position, exploRadius, LayerMask.GetMask("Hitbox"));
        for(int i =0;i<cols.Length;i++)
        {
            Rigidbody targetRigidbody = cols[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(knockForce, exploCenter.position, exploRadius);

            MeleeHealth meleeHealth = targetRigidbody.GetComponent<MeleeHealth>();
            RangeHealth rangeHealth = targetRigidbody.GetComponent<RangeHealth>();

            float damage = CalculateDamage(targetRigidbody.position);

            meleeHealth.DamageEnemy(damage);
            rangeHealth.DamageEnemy(damage);
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
