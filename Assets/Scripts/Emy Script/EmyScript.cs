/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundscript : MonoBehaviour
{
    public Transform player;
    public float x, y, z;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.IDLE_ANIMATION))
        {
            // If it's the player and the animation is in the specified state, set the animation trigger.
            anim.SetTrigger(MyTags.BEG1_TRIGGER);
            if(other.gameObject.tag == "Player" && anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.BEG1_ANIMATION))
            {
                anim.SetTrigger(MyTags.BEG2_TRIGGER);
            }
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class EmyScript : MonoBehaviour
{
    public static bool Hbutton1 = false;

    public static bool Gbutton1 = false;

    public static bool doneWithConvo = false;
    public bool isReady = false;
    private GameObject player;
    private Rigidbody myBody;
    private Animator anim;
    public GameObject uiCanvas; // Reference to the Canvas containing the UI elements.
    public TMP_Text messageText;
    public TMP_Text guidance;
    public TMP_Text yourText;

    public GameObject textUpPanel;
    public GameObject textDownPanel;

    public bool isCall = true;

    private List<string> messages = new List<string>();
    private int currentMessageIndex = 0;
    private bool isUIActive = false;

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

        messages.Add("Press G to Give Money\nPress H to Call Helpline");
        messages.Add("You: Hey! Why are you begging here?");

        messages.Add("Child: I'm asking because my boss instructed me to beg at this location.");

        messages.Add("You: Do you want to go to school?");

        messages.Add("Child: Yes, sir, I want to learn and have a regular life. Is there a way?");

        messages.Add("You: According to ARTICLE 21-A in our country, children have the right to compulsory education!");

        messages.Add("You: Let's call the child helpline");

        messages.Add("You: Child Helpline Number is 1098");


    }

    void FixedUpdate()
    {
        EnemyAI();
    }

    private void Update()
    {
        if (isReady)
        {
            if (isCall)
            {
                
                ShowMessage(messages[currentMessageIndex], currentMessageIndex);
                currentMessageIndex++;
                PlayerScript.CanClick = true;
                isCall = false;
            }

            if (Input.GetKeyDown(KeyCode.G))
                {

                    Gbutton1 = true;
                    Hbutton1 = false;
                }
                if (Input.GetKey(KeyCode.H))
                {
                    Hbutton1 = true;
                    Gbutton1 = false;

                }
                
            
            
        }
        DisplayMessage();
    }

    void DisplayMessage()
    {
        
        if(Hbutton1 == true && Gbutton1 == false)
        {
            if (Input.GetMouseButtonDown(0)) // Check for left mouse button click.
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
                anim.SetTrigger(MyTags.HEAD_TRIGGER);

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
                        doneWithConvo = true;
						Hbutton1 = false;
                        anim.SetTrigger(MyTags.STOP_TRIGGER);
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


    private void ShowMessage(string message,int i)
    {
        /*if(i == 7)
        {
            guidance.text = message;
            yourText.text = " ";
            messageText.text = " ";
            Hbutton1 = true;

        }*/
        if(i%2 == 0)
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
			textUpPanel.SetActive(true);
			textDownPanel.SetActive(true);
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
                anim.SetTrigger(MyTags.BEG1_TRIGGER);
            }

            anim.SetTrigger(MyTags.BEG2_TRIGGER);
            isReady = true;
            
            //transform.LookAt(new Vector3(player.transform.position.x,transform.position.y,transform.position.z));

        }
        else
        {

            anim.SetTrigger(MyTags.STOP_TRIGGER);
            isReady = false;
            /*myBody.velocity = new Vector3(0f, 0f, 0f);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION))
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }*/
        }
    }
}

