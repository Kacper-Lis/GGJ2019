using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static int score = 0;
    [HideInInspector] public static int highScore = 0;
    public Text scoreText;

    EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
    public static void IncreaseScore(int sc)
    {
        score += sc;
    }
}
