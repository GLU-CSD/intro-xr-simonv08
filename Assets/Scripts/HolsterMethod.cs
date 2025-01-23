using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolsterMethod : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            other.transform.SetParent(transform);
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            Debug.Log("holstered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            other.transform.SetParent(null);
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.freezeRotation = false;
            Debug.Log("unholstered");
        }
    }
}
