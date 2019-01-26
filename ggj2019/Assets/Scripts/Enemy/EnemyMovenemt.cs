using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovenemt : MonoBehaviour
{
    /*
    public sister;
    public brother;
    Transform brother;
    Transform sister;
    Health Health;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
    float toSisterDistance;
    float toBrotherDistance;

    void Awake ()
    {
        toSisterDistance = Vector3.Distance(sister.transform.position, enemy.transform.position);
        toBrotherDistance = Vector3.Distance(brother.transform.position, enemy.transform.position);
        Health = player.GetComponent <Health> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
        brother = GameObject.FindGameObjectWithTag ("brother").transform;
        sister = GameObject.FindGameObjectWithTag ("sister").transform;
        enemy = GameObject.FindGameObjectWithTag ("enemy").transform;
    }


    void Update ()
    {
        // If the enemy and the player have health left
        if(enemyHealth.currentHealth > 0 && Health.currentHealth > 0)
        {
            // set the destination of the nav mesh agent to the player.
            if (toSisterDistance > toBrotherDistance)
                {
                nav.SetDestination (brother.position);
                }
            else
                {
                nav.SetDestination (sister.position);
                }
        }
        // Otherwise
        else
        {
            // disable the nav mesh agent.
            nav.enabled = false;
        }
    }*/
}
