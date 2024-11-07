using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject uiCanvas; // Reference to the Canvas containing the UI elements.
    public Text interactionText;

    private bool isUIActive = false;

    private void Start()
    {
        uiCanvas.SetActive(false); // Initially deactivate the UI Canvas.
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click.
        {
            // Check if the UI is currently active and respond accordingly.
            if (isUIActive)
            {
                // Handle interaction logic when the mouse button is clicked.
                // For example, close the UI or perform an action.
                // You can also call functions to continue the dialogue or perform other actions.
                uiCanvas.SetActive(false);
                interactionText.text = "";
            }
        }
    }
}

