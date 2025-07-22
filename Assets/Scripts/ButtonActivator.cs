using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script para el botón que al pisarse activa una plataforma móvil o puente.

// Consejo: El objeto objectToActivate puede ser una plataforma animada con Animator o moverla con script.
public class ButtonActivator : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            objectToActivate.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            objectToActivate.SetActive(false);
        }
    }
}
