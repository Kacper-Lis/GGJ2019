using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject enemy_1;
    //public GameObject enemy_2;

    public Health playerHP;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // For the First Enemy
    void Spawn()
    {
        if (playerHP.currentHP <= 0)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy_1, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }

   
}
