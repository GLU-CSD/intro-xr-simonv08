using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] private float bulletVelocity;

    public void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,  firepoint.position, firepoint.rotation);
        bullet.transform.rotation *= Quaternion.Euler(90, 0, 0);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null )
        {
            rb.AddForce(firepoint.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}
