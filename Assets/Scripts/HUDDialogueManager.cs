using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDDialogueManager : MonoBehaviour
{
    public static HUDDialogueManager instance;

    public GameObject DialogueHolder;
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI textDisplay;
    public GameObject contenueButton;

    private void Awake()
    {
        instance = this;
    }
}
