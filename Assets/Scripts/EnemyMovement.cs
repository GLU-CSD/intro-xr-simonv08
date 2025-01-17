using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform BaseTransform;
    private Health Health;

    void Start()
    {
        // Vind de NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        Health = GetComponent<Health>();

        // Zoek de XR Rig met de tag "Base"
        GameObject Base = GameObject.FindGameObjectWithTag("Base");
        if (Base != null)
        {
            BaseTransform = Base.transform;
        }
    }

    // Update is called once per frame

    void Update()
    {
        // Beweeg naar de positie van de speler als deze is gevonden
        if (BaseTransform != null  && Health.currentHealth>0)
        {
            agent.SetDestination(BaseTransform.position);
        }
     
    }
}
