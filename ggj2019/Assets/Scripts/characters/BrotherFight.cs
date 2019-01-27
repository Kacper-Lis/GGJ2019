using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherFight : MonoBehaviour
{
    public float attackRest = 1f;
    public Collider[] hitBoxes;
    public float swordDamage = 30f;
    private Animator anim;

    private float attackNext = 1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G) && attackNext < Time.time)
        {
            attackNext = Time.time + attackRest;
            //przeciagnac objekt miecza
            anim.SetTrigger("AttackTrigger");
            LaunchAttack(hitBoxes[0]);
        }
    }
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
            Debug.Log("hpM");
            MeleeHealth meleeHealth = targetRigidbody.GetComponent<MeleeHealth>();
            if (!meleeHealth)
                continue;
            RangeHealth rangeHealth = targetRigidbody.GetComponent<RangeHealth>();
            if (!rangeHealth)
                continue;
            Debug.Log("hpMasda");
            meleeHealth.DamageEnemy(swordDamage);
            rangeHealth.DamageEnemy(swordDamage);
        }
    }
}
