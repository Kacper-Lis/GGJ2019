using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float startHP = 100f;
    public float currentHP;
    public Slider HealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = startHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            // Call do Game !!!!!
            game_over();
        }
        HealthSlider.value = currentHP;
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }

    void game_over()
    {

    }
}
