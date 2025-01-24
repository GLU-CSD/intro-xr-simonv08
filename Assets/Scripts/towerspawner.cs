using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerspawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    private bool hasSpawned = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain") && !hasSpawned)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            hasSpawned = true;
        }
    }
}
