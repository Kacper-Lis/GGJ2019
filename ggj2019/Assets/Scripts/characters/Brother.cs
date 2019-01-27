using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brother : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    Animator anim;
    Rigidbody playerBody;
    float moveX;
    float rotateX;
    Vector3 movement;
    Quaternion rotation;
    bool playerInRange;
    // Start is called before the first frame update
    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("Walking"); 
        }
        
    }
    void Movement()
    {
        moveX = Input.GetAxis("Vertical");
        movement = transform.forward * moveX * moveSpeed * Time.deltaTime;
        playerBody.MovePosition(playerBody.position + movement);
    }
    void Rotate()
    {
        rotateX = Input.GetAxis("Horizontal");
        float turn = rotateX * rotateSpeed;
        rotation = Quaternion.Euler(0f, turn, 0f);

        playerBody.MoveRotation(playerBody.rotation * rotation);
    }


}
