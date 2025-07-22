using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Maneja el orden correcto de interruptores

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public int[] correctOrder = { 1, 2, 3 }; // Cambiar orden según puzzle
    private int currentIndex = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void CheckSwitch(int id)
    {
        if (id == correctOrder[currentIndex])
        {
            currentIndex++;
            if (currentIndex >= correctOrder.Length)
            {
                Debug.Log("¡Puzzle completado!");
                // Desbloquear puerta, activar plataforma, etc.
            }
        }
        else
        {
            Debug.Log("Orden incorrecto. Reiniciando puzzle.");
            currentIndex = 0;
        }
    }
}
