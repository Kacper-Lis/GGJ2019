using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject enemy_1;
    public GameObject enemy_2;
    public int wave;
    public Health playerHP;

    public float spawnTime = 3f;
    public Transform[] spawnPointsM;
    public Transform[] spawnPointsR;

    float currentScore;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (playerHP.currentHP <= 0)
            return;
        if (currentScore >= 200)
        {
            wave = 3;
        }else if(currentScore >= 100)
        {
            wave = 2;
        }else if(currentScore >= 20)
        {
            wave = 1;
        }
        Spawn();
    }
    // For the First Enemy
    void Spawn()
    {
        if (playerHP.currentHP <= 0)
            return;
        switch (wave)
        {
            case 2:
                wave2();
                break;
            case 1:
                wave1();
                break;
        }
        void wave1()
        {
            Debug.Log("wywolana");
        }
        void wave2()
        {

        };

    }
    public void EnableEnemy()
    {

    }
    public void DisableEnemy()
    {
        EnemyMovenemt enemyMovenemt = GetComponent<EnemyMovenemt>();
        enemyMovenemt.enabled = false;
    }

   
}
