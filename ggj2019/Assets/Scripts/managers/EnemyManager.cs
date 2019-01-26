using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject enemy_1;
    public GameObject enemy_2;
    public int wave = 1;
    public Health playerHP;

    public float spawnTime = 3f;
    public Transform[] spawnPointsM;
    public Transform[] spawnPointsR;

    float currentScore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    private void Update()
    {

    }
    // For the First Enemy
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            if (currentScore >= 200)
            {
                wave = 3;
            }
            else if (currentScore >= 100)
            {
                wave = 2;
            }
            else
            {
                wave1();
            }
        }
    }
    void wave1()
    {

        Debug.Log("sas");
    }
    void wave2()
    {

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
