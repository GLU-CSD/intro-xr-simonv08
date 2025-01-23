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
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            Debug.Log("holstered");
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
