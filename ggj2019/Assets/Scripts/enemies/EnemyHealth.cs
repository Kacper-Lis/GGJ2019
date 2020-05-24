using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HP = 50f;
    public int ScorePoints = 40;

    public void DamageEnemy(float damage)
    {
        if (HP - damage <= 0)
        {
            if (gameObject != null)
            {
                //Temporary later change to XP
                GameManager.IncreaseScore(ScorePoints);
                Destroy(this.gameObject);
            }
        }
        else 
        {
            HP -= damage;
        }

        //Animation or something to call
    }
}
