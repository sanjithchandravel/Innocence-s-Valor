using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    public static int number = 0;
    public static bool endMission = false;

    public TMP_Text scoreText;

    public static int Score = 0;

	private Vector2 rotationInput;

    private Rigidbody myBody;

    private Animator anim;

    private bool isPlayerMoving;

    private float playerSpeed = 0.2f;

    private float rotationSpeed = 4f;

    private float jumpForce = 3f;

    private bool canJump;

    private float moveHori, moveVerti;

    private float rotY = 0f;

    public Transform groundCheck;

    public LayerMask groundLayer;

    public static bool CanClick = true;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        rotY = transform.localRotation.eulerAngles.y;
        number = 0;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboad();
        AnimatePlayer();
        //Attack();
        IsOnGround();
        Jump();
        Phone();
        Donate();
		//MoveAndRotate ();
    }

    void FixedUpdate()
    {
        MoveAndRotate();
    }

    void PlayerMoveKeyboad()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveHori = -1f;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveHori = 0f;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveHori = 1f;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveHori = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveVerti = 1f;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveVerti = 0f;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveVerti = -1f;
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveVerti = 0f;
        }

    }

    void MoveAndRotate()
    {
        if (moveVerti != 0)
        {
            myBody.MovePosition(transform.position + transform.forward * (moveVerti * playerSpeed));
        }
		/*if (moveHori != 0)
		{
			myBody.MovePosition(transform.position + transform.forward * (moveHori * playerSpeed));
		}*/
        rotY += moveHori * rotationSpeed;
        myBody.rotation = Quaternion.Euler(0f, rotY, 0f);




    }

	/*void RotateWithMouse()
	{
		// Get mouse input for rotation
		rotationInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		// Adjust the rotation speed according to your preference
		float rotationSpeed = 2.0f;

		// Rotate the player horizontally based on mouse movement
		rotY += rotationInput.x * rotationSpeed;

		// Limit vertical rotation if needed
		// You can use Mathf.Clamp to limit the vertical rotation angle
		// rotX = Mathf.Clamp(rotX - rotationInput.y * rotationSpeed, -maxVerticalAngle, maxVerticalAngle);

		// Apply the new rotation
		//transform.rotation = Quaternion.Euler(0f, rotY, 0f);
		myBody.rotation = Quaternion.Euler(0f, rotY, 0f);


	}*/
    void AnimatePlayer()
    {
        if (moveVerti != 0)
        {
            if (!isPlayerMoving)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
                    isPlayerMoving = true;
                    anim.SetTrigger(MyTags.RUN_TRIGGER);
                }
            }
        }
        else
        {
            if (isPlayerMoving)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
                    isPlayerMoving = false;
                    anim.SetTrigger(MyTags.STOP_TRIGGER);
                }

            }
        }
    }

    void Attack()
    {
        if ((Input.GetKeyDown(KeyCode.F)))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION) || !anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ATTACK_ANIMATION))
            {
                anim.SetTrigger(MyTags.ATTACK_TRIGGER);

            }

        }
    }

    void IsOnGround()
    {
        

        canJump = Physics.Raycast(groundCheck.position, Vector3.down, 0.4f, groundLayer);
        print(canJump);
        
            print(groundCheck.position);
        print(groundLayer.value);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                canJump = false;
                myBody.MovePosition(transform.position + transform.up * (jumpForce * playerSpeed));
                anim.SetTrigger(MyTags.JUMP_TRIGGER);
            }
        }
    }

    void Phone()
    {
        if(EmyScript.doneWithConvo == true && CanClick == true)
        {
            CanClick = false;
            anim.SetTrigger(MyTags.PHONE_TRIGGER);
            Score += 10;
            scoreText.text = "Score: " + Score;
            number = 2;
            EmyScript.doneWithConvo = false;
            Invoke("end", 9f);
        }
    }


    void Donate()
    {
        if(EmyScript.Gbutton1 == true && CanClick == true)
        {
            CanClick = false;
            anim.SetTrigger(MyTags.DONATE_TRIGGER);
            EmyScript.Gbutton1 = false; 
            number = 1;
            Invoke("end", 9f);

        }
    }
    void end()
    {
        //number = 0;
        //anim.SetTrigger(MyTags.STOP_TRIGGER);
        endMission = true;
    }

}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private FCGWaypointsContainer currentWaypointContainer;
    private int currentWaypointIndex = 0;

    private Rigidbody myBody;

    private Animator anim;

    private bool isPlayerMoving;

    private float playerSpeed = 0.2f;

    private float rotationSpeed = 4f;

    private float jumpForce = 3f;

    private bool canJump;

    private float moveHori, moveVerti;

    private float rotY = 0f;

    public Transform groundCheck;

    public LayerMask groundLayer;

    // ... (other variables)

    void Update()
    {
        PlayerMoveKeyboad();
        AnimatePlayer();
        //Attack();
        IsOnGround();
        Jump();

        // Check if the player is currently on a waypoint container
        if (currentWaypointContainer)
        {
            // Check for player input to move to the next waypoint
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveToNextWaypoint();
            }
        }
    }

    // ... (other functions)

    void OnTriggerEnter(Collider other)
    {
        // Check if she player enters a waypoint container trigger
        FCGWaypointsContainer waypointContainer = other.GetComponent<FCGWaypointsContainer>();
        if (waypointContainer)
        {
            // Set the current waypoint container and reset the index
            currentWaypointContainer = waypointContainer;
            currentWaypointIndex = 0;
        }
    }
    void MoveAndRotate()
    {
        if (moveVerti != 0)
        {
            myBody.MovePosition(transform.position + transform.forward * (moveVerti * playerSpeed));
        }

        rotY += moveHori * rotationSpeed;
        myBody.rotation = Quaternion.Euler(0f, rotY, 0f);




    }
    void AnimatePlayer()
    {
        if (moveVerti != 0)
        {
            if (!isPlayerMoving)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
                    isPlayerMoving = true;
                    anim.SetTrigger(MyTags.RUN_TRIGGER);
                }
            }
        }
        else
        {
            if (isPlayerMoving)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
                    isPlayerMoving = false;
                    anim.SetTrigger(MyTags.STOP_TRIGGER);
                }

            }
        }
    }

    void MoveToNextWaypoint()
    {
        if (currentWaypointContainer)
        {
            // Get the waypoints from the current container
            List<Transform> waypoints = currentWaypointContainer.waypoints;

            // Check if there are waypoints in the container
            if (waypoints.Count > 0)
            {
                // Increment the index and loop back to the start if necessary
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = 0;
                }

                // Move the player to the next waypoint
                Vector3 nextWaypointPosition = waypoints[currentWaypointIndex].position;
                transform.position = nextWaypointPosition;
            }
        }
    }
    void PlayerMoveKeyboad()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveHori = -1f;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveHori = 0f;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveHori = 1f;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveHori = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveVerti = 1f;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveVerti = 0f;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveVerti = -1f;
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveVerti = 0f;
        }

    }
    void IsOnGround()
    {


        canJump = Physics.Raycast(groundCheck.position, Vector3.down, 0.1f, groundLayer);
        print(canJump);
        print(groundCheck.position);
        print(groundLayer.value);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                canJump = false;
                myBody.MovePosition(transform.position + transform.up * (jumpForce * playerSpeed));
                anim.SetTrigger(MyTags.JUMP_TRIGGER);
            }
        }
    }

}*/
