using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [HideInInspector] public float damage = 50f;
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * Speed * Time.deltaTime;
        transform.LookAt(target.position, Vector3.up);
        transform.Rotate(-90, 0, 0);
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Health enemyHealth = target.GetComponent<Health>();
        if (enemyHealth != null )
        {
            enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
