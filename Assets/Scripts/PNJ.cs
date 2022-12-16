using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    [SerializeField] private string[] sentences;
    [SerializeField] private string characterName;

    private int index;
    private bool isOnDialogue;
    private bool canDialogue;

    HUDDialogueManager dialogueManager => HUDDialogueManager.instance;

    public QuestData quest;



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && canDialogue == true)
        {
            if(quest!= null && quest.statut == QuestData.Statut.none)
            {
                StartDialogue(quest.sentence);
            }
            else if (quest != null && quest.statut == QuestData.Statut.accepter && quest.actualAmount < quest.amoutToFind)
            {
                StartDialogue(quest.InprogressSentence);
            }
            else if (quest != null && quest.statut == QuestData.Statut.accepter && quest.actualAmount == quest.amoutToFind)
            {
                StartDialogue(quest.completeSentence);
                quest.statut = QuestData.Statut.complete;
            }
            else if(quest == null)
            {
                StartDialogue(sentences);
            }
        }
    }

    public void StartDialogue(string[] sentence)
    {
        dialogueManager.DialogueHolder.SetActive(true);
        isOnDialogue = true;
        TypingText(sentence);
        dialogueManager.contenueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        dialogueManager.contenueButton.GetComponent<Button>().onClick.AddListener(delegate { NextLine(sentence); });
    }

    private void TypingText(string[] sentences)
    {
        dialogueManager.nameDisplay.text = "";
        dialogueManager.textDisplay.text = "";

        dialogueManager.nameDisplay.text = characterName;
        dialogueManager.textDisplay.text = sentences[index];

        if(dialogueManager.textDisplay.text == sentences[index])
        {
            dialogueManager.contenueButton.SetActive(true);
        }
    }

    public void NextLine(string[] sentence)
    {
        dialogueManager.contenueButton.SetActive(false);

        if(isOnDialogue && index < sentence.Length - 1)
        {
            index++;
            dialogueManager.textDisplay.text = "";
            TypingText(sentence);
        }else if(isOnDialogue && index == sentence.Length - 1)
        {
            isOnDialogue = false;
            index = 0;
            dialogueManager.nameDisplay.text = "";
            dialogueManager.textDisplay.text = "";
            dialogueManager.DialogueHolder.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canDialogue = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canDialogue = false;
        }
    }
}
