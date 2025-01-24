using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Image healthbarFill;
    public float currentHealth;
    public float ghostHealth;
    public bool IsDead;
    private void Start()
    {
        currentHealth = maxHealth;
        ghostHealth = maxHealth;
        IsDead = false;
        UpdateHealthBar();
    }

    

    void UpdateHealthBar()
    {
        healthbarFill.fillAmount = currentHealth / maxHealth;
    }

    public async void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            IsDead = true;
            NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.enabled = false;
            }
            
            Destroy(gameObject, 1f);
        }
    }

    public void GhostDamage(float amount)
    {
        ghostHealth -= amount;
        if (ghostHealth <= 0)
        {
            IsDead = true;
        }
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }


}
