using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneManager : MonoBehaviour
{
    public static BoneManager instance;
    public int totalBones = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddBones(int amount)
    {
        totalBones += amount;
        Debug.Log("Huesos totales: " + totalBones);
    }
}
