using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 respawnPosition;

    void Start()
    {
        respawnPosition = transform.position; // Posición inicial
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            respawnPosition = other.transform.position;
            Debug.Log("Checkpoint alcanzado: " + respawnPosition);
        }
    }

    public void Respawn()
    {
        transform.position = respawnPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
