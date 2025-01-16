using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGrenade : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
