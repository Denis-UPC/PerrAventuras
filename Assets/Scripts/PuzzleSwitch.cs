using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Cada interruptor debe tener este script con su ID correspondiente.
public class PuzzleSwitch : MonoBehaviour
{
    public int switchID;
    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            PuzzleManager.instance.CheckSwitch(switchID);
        }
    }
}
