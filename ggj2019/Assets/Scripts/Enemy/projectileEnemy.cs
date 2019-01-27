using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEnemy : MonoBehaviour
{
    public float speed = 20f;
    public GameObject[] players;
    public int boltDamage = 5;

    Rigidbody boltBody;
    private void Awake()
    {
        boltBody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        boltBody.velocity = transform.forward * speed;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        players = GameObject.FindGameObjectsWithTag("Players");
        for (int i = 0; i < players.Length; i++)
        {
            Collider hit = players[i].GetComponent<Collider>();
            if (other == hit)
            {
                
                Health.TakeDamage(boltDamage);
            }
        }

    }
    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
