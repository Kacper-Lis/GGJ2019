using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    //Movement
    public float moveSpeed = 2.0f;
    private float rotateSpeed = 4.0f;
    private float charging = 0;

    //Hp
    private int maxHP = 100;
    private int currentHP = 100;
    private float hpRegenTime = 1;
    private int hpRegenValue = 1;

    //Mana/Energy
    private int maxPower = 100;
    private int power = 100;
    private float powerRegenTime = 1;
    private int powerRegenValue = 1;

    private Animator anim;
    private Rigidbody playerBody;

    [HideInInspector] public GameObject[] enemies;

    [HideInInspector] public float moveX;
    [HideInInspector] public float rotateX;

    private Vector3 movement;
    private Quaternion rotation;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        setupStats();
        InvokeRepeating("regenerateHP", 1f, getHpRegenTime());
        InvokeRepeating("regeneratePower", 1f, getPowerRegenTime());
    }

    private void FixedUpdate()
    {       
        Movement();
        Rotate();
    }

    private void Update()
    {
        readInput();
        AnimateMovement();
        Attack();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentHP <= 0)
        {
            // Call do Game !!!!!
            game_over();
        }
    }

    private void AnimateMovement() 
    {
        //Movement
        if (moveX != 0)
            anim.SetBool("isWalking", true);
        else 
            anim.SetBool("isWalking", false);

        //Rotation

    }

    private void readInput() 
    {
        moveX = Input.GetAxis("Vertical1");
        rotateX = Input.GetAxis("Horizontal1");
    }

    private void Movement()
    {
        movement = transform.forward * moveX * moveSpeed * Time.deltaTime;
        playerBody.MovePosition(playerBody.position + movement);
    }

    private void Rotate()
    {
        float turn = rotateX * rotateSpeed;
        rotation = Quaternion.Euler(0f, turn, 0f);
        playerBody.MoveRotation(playerBody.rotation * rotation);
    }

    private void Attack() 
    {
        if (Input.GetButton("FireM1") && !Input.GetButton("FireM2")) 
        {
            charging += Time.deltaTime;
        }

        if (Input.GetButtonUp("FireM1") && charging > 1.5f && !Input.GetButton("FireM2"))
        {
            anim.SetTrigger("PowerAttacking");
            charging = 0;
        }
        else if (Input.GetButtonUp("FireM1") && !Input.GetButton("FireM2")) 
        {
            anim.SetTrigger("BasicAttacking");
            charging = 0;
        }

        if (Input.GetButtonDown("FireM2") && !Input.GetButton("FireM1"))
        {
            anim.SetTrigger("SpecialAttacking");
        }
        else 
        {

        }
    }

    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    public bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    void game_over()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "GG"));
    }

    public void regenerateHP() 
    {
        changeCurrentHP(getHpRegenValue());
    }

    public void regeneratePower() 
    {
        changePower(getPowerRegenValue());
    }

    public void TakeDamage(int damage)
    {
        changeCurrentHP(-damage);
    }

    public int getCurrentHP() 
    {
        return currentHP;
    }

    public void changeCurrentHP(int value) 
    {
        if (currentHP + value <= 0)
        {
            currentHP = 0;
            game_over();
        }
        else if (currentHP + value >= maxHP)
        {
            currentHP = maxHP;
        }
        else 
        {
            currentHP += value;
        }
    }

    public int getMaxHP() 
    {
        return maxHP;
    }

    public void setMaxHP(int value) 
    {
        maxHP = value;
    }

    public float getHpRegenTime() 
    {
        return hpRegenTime;
    }

    public void setHpRegenTime(float value) 
    {
        hpRegenTime = value;
    }

    public int getHpRegenValue() 
    {
        return hpRegenValue;
    }

    public void setHpRegenValue(int value) 
    {
        hpRegenValue = value;
    }

    public int getPower() 
    {
        return power;
    }

    public void changePower(int value) 
    {
        if (power + value <= 0)
        {
            power = 0;
        }
        else if (power + value >= maxPower)
        {
            power = maxPower;
        }
        else
        {
            power += value;
        }
    }

    public int getPowerRegenValue() 
    {
        return powerRegenValue;
    }

    public void setPowerRegenValue(int value) 
    {
        powerRegenValue = value;
    }

    public float getPowerRegenTime() 
    {
        return powerRegenTime;
    }

    public void setPowerRegenTime(float value) 
    {
        powerRegenTime = value;
    }

    public abstract void basicAttack();

    public abstract void powerAttack();

    public abstract void specialAttack();

    public abstract void setupStats();
}
