using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    public float attackRest = 1f;
    public int Damage = 10;
    [HideInInspector]public GameObject[] players;
    public Transform Sister;
    public Transform Brother;
    public GameObject Manager;

    float toSisterDistance;
    float toBrotherDistance;
    Animator anim;

    private void Start()
    {
        anim = transform.parent.parent.parent.parent.parent.parent.parent.parent.GetComponent<Animator>();
        players = GameObject.FindGameObjectsWithTag("Players");
    }


    /*void LaunchAttack(Collider col)
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
    }*/
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("uff");
        if (AnimatorIsPlaying("Attack"))
        {
            for (int i = 0; i < players.Length; i++)
            {
                Debug.Log("uff");
                Collider hit = players[i].GetComponent<Collider>();
                if (other == hit)
                {
                    Debug.Log("uff");
                    //RangeHealth rangeHealth = hit.GetComponent<RangeHealth>();
                    Health.TakeDamage(Damage);
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
    // Update is called once per frame
    void Update()
    {
        toSisterDistance = Vector3.Distance(Sister.position, transform.position);
        toBrotherDistance = Vector3.Distance(Brother.position, transform.position);

        if (toSisterDistance < 1 || toBrotherDistance < 1)
        {
            //setbool
            anim.SetBool("IsAttacking", true);
        }
    }
}
