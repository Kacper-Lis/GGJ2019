using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    private GameObject SisterObject;
    private GameObject BrotherObject;

    private Transform Sister;
    private Transform Brother;

    //public GameObject playerHP;
    //public EnemyHealth enemyHP;
    
    NavMeshAgent nav;
    float toSisterDistance;
    float toBrotherDistance;
    Vector3 brotherCurrent;
    Vector3 sisterCurrent;
    private bool Attack;

    

    void Awake ()
    {
        SisterObject = GameObject.Find("Poly");
        BrotherObject = GameObject.Find("Brother");
        Sister = SisterObject.GetComponent<Transform>();
        Brother = BrotherObject.GetComponent<Transform>();
        nav = GetComponent <NavMeshAgent> ();
    }

   

    void Update ()
    {
        toSisterDistance = Vector3.Distance(Sister.position, transform.position);
        toBrotherDistance = Vector3.Distance(Brother.position, transform.position);
        brotherCurrent = Brother.position;
        sisterCurrent = Sister.position;

        // set the destination of the nav mesh agent to the player.
        if (toSisterDistance > toBrotherDistance)
        {
            nav.SetDestination(sisterCurrent);
        }
        else
        {
            nav.SetDestination(brotherCurrent);
        }
    }
}
