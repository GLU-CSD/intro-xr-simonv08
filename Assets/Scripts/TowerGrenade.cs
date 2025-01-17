using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGrenade : Projectile
{
    [SerializeField] private float explosionForce = 500f;      // Kracht van de explosie
    [SerializeField] private float explosionRadius = 5f;       // Radius van de explosie

    internal override void Explode()
    {
        // Vind alle objecten in de buurt van de explosie
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.gameObject.CompareTag("Enemy"))
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);

                    if (nearbyObject.CompareTag("Enemy"))
                    {
                        Health healthscript = nearbyObject.GetComponent<Health>();
                        if (healthscript != null)
                        {
                            healthscript.TakeDamage(damage);

                        }

                    }
                }
            }
        }
        Destroy(gameObject);
    }
}
