using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    public float attackRest = 1f;
    public Collider[] hitBoxes;
    public int Damage = 10;

    public GameObject Sister;
    public GameObject Brother;
    public GameObject AI_enemy;
    public GameObject Manager;

    float toSisterDistance;
    float toBrotherDistance;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void LaunchAttack(Collider col)
    {

        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        for (int i = 0; i < cols.Length; i++)
        {
            Rigidbody targetRigidbody = cols[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
                continue;
            //damage
            Health.TakeDamage(Damage);


        }
    }

    // Update is called once per frame
    void Update()
    {
        toSisterDistance = Vector3.Distance(Sister.transform.position, AI_enemy.transform.position);
        toBrotherDistance = Vector3.Distance(Brother.transform.position, AI_enemy.transform.position);

        if (toSisterDistance < 0.8 || toBrotherDistance < 0.8)
        {
            anim.SetTrigger("AttTriger");
            LaunchAttack(hitBoxes[0]);

        }
    }
}
