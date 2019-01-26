using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherFight : MonoBehaviour
{
    public float attackRest = 1f;
    public Collider[] hitBoxes;
    public float swordDamage = 10f;

    private float attackNext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G) && attackNext < Time.time)
        {
            attackNext += Time.time + attackRest;
            //przeciagnac objekt miecza
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
            EnemyHealth targetHealth = targetRigidbody.GetComponent<EnemyHealth>();
            targetHealth.DamageEnemy(swordDamage);
            Debug.Log("Collider");
        }
    }
}
