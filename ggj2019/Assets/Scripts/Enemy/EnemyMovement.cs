using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Sister;
    public GameObject Brother;
    public GameObject AI_enemy;
    
    Transform brother;
    Transform sister;
    //public GameObject playerHP;
    public EnemyHealth enemyHP;
    
    NavMeshAgent nav;
    float toSisterDistance;
    float toBrotherDistance;

    private bool Attack;

    

    void Awake ()
    {
        
        toSisterDistance = Vector3.Distance(Sister.transform.position, AI_enemy.transform.position);
        toBrotherDistance = Vector3.Distance(Brother.transform.position, AI_enemy.transform.position);
        // Health = player.GetComponent <Health> ();
        // enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
        //Look into that in case of bugs
        // brother = GameObject.FindGameObjectWithTag ("brother").transform;
        // sister = GameObject.FindGameObjectWithTag ("sister").transform;
        // enemy = GameObject.FindGameObjectWithTag ("enemy").transform;
    }

   

    void Update ()
    {
        // If the enemy and the player have health left aka Game is on!
        if(enemyHP.enemyHP > 0)
        {
            toSisterDistance = Vector3.Distance(Sister.transform.position, AI_enemy.transform.position);
            toBrotherDistance = Vector3.Distance(Brother.transform.position, AI_enemy.transform.position);


            // set the destination of the nav mesh agent to the player.
            if (toSisterDistance > toBrotherDistance)
                {
                nav.SetDestination (Brother.transform.position);
                }
            else
                {
                nav.SetDestination (Sister.transform.position);
                }

            

        }





        // Otherwise
        else
        {
            // disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}
