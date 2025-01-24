using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Bullet prefab
    [SerializeField] private Transform firepoint;     // Firing point
    [SerializeField] private float bulletVelocity = 10f; // Bullet speed
    private bool shooting = false;
    private float nextFireTime = 0f;
    [SerializeField] private float fireRate = 1f;
    private void Update()
    {
        if (shooting == true && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
    public void Shoot()
    {
        // Instantiate and shoot the bullet
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.transform.rotation *= Quaternion.Euler(90, 0, 0);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firepoint.forward * bulletVelocity, ForceMode.Impulse);
        }
    }

    public void startShooting()
    {
        shooting = true;
    }

    public void stopShooting()
    {
        shooting = false;
    }
}
