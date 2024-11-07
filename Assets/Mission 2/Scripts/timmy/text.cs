using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class text : MonoBehaviour
{

    public TMP_Text timer;
    private float T;
    private GameObject player;
    public GameObject welcome;
    private bool isFalse = false;
    public GameObject straight;
    public GameObject seeLeft;
    public GameObject missionCompleted;
    public TMP_Text panelText;
    public GameObject panel;
    public TMP_Text panelText2;
    public GameObject uiCanvas; // Reference to the Canvas containing the UI elements.
    public TMP_Text messageText;

    public GameObject textUpPanel;
    public GameObject textDownPanel;
    // public bool[] isShow = new bool[4];
    private bool isUIActive = false;
    // private bool isOff = true;
    private float amy_w_t = 4f;
    // Start is called before the first frame update

    private void Awake()
    {
        T = 100;
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
        Straight();
        OnLeft();
        MissionEnd();

        float temp = 1f;
        if (T <= temp)
        {
            isFalse = true;
            Invoke("Finish", 0f);
            timer.text = "Timer: 0";
        } else
        {
            CountDownTimer();
        }
        //check();
    }

    private void ShowMessage(string message)
    {
        Debug.Log("Showing message: " + message);
        messageText.text = message;
        panel.SetActive(false);
        uiCanvas.SetActive(true);
        panel.SetActive(false);
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
            ShowMessage("Mission 2");
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
            ShowMessage("Rescue the child");
            Invoke("OnDestroy", 6f);

        }

    }

    void MissionEnd()
    {
        if (player1.end1 == true)
        {
            if (player1.number1 == 2)
            {
                ShowMessage("Mission Passed");
            }
            else
            {
                ShowMessage("Mission Failed");
            }
            textUpPanel.SetActive(false);
            textDownPanel.SetActive(false);
            Invoke("Finish", 10f);
        }
    }

    void CountDownTimer()
    {
        T -= Time.deltaTime;
        timer.text = "Time: " + T.ToString("F0");

        
    }
    void Finish()
    {
        if (player1.number1 == 2)
        {
            panelText.text = "Mission Passed";
            panelText2.text = "You've succesfully rescued the child";
        }
        else if (player1.number1 == 1 || isFalse == true)
        {
            panelText.text = "Mission Failed";
            panelText2.text = "Oops! You failed to rescue the child";
        }
        player1.number1 = 0;
        textUpPanel.SetActive(false);
        textDownPanel.SetActive(false);
        panel.SetActive(true);
        player1.end1 = false;
        
    }

    
}