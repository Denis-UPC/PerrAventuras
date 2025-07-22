using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script permite generar obstáculos, enemigos o coleccionables de forma aleatoria en el nivel.
// Está pensado para usarse en zonas como desafíos, habitaciones secretas o niveles infinitos.
//
// PARA USAR: agregar este script a un GameObject vacío llamado "SpawnerZone"
// y vincular los prefabs y zona de spawn.
// Por ahora queda desactivado.

public class ProceduralSpawner : MonoBehaviour
{
    [Header("Prefabs a generar aleatoriamente")]
    public GameObject[] objectsToSpawn;

    [Header("Cantidad de objetos")]
    public int minObjects = 3;
    public int maxObjects = 6;

    [Header("Zona de spawn")]
    public Vector2 areaSize = new Vector2(10, 5);

    [Header("Control")]
    public bool generateOnStart = false;

    void Start()
    {
        if (generateOnStart)
            SpawnObjects();
    }

    public void SpawnObjects()
    {
        int count = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < count; i++)
        {
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                0f,
                Random.Range(-areaSize.y / 2, areaSize.y / 2)
            );

            int index = Random.Range(0, objectsToSpawn.Length);
            Instantiate(objectsToSpawn[index], randomPos, Quaternion.identity);
        }
    }

    // Visualiza la zona en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, 1f, areaSize.y));
    }
}
