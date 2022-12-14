using UnityEngine;

public class CopMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;
    public float speed;
    
    private bool _copGoLeft;
    private bool _copGoRight;
    private bool _copGoMiddleFromRight;
    private bool _copGoMiddleFromLeft;

    [HideInInspector] public bool jumpingController;
    [HideInInspector] public bool rollingController;
    
    [HideInInspector] public bool pressAtoMiddle;
    [HideInInspector] public bool pressAtoLeft;
    [HideInInspector] public bool pressDtoMiddle;
    [HideInInspector] public bool pressDtoRight;
    [SerializeField] private CopRotation copRotation;
    
    private string _line = "Middle";
    private int _lineNumber = 2;

    private bool _timerActive;
    private float _timeLimit = 0.2f;
    private float _timeCounter;
    
    private float _speedForDirection;
    private float _speedX;
    private float _copRotationHolder;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TimerForChangeLine();
    }
    
    void FixedUpdate()
    {
        Move();
        ChangeTheLine();
        CheckLineCoordinate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("UnderTrigger"))
        {
            rollingController = true;
        }
        
        else if (other.gameObject.CompareTag("OverTrigger"))
        {
            jumpingController = true;
        }
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_speedX, _rigidbody.velocity.y, speed);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
    }
    
    public void ChangeTheLine()
    {
        if (pressAtoLeft && _line == "Middle" && _lineNumber != 1)
        {
            _copGoLeft = true;
            _copGoRight = false;
            _copGoMiddleFromRight = false;
            _copGoMiddleFromLeft = false;
            _lineNumber -= 1;
            _line = "Left";
            pressAtoLeft = false;
        }
        
        else if (pressAtoMiddle && _line == "Right" && _lineNumber != 2)
        {
            _copGoMiddleFromRight = true;
            _copGoMiddleFromLeft = false;
            _copGoLeft = false;
            _copGoRight = false;
            _lineNumber -= 1;
            _line = "Middle";
            pressAtoMiddle = false;
        }
        
        else if (pressDtoMiddle && _line == "Left" && _lineNumber != 2)
        {
            _copGoMiddleFromLeft = true;
            _copGoLeft = false;
            _copGoRight = false;
            _copGoMiddleFromRight = false;
            _lineNumber += 1;
            _line = "Middle";
            pressDtoMiddle = false;
        }
        
        else if (pressDtoRight && _line == "Middle" && _lineNumber != 3)
        {
            _copGoRight = true;
            _copGoLeft = false;
            _copGoMiddleFromRight = false;
            _copGoMiddleFromLeft = false;
            _lineNumber += 1;
            _line = "Right";
            pressDtoRight = false;
        }
    }

    public void CheckLineCoordinate()
    {
        if (_copGoLeft)
        {
            _timerActive = true;
            _speedForDirection = -8f;
            _copRotationHolder = -60f;
            if (transform.position.x <= -3.4f)
            {
                _speedX = 0f;
                copRotation.rotationAngle = 0f;
                _timeCounter = 0f;
                _timerActive = false;
                _copGoLeft = false;
            }
        }
        
        if (_copGoRight)
        {
            _timerActive = true;
            _speedForDirection = 8f;
            _copRotationHolder = 60f;
            if (transform.position.x >= 3.4f)
            {
                _speedX = 0f;
                copRotation.rotationAngle = 0f;
                _timeCounter = 0f;
                _timerActive = false;
                _copGoRight = false;
            }
        }
        
        if (_copGoMiddleFromLeft)
        {
            _timerActive = true;
            _speedForDirection = 8f;
            _copRotationHolder = 60f;
            if (transform.position.x >= -.1f)
            {
                _speedX = 0f;
                copRotation.rotationAngle = 0f;
                _timeCounter = 0f;
                _timerActive = false;
                _copGoMiddleFromLeft = false;
            }
        }
        
        if (_copGoMiddleFromRight)
        {
            _timerActive = true;
            _speedForDirection = -8f;
            _copRotationHolder = -60f;
            if (transform.position.x <= .1f)
            {
                _speedX = 0f;
                copRotation.rotationAngle = 0f;
                _timeCounter = 0f;
                _timerActive = false;
                _copGoMiddleFromRight = false;
            }
        }
    }

    private void TimerForChangeLine()
    {
        if (_timerActive)
        {
            if (_timeCounter >= _timeLimit)
            {
                copRotation.rotationAngle = _copRotationHolder;
                _speedX = _speedForDirection;
            }
            _timeCounter += Time.deltaTime;
        }
    }
}
