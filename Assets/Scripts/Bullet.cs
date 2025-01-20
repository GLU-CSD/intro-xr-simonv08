using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 30f;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Debug.Log("hit target");
            hit(collision.gameObject);
            Destroy(gameObject); 
        }
    }

    private void hit(GameObject target)
    {
        Health enemyHealth = target.GetComponent<Health>();
        Debug.Log("hit function works");
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Debug.Log("enemy takes damage");
        }
    Destroy(gameObject);
    Debug.Log("Destroyed game object");
    }
}
