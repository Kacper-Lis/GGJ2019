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
    float currentScore = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        if(wave == 5){
            waitTime = 2;
        }else if(wave == 3)
        {   waitTime = 3f;
        }else if (wave == 1)
        {   waitTime = 4f;
        }
    }
    // For the First Enemy
    IEnumerator Spawn()
    {
 
        while (true)
        {
            if(currentScore >= 500)
            {
                wave5();
                wave = 5;
            }
            else if(currentScore >= 300)
            {
                wave4();
                wave = 4;
            }
            else if (currentScore >= 200)
            {
                wave3();
                wave = 3;
            }
            else if (currentScore >= 100)
            {
                wave2();
                wave = 2;
            }
            else
            {
                wave1();
                wave = 1;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
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
