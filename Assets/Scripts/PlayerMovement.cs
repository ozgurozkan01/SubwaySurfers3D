using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private AnimationController animController;
    private Rigidbody _rigidBody;

    public bool isGrounded;
    
    private bool _goLeft;
    private bool _goRight;
    private bool _goMiddleFromRight;
    private bool _goMiddleFromLeft;
    
    private string _line = "Middle";
    private int _lineNumber = 2;

    private float _speedX;
    
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
    }

    private void Move()
    {
        _rigidBody.velocity = new Vector3(_speedX, _rigidBody.velocity.y, speed);
    }

    private void Jump()
    {
        _rigidBody.velocity = new Vector3(0f, jumpForce, _rigidBody.velocity.z);
        isGrounded = false;
    }
    
    private void ChangeTheLine()
    {
        if (Input.GetKeyDown(KeyCode.A) && _line == "Middle" && _lineNumber != 1)
        {
            animController.RightTurnOf();
            _goLeft = true;
            _goRight = false;
            _goMiddleFromRight = false;
            _goMiddleFromLeft = false;
            _lineNumber -= 1;
            _line = "Left";
        }
        
        else if (Input.GetKeyDown(KeyCode.A) && _line == "Right" && _lineNumber != 2)
        {
            animController.RightTurnOf();
            _goMiddleFromRight = true;
            _goMiddleFromLeft = false;
            _goLeft = false;
            _goRight = false;
            _lineNumber -= 1;
            _line = "Middle";
        }
        
        else if (Input.GetKeyDown(KeyCode.D) && _line == "Left" && _lineNumber != 2)
        {
            animController.RightTurnOn();
            _goMiddleFromLeft = true;
            _goLeft = false;
            _goRight = false;
            _goMiddleFromRight = false;
            _lineNumber += 1;
            _line = "Middle";
        }
        
        else if (Input.GetKeyDown(KeyCode.D) && _line == "Middle" && _lineNumber != 3)
        {
            animController.RightTurnOn();
            _goRight = true;
            _goLeft = false;
            _goMiddleFromRight = false;
            _goMiddleFromLeft = false;
            _lineNumber += 1;
            _line = "Right";
        }
    }

    private void CheckLineCoordinate()
    {
        if (_goLeft)
        {
            _speedX = -8f;
            if (transform.position.x <= -3.4f)
            {
                _speedX = 0f;
                _goLeft = false;
            }
        }
        
        if (_goRight)
        {
            _speedX = 8f;
            if (transform.position.x >= 3.4f)
            {
                animController.RightTurnOf();
                _speedX = 0f;
                _goRight = false;
            }
        }
        
        if (_goMiddleFromLeft)
        {
            _speedX = 8f;
            if (transform.position.x >= -.1f)
            {
                animController.RightTurnOf();
                _speedX = 0f;
                _goMiddleFromLeft = false;
            }
        }
        
        if (_goMiddleFromRight)
        {
            _speedX = -8f;
            if (transform.position.x <= .1f)
            {
                _speedX = 0f;
                _goMiddleFromRight = false;
            }
        }
    }

    private void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
