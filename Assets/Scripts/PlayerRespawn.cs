using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float respawnDelay = 1f;

    public void Respawn()
    {
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        transform.position = GameManager.Instance.lastCheckpoint;
        GetComponent<PlayerHealth>().RestoreFullHealth();
    }
}
