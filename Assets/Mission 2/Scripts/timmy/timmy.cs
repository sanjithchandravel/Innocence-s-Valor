using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timmy : MonoBehaviour
{
    public static bool Hbutton = false;
    public bool isReady = false;
    private GameObject player;
    private Rigidbody myBody;
    private Animator anim;
    public GameObject uiCanvas; // Reference to the Canvas containing the UI elements.
    public TMP_Text messageText;
    public TMP_Text guidance;
    public TMP_Text yourText;

	public bool isOpen = true;

    private List<string> messages = new List<string>();
    private int currentMessageIndex = 0;
    private bool isUIActive = false;


    public GameObject textUpPanel;
    public GameObject textDownPanel;
    //private float enemy_speed=10f;
    private float amy_w_t = 10f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        uiCanvas.SetActive(false); // Initially deactivate the UI Canvas.
        textUpPanel.SetActive(false);
        textDownPanel.SetActive(false);

        // Add your messages to the list.
        messages.Add("You: Hey, why do you appear unsteady while walking ? Are you feeling alright?");

        messages.Add("Child: this is because I enjoyed having alcohol today..whoooa!");

        messages.Add("You: Well, it's not the right time for someone your age to be drinking alcohol, my young friend!");

        messages.Add("Child: That's none of your concern, mister!");

        messages.Add("You: You're just a kid! According to the NDPS Act, it's illegal for a person of your age to consume drugs or alcohol.If caught, there can be serious consequences.");

        messages.Add("You: Let's call the child helpline");

        messages.Add("You: Child Helpline Number is 1098");

        messages.Add("You: Press 'H' to make the call.");

    }

    void FixedUpdate()
    {
        EnemyAI();
    }

    private void Update()
    {
        if (isReady)
        {
            if (Input.GetMouseButtonDown(0)) // Check for left mouse button click.
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
                

                Debug.Log("Left mouse button clicked.");
                // Check if the UI is currently active and respond accordingly.
                if (isUIActive)
                {
                    // Display the next message, if available.
                    currentMessageIndex++;
                    if (currentMessageIndex < messages.Count)
                    {
                        ShowMessage(messages[currentMessageIndex], currentMessageIndex);
                    }
                    else
                    {
                        // No more messages. Close the UI.
                        Hbutton = true;
						isOpen = false;
                        //uiCanvas.SetActive(false);
                    }
                }
                else
                {
                    // Start displaying messages.
                    currentMessageIndex = 0;
                    ShowMessage(messages[currentMessageIndex], currentMessageIndex);
                }
            }
        }
    }

    private void ShowMessage(string message, int i)
    {
        if (i % 2 == 0)
        {
            Debug.Log("Showing message: " + message);
            yourText.text = message;
            guidance.text = " ";
            uiCanvas.SetActive(true);
            textDownPanel.SetActive(true);
            textUpPanel.SetActive(true);
            isUIActive = true;
        }
        else
        {
            Debug.Log("Showing message: " + message);
            messageText.text = message;
            guidance.text = " ";
            uiCanvas.SetActive(true);
            textDownPanel.SetActive(true);
            textUpPanel.SetActive(true);
            isUIActive = true;
        }


    }

    void EnemyAI()
    {
        Vector3 direction = player.transform.position - transform.position;
        float dist = direction.magnitude;
        direction.Normalize();

        //Vector3 velocity= direction*enemy_speed;

        if (dist < amy_w_t)
        {
            //myBody.velocity=new Vector3(velocity.x,myBody.velocity.y,velocity.z);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.IDLE_ANIMATION))
            {
                anim.SetTrigger(MyTags.DRINK1_TRIGGER);
            }

            anim.SetTrigger(MyTags.DRINK2_TRIGGER);
            isReady = true;

        }
        else
        {

            anim.SetTrigger(MyTags.STOP_TRIGGER);
            isReady = false;
        }
    }
}
