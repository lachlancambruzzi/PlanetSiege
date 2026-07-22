using TMPro;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    public GameObject dialogueBalloon;
    public TextMeshProUGUI dialogueText;

    void Start()
    {
        HideDialogue();
    }

    public void ShowDialogue(string message, float duration = 2f)
    {
        dialogueBalloon.SetActive(true);
        dialogueText.text = message;
        CancelInvoke(nameof(HideDialogue)); // Cancel previous hide calls
        Invoke(nameof(HideDialogue), duration);
    }

    public void HideDialogue()
    {
        dialogueBalloon.SetActive(false);
    }
}