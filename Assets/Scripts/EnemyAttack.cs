using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f;       // Schade per aanval
    [SerializeField] private float attackCooldown = 2f;      // Tijd tussen aanvallen
    private float lastAttackTime;          // Tijd sinds laatste aanval

    private Health baseHealth;       // Referentie Health script base


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        // Zorg dat de base de tag "Base" heeft
        {
            baseHealth = collision.gameObject.GetComponent<Health>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            baseHealth = null;
            // Verwijdert de referentie wanneer de vijand de base verlaat
        }
    }

    void Update()
    {
        if (baseHealth != null && Time.time >= lastAttackTime + attackCooldown)
        {
            baseHealth.TakeDamage(damageAmount); // Schade doen aan de base
            lastAttackTime = Time.time; // Tijd van laatste aanval bijwerken
            Debug.Log(this.name + "attacked the base!");
        }
    }

}
