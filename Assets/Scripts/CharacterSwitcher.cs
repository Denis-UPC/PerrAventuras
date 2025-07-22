using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    //Generar lista para cambio entre Protagonistas
    public List<GameObject> characters;
    private int currentIndex = 0;

    void Start()
    {
        ActivateCharacter(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentIndex = (currentIndex + 1) % characters.Count;
            ActivateCharacter(currentIndex);
        }
    }

    void ActivateCharacter(int index)
    {
        for (int i = 0; i < characters.Count; i++)
            characters[i].SetActive(i == index);
    }
}
