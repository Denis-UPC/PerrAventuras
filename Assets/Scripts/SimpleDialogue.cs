using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Puedes vincular esto a un OnTriggerEnter() con el jugador o botón para iniciar la secuencia.

public class SimpleDialogue : MonoBehaviour
{
    public string[] dialogueLines;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    private int currentLine;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void TriggerDialogue()
    {
        currentLine = 0;
        dialoguePanel.SetActive(true);
        ShowLine();
    }

    public void ShowLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
