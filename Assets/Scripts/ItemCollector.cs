using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int itemsCollected = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemsCollected++;
            Debug.Log("Items recolectados: " + itemsCollected);
            Destroy(other.gameObject);
        }
    }
}
