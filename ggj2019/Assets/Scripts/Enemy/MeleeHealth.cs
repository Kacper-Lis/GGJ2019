using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHealth : MonoBehaviour
{
    public float hpM = 50f;
    public float ScorePoints = 15;
    public float delay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DamageEnemy(float damage)
    {
        hpM -= damage;
        //Animation or something to call
    }
    // Update is called once per frame
    void Update()
    {
        if (hpM <= 0)
        {
            // destroy(gameObject, delay);

            //GameManager.score += ScorePoints;
            Destroy(gameObject, delay);
        }
    }
}
