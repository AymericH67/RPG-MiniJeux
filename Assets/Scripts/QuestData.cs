using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/NewQuest")]
public class QuestData : ScriptableObject
{
    public int id;
    public string title;
    public string description;
    public string[] sentence, InprogressSentence, completeSentence;
    public string objectToFind;
    public int actualAmount, amoutToFind;
    public int goldToGive;

    [System.Serializable]
    public enum Statut
    {
        none,
        accepter, 
        complete
    }

    public Statut statut;

}
