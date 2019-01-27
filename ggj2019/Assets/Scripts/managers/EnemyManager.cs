using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject enemy_M;
    public GameObject enemy_R;
    public int wave = 1;
    public Health playerHP;

    public Transform[] spawnPointsM;
    public Transform[] spawnPointsR;

    float waitTime;
    float spawnCD = 2;
    float currentScore = 600f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Spawn());
    }
    private void Update()
    {
        if (currentScore >= 500)
        {
            wave = 5;
        }
        else if (currentScore >= 300)
        {
            wave = 4;
        }
        else if (currentScore >= 200)
        {
            wave = 3;
        }
        else if (currentScore >= 100)
        {
            wave = 2;
        }
        else
        {
            wave = 1;
        }
        if (Time.time > spawnCD)
        {
            spawnCD = Time.time + waitTime;

            currentScore = GameManager.score;
            if (wave == 5)
            {
                waitTime = 3;
                wave5();
            }
            else if (wave == 4)
            {
                wave4();
            }
            else if (wave == 3)
            {
                waitTime = 4f;
                wave3();
            }
            else if (wave == 2)
            {
                wave2();
            }
            else if (wave == 1)
            {
                waitTime = 5f;
                wave1();
            }
        }
    }
    // For the First Enemy
   /* IEnumerator Spawn()
    {
 
        while (Health.currentHP > 0)
        {
            if(currentScore >= 500)
            {
                wave = 5;
            }
            else if(currentScore >= 300)
            { 
                wave = 4;
            }
            else if (currentScore >= 200)
            {
                wave = 3;
            }
            else if (currentScore >= 100)
            {
                wave = 2;
            }
            else
            {
                wave = 1;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }*/
    void wave1()
    {
        Instantiate(enemy_M, spawnPointsM[0]);
        Instantiate(enemy_R, spawnPointsR[0]);
    }
    void wave2()
    {
        for(int i = 0; i < 2; i++)
        {
            Instantiate(enemy_M, spawnPointsM[i]);
            Instantiate(enemy_R, spawnPointsR[i]);
        }
    }
    void wave3()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(enemy_M, spawnPointsM[i]);
            Instantiate(enemy_R, spawnPointsR[i]);
        }
    }
    void wave4()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemy_M, spawnPointsM[i]);
            Instantiate(enemy_R, spawnPointsR[i]);
        }
    }
    void wave5()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(enemy_M, spawnPointsM[i]);
            Instantiate(enemy_R, spawnPointsR[i]);
        }
    }
}
