using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que debe ir en el objeto "Hueso" (con Collider isTrigger)

public class BoneCollectible : MonoBehaviour
{
    public int boneValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BoneManager.instance.AddBones(boneValue);
            Destroy(gameObject);
        }
    }
}
