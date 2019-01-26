using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static int score = 0;
    [HideInInspector] public static int highScore = 0;

    Health playerHP;
    EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP.currentHP <= 0)
        {
            RoundEnding();
        }
    }
    void RoundEnding()
    {
        enemyManager.DisableEnemy(); 
    }
}
