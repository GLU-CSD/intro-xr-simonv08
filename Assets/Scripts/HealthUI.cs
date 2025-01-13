using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private string prefabTag = "Enemy";
    private Health HealthScript;

    void Start()
    {
        
    }

    void Update()
    {
        if (HealthScript == null)
        {
            GameObject spawnedPrefab = GameObject.FindWithTag(prefabTag);
            if (spawnedPrefab != null)
            {
                HealthScript = spawnedPrefab.GetComponent<Health>();
            }

        }
    }

    public void DamageButton()
    {
        if (HealthScript != null)
        {
            HealthScript.TakeDamage(10);
        }
    }

    public void HealButton()
    {
        if (HealthScript != null)
        {
            HealthScript.RestoreHealth(10);
        }
    }
}
