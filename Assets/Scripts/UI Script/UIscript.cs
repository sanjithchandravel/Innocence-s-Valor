/*using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{
    public Text dialogueText;
    public Button responseButton;
    public GameObject npc;

    private string[] dialogueLines;
    private int currentLine = 0;

    private enum DialogueState { Player, NPC }
    private DialogueState currentState;

    private void Start()
    {
        dialogueLines = new string[]
        {
            "Player: Why are you begging here?",
            "NPC: I am begging because my boss instructed me to beg at this traffic signal",
            "Player: Do you want to study?",
            "NPC: Yes sir, I want to study and lead a normal life. Is there any way?",
            "Player: According to article 24 in Indian Constitution, there shouldn't be any child labour in this country.",
            "Player: Let's call child helpline 1098. Press H to call the helpline."
        };

        currentState = DialogueState.Player;
        ShowNextLine();
    }

    private void Update()
    {
        if (currentState == DialogueState.Player && Input.GetKeyDown(KeyCode.Return))
        {
            ShowNextLine();
        }
        else if (currentState == DialogueState.NPC && Input.GetKeyDown(KeyCode.H))
        {
            // Implement the logic to call the helpline here.
        }
    }

    private void ShowNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;

            // Determine the speaker (Player or NPC) and change the state accordingly.
            currentState = (currentState == DialogueState.Player) ? DialogueState.NPC : DialogueState.Player;
        }
        else
        {
            // Dialogue ends. You can implement a closing action here.
        }
    }
}*/


using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public bool isReady = false;
    public GameObject uiCanvas; // Reference to the Canvas containing the UI elements.
    public TMP_Text messageText;

    private List<string> messages = new List<string>();
    private int currentMessageIndex = 0;
    private bool isUIActive = false;

    private void Start()
    {
        uiCanvas.SetActive(false); // Initially deactivate the UI Canvas.

        // Add your messages to the list.
        messages.Add("Player: Why are you begging here?");
        messages.Add("NPC: I am begging because my boss instructed me to beg at this traffic signal");
        messages.Add("Player: Do you want to study?");
        messages.Add("NPC: Yes sir, I want to study and lead a normal life. Is there any way?");
        messages.Add("Player: According to article 24 in Indian Constitution, there shouldn't be any child labour in this country.");
        messages.Add("Player: Let's call child helpline 1098. ");
        messages.Add("Press H to call the helpline.");
    }

    private void Update()
    {
        if (isReady)
        {
            if (Input.GetMouseButtonDown(0)) // Check for left mouse button click.
            {
                Debug.Log("Left mouse button clicked.");
                // Check if the UI is currently active and respond accordingly.
                if (isUIActive)
                {
                    // Display the next message, if available.
                    currentMessageIndex++;
                    if (currentMessageIndex < messages.Count)
                    {
                        ShowMessage(messages[currentMessageIndex]);
                    }
                    else
                    {
                        // No more messages. Close the UI.
                        uiCanvas.SetActive(false);
                    }
                }
                else
                {
                    // Start displaying messages.
                    currentMessageIndex = 0;
                    ShowMessage(messages[currentMessageIndex]);
                }
            }
        }
    }

        private void ShowMessage(string message)
    {
        Debug.Log("Showing message: " + message);
        messageText.text = message;
        uiCanvas.SetActive(true);
        isUIActive = true;
    }
}
