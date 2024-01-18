using UnityEngine;
using UnityEngine.UI;

public class Dialog2 : MonoBehaviour
{
    public Text textUI;
    public string[] dialogueLines;
    private int currentLine;

    void Start()
    {
        currentLine = 0;
        UpdateText();
    }

    void UpdateText()
    {
        if (textUI != null && currentLine < dialogueLines.Length)
        {
            textUI.text = dialogueLines[currentLine];
        }
    }

    void Update()
    {
        // You can trigger the next line using any input or event.
        // For example, you might want to trigger the next line when the player presses a key.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    void NextLine()
    {
        currentLine++;

        // If there are no more lines, you can hide the text box or perform other actions.
        if (currentLine >= dialogueLines.Length)
        {
            // Example: Hide the text box when the dialogue ends
            gameObject.SetActive(false);
        }
        else
        {
            UpdateText();
        }
    }
}