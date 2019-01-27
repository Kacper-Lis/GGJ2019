using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour
{
    public float speed = 8f;
    public int boltDamage = 15;

    [HideInInspector]public GameObject[] enemys;
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
    }
    // Update is called once per frame
    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            MeleeHealth health = enemys[i].GetComponent<MeleeHealth>();
            Collider hit = enemys[i].GetComponent<Collider>();
            if (other == hit)
            {
                Debug.Log("Hit e");
                health.DamageEnemy(boltDamage);
                Destroy(gameObject);
            }
        }
    }
}
