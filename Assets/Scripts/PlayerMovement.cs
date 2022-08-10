using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float diveForce;
    [SerializeField] private CopMovement copMovement;
    [SerializeField] private PlayerRotation playerRotation;
    private Rigidbody _rigidBody;

    private bool isJumping;
    public bool isGrounded;
    
    private bool _goLeft;
    private bool _goRight;
    private bool _goMiddleFromRight;
    private bool _goMiddleFromLeft;
    
    private string _line = "Middle";
    private int _lineNumber = 2;

    [HideInInspector] public float speedX;
    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    
    void Update()
    { 
        ChangeTheLine();
        CheckLineCoordinate();
    }

    private void FixedUpdate()
    {
        Move();
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            Jump();
        }
        if (!isGrounded && isJumping && Input.GetKey(KeyCode.S))
        {
            DiveThroughDownward();
        }
    }

    private void Move()
    {
        _rigidBody.velocity = new Vector3(speedX, _rigidBody.velocity.y, speed);
    }

    private void Jump()
    {
        _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, jumpForce, _rigidBody.velocity.z);
        isJumping = true;
        isGrounded = false;
    }

    private void DiveThroughDownward()
    {
        _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, diveForce, _rigidBody.velocity.z);
    }
    
    private void ChangeTheLine()
    {
        if (Input.GetKeyDown(KeyCode.A) && _line == "Middle" && _lineNumber != 1)
        {
            playerRotation.rotationAngle = -60f;
            _goLeft = true;
            _goRight = false;
            _goMiddleFromRight = false;
            _goMiddleFromLeft = false;
            copMovement.pressAtoLeft = true;
            _lineNumber -= 1;
            _line = "Left";
        }
        
        else if (Input.GetKeyDown(KeyCode.A) && _line == "Right" && _lineNumber != 2)
        {
            playerRotation.rotationAngle = -60f;
            _goMiddleFromRight = true;
            _goMiddleFromLeft = false;
            _goLeft = false;
            _goRight = false;
            copMovement.pressAtoMiddle = true;
            _lineNumber -= 1;
            _line = "Middle";
        }
        
        else if (Input.GetKeyDown(KeyCode.D) && _line == "Left" && _lineNumber != 2)
        {
            playerRotation.rotationAngle = 60f;
            _goMiddleFromLeft = true;
            _goLeft = false;
            _goRight = false;
            _goMiddleFromRight = false;
            copMovement.pressDtoMiddle = true;
            _lineNumber += 1;
            _line = "Middle";
        }
        
        else if (Input.GetKeyDown(KeyCode.D) && _line == "Middle" && _lineNumber != 3)
        {
            playerRotation.rotationAngle = 60f;
            _goRight = true;
            _goLeft = false;
            _goMiddleFromRight = false;
            _goMiddleFromLeft = false;
            copMovement.pressDtoRight = true;
            _lineNumber += 1;
            _line = "Right";
        }
    }

    private void CheckLineCoordinate()
    {
        if (_goLeft)
        {
            speedX = -8f;
            if (transform.position.x <= -3.4f)
            {
                playerRotation.rotationAngle = 0f;
                speedX = 0f;
                _goLeft = false;
            }
        }
        
        if (_goRight)
        {
            speedX = 8f;
            if (transform.position.x >= 3.4f)
            {
                playerRotation.rotationAngle = 0f;
                speedX = 0f;
                _goRight = false;
            }
        }
        
        if (_goMiddleFromLeft)
        {
            speedX = 8f;
            if (transform.position.x >= -.1f)
            {
                playerRotation.rotationAngle = 0f;
                speedX = 0f;
                _goMiddleFromLeft = false;
            }
        }
        
        if (_goMiddleFromRight)
        {
            speedX = -8f;
            if (transform.position.x <= .1f)
            {
                playerRotation.rotationAngle = 0f;
                speedX = 0f;
                _goMiddleFromRight = false;
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
    }

}
