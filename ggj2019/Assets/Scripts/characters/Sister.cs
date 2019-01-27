using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private Animator anim;

    Rigidbody playerBody;
    float moveX;
    float rotateX;
    Vector3 movement;
    Quaternion rotation;
    // Start is called before the first frame update
    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        float checkX = Input.GetAxisRaw("Vertical1");
        moveX = Input.GetAxis("Vertical1");
        rotateX = Input.GetAxis("Horizontal1");
        if (checkX == 1 || checkX == -1)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
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
