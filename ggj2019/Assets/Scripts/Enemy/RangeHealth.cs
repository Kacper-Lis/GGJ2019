using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHealth : MonoBehaviour
{
    public float hpR = 30f;
    public float ScorePoints = 25;
    public float delay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DamageEnemy(float damage)
    {
        hpR -= damage;
        //Animation or something to call
    }
    // Update is called once per frame
    void Update()
    {
        if (hpR <= 0)
        {
            // destroy(gameObject, delay);

            //GameManager.score += ScorePoints;
            Destroy(gameObject, delay);
        }
    }
}
