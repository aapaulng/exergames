using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    //testing purposes
    public float direction;

    CharacterController controller;
    bool isGrounded = false;

    public GameControlScript gamecontrol;
    public CountDownScript count;
    public PauseMenuScript pause;
    //audio source reference variables
    public AudioSource powerCollectSound;
    public AudioSource jumpSound;
    public AudioSource snagCollectSound;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    //location of character
    int Left = -2;
    int Middle = 0;
    int Right = 2;
    int location = 0;
 

    float tempVectorValue = 0f;

    //extra Script
    public GameControlScript control;
    private GestureListener gestureListener;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        // get the gestures listener
        gestureListener = Camera.main.GetComponent<GestureListener>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.isGrounded && count.isCountDown) {
            GetComponent<Animation>().Play("run");
 
            if (Input.GetKeyDown("left")||gestureListener.IsFlyLeft())
            {
                location = CalculateMotion((int)controller.GetComponent<Transform>().localPosition.x, -1);
            }
            else if (Input.GetKeyDown("right") || gestureListener.IsFlyRight())
            {
                location = CalculateMotion((int)controller.GetComponent<Transform>().localPosition.x, 1);
            }
            else
            {
                location = CalculateMotion((int)controller.GetComponent<Transform>().localPosition.x, 0);
            }
            
            //moveDirection = new Vector3(tempVectorValue, 0, 0);
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            //moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection *= speed;
           

            if (pause.paused == false && pause.enabled == true)
            {
                gameObject.GetComponent<AudioSource>().enabled = true; 
            }
            else if (pause.paused == true || count.isCountDown == false)
            {
                gameObject.GetComponent<AudioSource>().enabled = false;
            }


            if (Input.GetKeyDown("left") || gestureListener.IsSwipeLeft())
            {
                location = CalculateMotion((int)controller.GetComponent<Transform>().localPosition.x, -1);
            }
            else if (Input.GetKeyDown("right") || gestureListener.IsSwipeRight())
            {
                location = CalculateMotion((int)controller.GetComponent<Transform>().localPosition.x, 1);
            }
            else
            {
                location = CalculateMotion((int)controller.GetComponent<Transform>().localPosition.x, 0);
            }
           
           
           //moveDirection = new Vector3(tempVectorValue, 0, 0);
           //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
           // moveDirection = transform.TransformDirection(moveDirection);
           // moveDirection *= speed;

            if (Input.GetButton("Jump")) {
                GetComponent<Animation>().Stop("run");
                GetComponent<Animation>().Play("jump_pose");
                jumpSound.Play();
                gameObject.GetComponent<AudioSource>().enabled = false;
                moveDirection.y = jumpSpeed;
            } 
            else if (gestureListener.IsFlap())
            {
                GetComponent<Animation>().Stop("run");
                GetComponent<Animation>().Play("jump_pose");
                jumpSound.Play();
                gameObject.GetComponent<AudioSource>().enabled = false;
                moveDirection.y = jumpSpeed; 
            }
            
           

            if (controller.isGrounded) {  //recursive, extra one, not nessacary
                isGrounded = true;   
            }

            if (control.isGameOver)
            {
                gameObject.GetComponent<AudioSource>().enabled = false;
            }

        }

        if (((gestureListener.IsRaiseLeftHand() || gestureListener.IsRaiseRightHand())) && !count.enabled)
        {
            Debug.Log("CountDownStart"+gestureListener.IsRaiseRightHand());
            StartCountDown();
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);   //used for jump
        controller.transform.localPosition = new Vector3(location, controller.GetComponent<Transform>().position.y, -7);
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Powerup(Clone)" || other.gameObject.name =="BossPowerup(Clone)") {
            powerCollectSound.Play();
            control.PowerUpCollected();
        }

        else if (other.gameObject.name == "Obstacle(Clone)"||other.gameObject.name =="BossObstacle(Clone)") {
            snagCollectSound.Play();
            control.AlcoholCollected();
        }
        else if (other.gameObject.name == "JumpWall(Clone)" || other.gameObject.name == "BossJumpWall(Clone)")
        {
            control.JumpWallCollected();
        }

        else if (other.gameObject.name == "JumpWallSafeZone" || other.gameObject.name == "BossJumpWallSafeZone")
        {
            Debug.Log("EnterSafeZone");
            control.SlowMotion();
        }
        else if (other.gameObject.name == "JumpWallTop" || other.gameObject.name == "BossJumpWallTop")
        {
            Debug.Log("Going Back To Original Speed");
            control.NormalMotion();
        }
        else if (other.gameObject.name == "ResetTimeScaleA(Clone)" || other.gameObject.name=="ResetTimeScaleB(Clone)")
        {
            Time.timeScale = 1f;
        }
        Destroy(other.gameObject);
        
      

    }

    int CalculateMotion(int current, int input)
    {
        if ((current==-2 && input==-1)||(current==0 && input==-1)||(current==-2 && input==0))
        {
            return -2;
        }
        else if ((current == 0 && input == 1) || (current == 2 && input == 1)||(current==2 && input==0))
        {
            return 2;
        }
        else 
        {
            return 0;
        }
    }

    public void StartCountDown()
    {
        count.enabled = true;
    }
}
