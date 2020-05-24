using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEnemy : MonoBehaviour
{
    public float speed = 7f;
    [HideInInspector]public GameObject[] players;
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
        Destroy(gameObject, 1f);
        players = GameObject.FindGameObjectsWithTag("Players");
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < players.Length; i++)
        {
            Collider hit = players[i].GetComponent<Collider>();
            if (other == hit)
            {
                Debug.Log("P hit");
                //Health.TakeDamage(boltDamage);
                Destroy(gameObject);
            }
        }

    }
    
    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
