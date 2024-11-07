using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    private GameObject player;
    public GameObject welcome;
    public GameObject left;
    public GameObject straight;
    public GameObject seeLeft;
    public GameObject missionCompleted;
    public GameObject uiCanvas; // Reference to the Canvas containing the UI elements.
    public TMP_Text messageText;
    public TMP_Text panelText;
    public GameObject panel;
    public TMP_Text panelText2;


    public GameObject textUpPanel;
    public GameObject textDownPanel;
   // public bool[] isShow = new bool[4];
    private bool isUIActive = false;
   // private bool isOff = true;
    private float amy_w_t = 4f;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }
    void Start()
    {
        uiCanvas.SetActive(false);
        panel.SetActive(false);
        textUpPanel.SetActive(false);
        textDownPanel.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Welcome();
        Left();
        Straight();
        OnLeft();
        MissionEnd();
        //check();
    }

    private void ShowMessage(string message)
    {
        Debug.Log("Showing message: " + message);
        messageText.text = message;
        panel.SetActive(false);
        uiCanvas.SetActive(true);
        panel.SetActive(false);
		textUpPanel.SetActive(false);
		textDownPanel.SetActive(false);
        isUIActive = true;
    }

    private void OnDestroy()
    {
        messageText.text = " ";
    }

    void Welcome()
    {
        Vector3 direction = player.transform.position - welcome.transform.position;
        float dist = direction.magnitude;
        direction.Normalize();
        if (dist < amy_w_t)
        {
            ShowMessage("Welcome Innocence's Valor");
            //Invoke("OnDestroy", 10f);
        }

 
    }

    void Left()
    {
        Vector3 direction = player.transform.position - left.transform.position;
        float dist = direction.magnitude;
        direction.Normalize();
        if (dist < amy_w_t)
        {
            ShowMessage("Turn Left");
            //Invoke("OnDestroy", 10f);

        }
        
    }

    void Straight()
    {
        Vector3 direction = player.transform.position - straight.transform.position;
        float dist = direction.magnitude;
        direction.Normalize();
        if (dist < amy_w_t)
        {
            ShowMessage("Go Straight");
            Invoke("OnDestroy", 10f);

        }
        
    }

    void OnLeft()
    {
        Vector3 direction = player.transform.position - seeLeft.transform.position;
        float dist = direction.magnitude;
        direction.Normalize();
        if (dist < amy_w_t)
        {
            ShowMessage("Rescue the child on your left");
            Invoke("OnDestroy", 6f);

        }
        
    }

    void MissionEnd()
    {
        if(PlayerScript.endMission == true)
        {
            if (PlayerScript.number == 2)
            {
                ShowMessage("Mission Passed");
            }
            else
            {
                ShowMessage("Mission Failed");
            }
            Invoke("Finish", 5f);
        }
    }

    void Finish()
    {
        if(PlayerScript.number == 2) {
            panelText.text = "Mission Passed";
            panelText2.text = "You've succesfully rescued the child";
        }
        else if(PlayerScript.number == 1) { 
            panelText.text = "Mission Failed";

            panelText2.text = "Oops! You failed to rescue the child";
        }
        ShowMessage(" ");
        PlayerScript.number = 0;
        textUpPanel.SetActive(false);
        textDownPanel.SetActive(false);
        panel.SetActive(true);
        PlayerScript.endMission = false;
    }

    /*void check()
    {
        isOff = true;
        for (int i = 0; i < 4; i++)
        {
            if (isShow[i] != false)
            {
                isOff = false;
            }
        }
        if (isOff)
        {
            uiCanvas.SetActive(false);
        }
    }*/
}
