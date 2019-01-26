using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHP = 100;
    public float ScorePoints = 5;
    public float delay = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DamageEnemy(float damage)
    {
        enemyHP -= damage;
        //Animation or something to call
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            // destroy(gameObject, delay);

            //GameManager.score += ScorePoints;
            Destroy(gameObject, delay);
        }



    }
}
